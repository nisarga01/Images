using Images.DTO;
using Images.IServices;
using Images.Models;
using Images.ServiceResponse;

namespace Images.Services
{
    public class ImageService : IImageServices
    {
        public async Task<ServiceResponse<ImageResponseDTO>> addImageAsync(ImageRequestDTO imageRequestDTO)
        {
            string photoUrl = HandleFileUpload(imageRequestDTO.Photo);

            var Response = new ServiceResponse<ImageResponseDTO>()
            {
                Data = !string.IsNullOrEmpty(photoUrl) ? new ImageResponseDTO()
                {
                    Photo = photoUrl
                } : null,
                Success = !string.IsNullOrEmpty(photoUrl),
                ErrorMessage = string.IsNullOrEmpty(photoUrl) ? "Failed to upload image." : null,
                ResultMessage = string.IsNullOrEmpty(photoUrl) ? "Failed to upload image." : "Image uploaded successfully."
            };
            return Response;
        }

        private string HandleFileUpload(IFormFile photo)
        {
            if (photo == null || photo.Length == 0)
            {
                return null;
            }

            // Define a folder path to store the photos
            var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "photos");

            // Create the folder if it doesn't exist
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            // Generate a unique filename for the photo
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
            var filePath = Path.Combine(uploadFolder, fileName);

            // Save the photo to the file system
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(fileStream);
            }

            // Return the URL of the saved photo
            return "/photos/" + fileName; // Adjust this based on your project's URL structure
        }
    }
}


