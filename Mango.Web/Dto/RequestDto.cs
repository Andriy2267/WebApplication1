using static Mango.Web.Utility.SD;

namespace Mango.Web.Dto
{
    public class RequestDto
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; } = string.Empty;
        public object Data { get; set; } = string.Empty;
        public string AccessToken { get; set; } = string.Empty;
    }
}
