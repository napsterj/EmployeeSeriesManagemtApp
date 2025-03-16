using EmployeeSeriesManagemt.Frontend.Models;
using EmployeeSeriesManagemt.Frontend.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using io = System.IO;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Encodings.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace EmployeeSeriesManagemt.Frontend.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) 
        {
            _employeeService = employeeService;
        }
        public IActionResult Search(EmployeePersonalAddressVM employeeAddressVM)
        {            
            ModelState.Clear();
            return View(employeeAddressVM);
        }
        
        public async Task<IActionResult> SearchByCity(EmployeePersonalAddressVM employeeAddressVM) 
        {           

            if (ModelState.IsValid)
            {
                var response = await _employeeService.GetPersonalAddressesByCity(employeeAddressVM.SearchTerm);
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    ViewData["NoRecords"] = $"{response.ErrorMessage}";
                    return View("Search", new EmployeePersonalAddressVM());
                }


                var employeesAddresses = JsonConvert.DeserializeObject<DeserializeHandlerEmployeeAddressesCity>
                                                            (Convert.ToString(response.Result));
                
                if (employeesAddresses != null)
                {
                    var employeeAddressesVM = new EmployeePersonalAddressVM
                    {
                        SearchTerm = employeeAddressVM.SearchTerm,
                        EmployeesAddresses = employeesAddresses.Result
                    };
                    return View("Search", employeeAddressesVM);
                }
                
            }

            return View("Search", new EmployeePersonalAddressVM());
            
        }

        [HttpGet]
        public IActionResult SearchByExternalId()
        {
            return View(new EmployeeAddressVM());
        }

        [HttpPost]
        public async Task<IActionResult> SearchByExternalId(EmployeeAddressVM employeeAddressVM)
        {
            if(employeeAddressVM.ExternalEmployeeIdf == 0)
            {                
                return View(new EmployeeAddressVM() 
                            { 
                               ErrorMessage = AppConstants.INVALID_EMPLOYEE_ID
                            });
            }

            var response = await _employeeService.GetEmployeeAddressById(employeeAddressVM.ExternalEmployeeIdf);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                return View(new EmployeeAddressVM()
                {
                    ErrorMessage = response.ErrorMessage!
                });                
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {                
                return View("SearchByExternalId", 
                            new EmployeeAddressVM() { ErrorMessage = response.ErrorMessage });
            }

            
           
            var addressEmployeeVM = new EmployeeAddressVM();
            var result = JsonConvert.DeserializeObject<DeserializeHandlerAddressById>
                                           (Convert.ToString(response.Result));
            
            addressEmployeeVM.Addresses = result?.Result.EmployeeAddresses;
            addressEmployeeVM.EmployeeName = result?.Result.EmployeeName;

            return View(addressEmployeeVM);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails(int Id)
        {
            var response = await _employeeService.GetEmployeeById(Id);

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                ViewData["Error"] = response.ErrorMessage!;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                ViewData["Error"] = response.ErrorMessage!;
            }
            
            var employeeDto = new EmployeeDto();
            if (response != null)
            {               
                var output = JsonConvert.DeserializeObject<DeserializeHandlerEmployeeProfile>(Convert.ToString(response.Result));
                employeeDto = output?.Result;
            }
            if (employeeDto != null)
            {                
                var (profile, error) = await GetProfilePicture(employeeDto.ProfileImage, 
                                                        $"{employeeDto.FirstName}{employeeDto.LastName}");
            }

            return View("EmployeeProfileVM", employeeDto);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEmployeeSeries(EmployeeDto employeeDto)
        {
            employeeDto.SeriesRequestDto.ExternalEmployeeIdf = employeeDto.ExternalIdf;
            var response = await _employeeService.SaveEmployeeSeries(employeeDto.SeriesRequestDto);
            if (response.StatusCode == HttpStatusCode.OK) 
            {
                var result = JsonConvert.DeserializeObject<DeserializeEmployeeSeries>(Convert.ToString(response.Result));
                if (result != null && result.Result != null)
                {
                    employeeDto.Series.Add(result.Result);
                }
            }
            return RedirectToAction("GetEmployeeDetails",new { Id = employeeDto.ExternalIdf });
        }
        private async Task<(string?, string?)> GetProfilePicture(string profilePictureBase64, string fullName)
        {
            try
            {
                var path = Path.Combine(Environment.CurrentDirectory, $"wwwroot\\images\\{fullName}_{DateTime.UtcNow.Year}.jpg");
                var fileBytes = Convert.FromBase64String(profilePictureBase64);
                using (var imageFile = new MemoryStream(fileBytes))
                {
                    Image image = Image.FromStream(imageFile,false, true);
                    if (image != null)
                    {
                        image.Save(path, ImageFormat.Png);
                    }
                }            
                
                return (path, null);
            }
            catch (OutOfMemoryException ex)
            {
                return (null, "Problem in displaying the profile picture");
            }
            catch (Exception ex)
            {
                return (null, "Some error has occured");
            }
            return ("", "");
        }
    }
}
