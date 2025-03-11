﻿using EmployeeSerierManagemt.API.Dtos;
using EmployeeSeriesManagemt.API.Common;
using EmployeeSeriesManagemt.BL.IService;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using EmployeeSerierManagemt.API.Mapper;
using EmployeeSerierManagemt.API.Common;
using Newtonsoft.Json;

namespace EmployeeSerierManagemt.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService, 
                                     ILogger<EmployeesController> logger) : ControllerBase
    {

        private readonly IEmployeeService _employeeService = employeeService;
        private readonly ILogger<EmployeesController> _logger = logger;
        private ResponseDto _responseDto = new();

        [HttpGet("get/employee/addresses/{externalEmployeeIdf:int}")]
        [ServiceFilter(typeof(ModelStateFilterAttribute))]
        public IActionResult GetEmployeeAddress(int externalEmployeeIdf)
        {            
            _logger.LogInformation($"Accessing endpoint: {nameof(GetEmployeeAddress)}");

            if (externalEmployeeIdf == 0)
            {                                
                return BadRequest(GetResponseDto(HttpStatusCode.BadRequest,
                                                           CommonConstants.INVALID_EMPLOYEE_ID));
            }

            var result = _employeeService.GetAddressesByEmployeeId(externalEmployeeIdf);

            var mapper = new AddressMapper();

            var addresses = mapper.AddressesToAddressesDto(result);
            
            var responseDto = GetResponseDto(HttpStatusCode.OK, "", addresses);
                                    
            return Ok(responseDto);

        }

        [HttpGet("get/employee/address/personal")]
        [ServiceFilter(typeof(ModelStateFilterAttribute))]
        public IActionResult GetPersonalAddressByCity(string city)
        {
            _logger.LogInformation($"Accessing endpoint: {nameof(GetPersonalAddressByCity)}");

            var response = _employeeService.GetAddressByCity(city);

            if (response is null || response.Count == 0)
            {
                var responseDto = GetResponseDto(HttpStatusCode.NotFound,
                                                 $"{CommonConstants.NO_RECORDS_FOUND} {city}");

                return NotFound(responseDto);
            }

            var employees = response.SelectMany(s => s.Employees);
            var addressMapper = new AddressMapper();

            var employeeAddresses = (from a in response
                                     select new EmployeeAddressResponseDto
                                     {
                                         Address = addressMapper.AddressToAddressDto(a),
                                         EmployeeNames = [.. a.Employees.Select(e => $"{e.FirstName} {e.LastName}")]
                                     }).ToHashSet();

            var result = GetResponseDto(HttpStatusCode.OK, string.Empty, employeeAddresses);

            return Ok(result);

        }

        [HttpGet("get/employee/series/datewise")]
        [ServiceFilter(typeof(ModelStateFilterAttribute))]
        public IActionResult GetEmployeeSeriesByDates([FromQuery]SeriesRequestDto requestDto)
        {
            _logger.LogInformation($"Accessing endpoint: {nameof(GetEmployeeSeriesByDates)}");

            var series = _employeeService.GetEmployeeSeriesByPeriod(requestDto.ExternalEmployeeIdf,
                                                                    requestDto.StartDate,
                                                                    requestDto.EndDate);
            if (series is null || series.Count == 0)
            {
                return BadRequest(GetResponseDto(HttpStatusCode.BadRequest,
                                                           CommonConstants.NO_SERIES_FOUND));
            }

            var seriesMapper = new SeriesCollectionMapper();
            var seriesDto = seriesMapper.SeriesToSeriesDtoCollection(series);

            var responseDto = GetResponseDto(HttpStatusCode.OK, string.Empty, seriesDto);
            
            return Ok(responseDto);

        }

        [HttpGet]
        [Route("{externalEmployeeIdf:int}", Name = nameof(GetEmployeeById))]
        public async Task<IActionResult> GetEmployeeById(int externalEmployeeIdf)
        {
            _logger.LogInformation($"Accessing endpoint: {nameof(GetEmployeeById)}");

            if (externalEmployeeIdf == 0)
            {
                return BadRequest(GetResponseDto(HttpStatusCode.BadRequest, 
                                                 CommonConstants.INVALID_EMPLOYEE_ID));
            }

            var response = await _employeeService.GetEmployeeById(externalEmployeeIdf);
            
            if(response is null)
            {
                return NotFound(GetResponseDto(HttpStatusCode.NotFound, 
                                               $"{CommonConstants.NO_EMPLOYEE_RECORD_FOUND}{externalEmployeeIdf}"));
            }

            var mapper = new EmployeeResponseMapper();
            var employee = mapper.EmployeeToEmployeeDto(response);

            return Ok(GetResponseDto(HttpStatusCode.OK, "", employee));

        }

        [HttpGet("get/seriesbycode/{seriesCode:int}")]        
        [ServiceFilter(typeof(ModelStateFilterAttribute))]
        public async Task<IActionResult> GetEmployeeSeriesByCode(int seriesCode)
        {
            _logger.LogInformation($"Accessing endpoint: {nameof(GetEmployeeSeriesByCode)}");

            var response = await _employeeService.GetEmployeeSeriesByCode(seriesCode);

            var mapper = new SeriesMapper();
            
            var seriesDto = mapper.SeriesToSeriesDto(response);

            var responseDto = GetResponseDto(HttpStatusCode.OK, "", seriesDto);

            return Ok(responseDto);
        }

        [HttpPost("add/employee/new")]
        [ServiceFilter(typeof(ModelStateFilterAttribute))]
        public async Task<IActionResult> SaveEmployee([FromBody]EmployeeDto employeeDto)
        {
            _logger.LogInformation($"Accessing endpoint: {nameof(SaveEmployee)}");

            var employeeMapper = new EmployeeMapper();
            var employeeCardMapper = new EmployeeIdCardMapper();

            var employee = employeeMapper.EmployeeDtoToEmployee(employeeDto);

            await _employeeService.VerifyNewEmployeeContactDetailsNotExist(employee);            
            
            if (employeeDto.EmployeeIdCardsDto is not null)
            {
                employee.EmployeeCard = employeeCardMapper.EmployeeCardDtoToEmployeeCard(employeeDto.EmployeeIdCardsDto);                
            }
            
            var newEmployee = await _employeeService.SaveNewEmployee(employee); 
            
            if(newEmployee.ExternalIdf == 0)
            {
                throw new Exception("Some error has occured");
            }

            var mapper = new EmployeeResponseMapper();
            var employeeResponse = mapper.EmployeeToEmployeeDto(newEmployee);
            
            var responseDto = GetResponseDto(HttpStatusCode.Created, string.Empty, employeeResponse);

            return CreatedAtRoute(nameof(GetEmployeeById),
                                  routeValues: new { externalEmployeeIdf = employeeResponse.ExternalIdf}, 
                                  responseDto);
        }

        [HttpPost("add/employee/series")]
        public async Task<IActionResult> SaveEmployeeSeries([FromBody]SeriesRequestDto seriesRequestDto)
        {
            _logger.LogInformation($"Accessing endpoint: {nameof(SaveEmployeeSeries)}");

            var mapper = new SeriesRequestMapper();
            var newSeries = mapper.SeriesRequestDtoToSeries(seriesRequestDto);

            var response = await _employeeService.SaveNewEmployeeSeries(newSeries);

            var responseDto = GetResponseDto(HttpStatusCode.Created, "", response);

            return CreatedAtRoute("get/seriesbycode/", 
                                  routeValues: new {seriesCode = response.Code}, 
                                  responseDto);
        }

        private ResponseDto GetResponseDto(HttpStatusCode statusCode, 
                                           string? errorMessage = "", 
                                           object? result = null)
        {
            _responseDto.Result = result;
            _responseDto.StatusCode = statusCode;
            _responseDto.ErrorMessage = errorMessage;

            if (result != null)
            {
                _logger.LogInformation($"{Environment.NewLine} " + 
                                       $"Successful Response: {JsonConvert.SerializeObject(result)}" +
                                       $"{Environment.NewLine}");
            }
            else { 
                _logger.LogError($"Error: {errorMessage}"); 
            }
            return _responseDto;
        }

    }
}
