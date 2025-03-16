using EmployeeSeriesManagemt.Frontend.Models;

namespace EmployeeSeriesManagemt.Frontend.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto> SendAsync(RequestDto reqestDto);
    }
}
