using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static Mango.Web.Utility.SD;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> SendAsynch(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                //token
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }


                message.RequestUri = new Uri(requestDto.Url);
                //For Get Request we are ok

                //But for Post, Put we need to selialize dataas below 
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                //After request send we will also get response
                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                //from the API we will be getting resposeDto, we can always deserialize that
                //But before we do that we should always check the status code of the response i.e recieved 

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSucces = false, Mesages = "Not found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSucces = false, Mesages = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSucces = false, Mesages = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSucces = false, Mesages = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;

                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    Mesages = ex.Message.ToString(),
                    IsSucces = false
                };
                return dto;
            }
        }

    }
}
