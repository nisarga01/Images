using Images.DTO;
using Images.ServiceResponse;

namespace Images.IServices
{
    public interface IImageServices
    {
        Task<ServiceResponse<ImageResponseDTO>> addImageAsync(ImageRequestDTO imageRequestDTO);
    }
}
