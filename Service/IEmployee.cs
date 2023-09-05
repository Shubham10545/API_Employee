using Domain.Models;


namespace Service
{
    public interface IEmployee
    {
        // Get All Records
        List<Domain.ViewModels.GetAllEmployeeData> GetEmployees();

        // Get Single 
        Employee GetSingleEmployee(int id);

        // Add Employee
        string AddEmployee(Employee employee);
        // Update
        string UpdateEmployee(Employee employee);
        // Delete
        string DeleteEmployee(int id);

        string FileUploads(FileUpload fileUpload);
    }
}
