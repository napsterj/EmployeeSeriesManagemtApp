namespace EmployeeSeriesManagemt.API.Common
{
    public static class CommonConstants
    {
        public const int PERSONAL_ADDRESS = 1;
        public const int WORK_ADDRESS = 2;

        
        //Error messages
        public const string INVALID_EMPLOYEE_ID = "Employee id is invalid.";
        public const string NO_RECORDS_FOUND = "No employees found in the city of ";
        public const string NO_SERIES_FOUND = "No series found for this employee in the specified date range.";
        public const string NO_EMPLOYEE_RECORD_FOUND = "No valid employee found with the id: ";       

    }
}
