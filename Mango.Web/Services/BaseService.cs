using Mango.Web.Dto;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
            HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Headers.Add("Accept", "application/json");
            // token

            httpRequestMessage.RequestUri = new Uri(requestDto.Url);
            if(requestDto.Data != null)
            {
                httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            HttpResponseMessage? responseMessage = null;

            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    httpRequestMessage.Method = HttpMethod.Post;
                    break;
                case ApiType.GET:
                    httpRequestMessage.Method = HttpMethod.Get;
                    break;
                case ApiType.PUT:
                    httpRequestMessage.Method = HttpMethod.Put;
                    break;
                default:
                    httpRequestMessage.Method = HttpMethod.Delete;
                    break;
            }

            responseMessage = await client.SendAsync(httpRequestMessage);

            switch(responseMessage.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ResponseDto() { IsSuccess = false, Message = "Not Found" };
                case HttpStatusCode.Unauthorized:
                    return new ResponseDto() { IsSuccess = false, Message = "Unauthorized" };
                case HttpStatusCode.Forbidden:
                    return new ResponseDto() { IsSuccess = false, Message = "Access Denied" };
                case HttpStatusCode.InternalServerError:
                    return new ResponseDto() { IsSuccess = false, Message = "Interlan server error" };
                default:
                    var apiContent = await responseMessage.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
            }

            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                };
                return responseDto;
            }
        }
    }
}
