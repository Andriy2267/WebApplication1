using Mango.Web.Dto;

namespace Mango.Web.Services.IServices
{
    public interface IBaseService
    {
        public Task<ResponseDto?> SendAsync(RequestDto requestDto);
    }
}
