using EmployeeSeriesManagemt.Frontend.Models;
using EmployeeSeriesManagemt.Frontend.Services.IServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using static EmployeeSeriesManagemt.Frontend.AppConstants;

namespace EmployeeSeriesManagemt.Frontend.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto> SendAsync(RequestDto reqestDto)
        {
            var client = _httpClientFactory.CreateClient("MyBaseService");

            HttpRequestMessage message = new()
            {
                Content = new StringContent(JsonConvert.SerializeObject(reqestDto.Data),
                                            Encoding.UTF8, "application/json"),
                RequestUri = new Uri(reqestDto.Url)
            };

            message.Method = reqestDto.ApiType switch
            {
                ApiType.GET => HttpMethod.Get,
                ApiType.POST => HttpMethod.Post,
                ApiType.PUT => HttpMethod.Put,
                _ => HttpMethod.Delete,
            };

            HttpResponseMessage responseMessage = await client.SendAsync(message);

            var responseDto = new ResponseDto();
            try
            {
                if (responseMessage != null)
                {
                    switch (responseMessage.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            responseDto.StatusCode = responseMessage.StatusCode;
                            var output = await responseMessage.Content.ReadAsStringAsync();
                            var outputWithoutSlash = JToken.Parse(output);
                            responseDto.ErrorMessage = outputWithoutSlash?.LastOrDefault()?
                                                                          .Last()
                                                                          .Value<string>();                            
                            break;

                        case HttpStatusCode.Created:
                            responseDto.StatusCode = responseMessage.StatusCode;
                            responseDto.ErrorMessage = "Created";
                            break;

                        case HttpStatusCode.InternalServerError:
                            responseDto.StatusCode = responseMessage.StatusCode;
                            responseDto.ErrorMessage = "Internal Server Error";
                            break;

                        case HttpStatusCode.BadRequest:
                            responseDto.StatusCode = responseMessage.StatusCode;
                            var content = await responseMessage.Content.ReadAsStringAsync();
                            responseDto.ErrorMessage = $"Bad Request {JsonConvert.DeserializeObject<string>(content)}";
                            break;

                        default:
                            responseDto.StatusCode =
                                                    responseMessage.StatusCode = responseMessage.StatusCode;
                            var data = await responseMessage.Content.ReadAsStringAsync();
                            responseDto.Result = JsonConvert.DeserializeObject<object>(data);
                            break;

                    }
                }
            }
            catch (Exception ex) 
            { 
            
            }
                

            return responseDto;
        }
    }
}
