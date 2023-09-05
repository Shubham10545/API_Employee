using Domain.Models;
using Domain.ViewModels;
using Repository;
using System.Linq.Expressions;

namespace Service
{
    public class EmployeeService : IEmployee

    {
        private readonly AppDbContect _dbContext;

        public EmployeeService(Repository.AppDbContect dbContext)
        {
            this._dbContext = dbContext;
        }
        public string AddEmployee(Employee employee)
        {
            
            this._dbContext.Employee.Add(employee);
                this._dbContext.SaveChanges();
                return " Record added sucessfully";    
        }

        public string DeleteEmployee(int id)
        {
            var RemoveEmployee =this._dbContext.Employee.Find(id);
            _dbContext.Remove(RemoveEmployee); 
            this._dbContext.SaveChanges();
            return "Record deleted sucessfully";
        }

        public List<GetAllEmployeeData> GetEmployees()
        {
            // return this._dbContext.Employee.ToList();

            var result = (from E in this._dbContext.Employee
                          join C in this._dbContext.Country on E.CountryId equals C.Id
                          join S in this._dbContext.State on C.Id equals S.CountryId
                          join CP in this._dbContext.City on S.Id equals CP.StateId

                          select new GetAllEmployeeData
                          {
                              Id= E.Id,
                             FirstName= E.FirstName,
                              LastName= E.LastName,
                              Email= E.Email,
                              Gender= E.Gender,
                              MaritalStatus= E.MaritalStatus,
                              BirthDate= E.BirthDate,
                              Salary= E.Salary,
                              Address= E.Address,
                              ZipCode= E.ZipCode,
                              Hobbies= E.Hobbies,
                              Country=C.CountryName,
                              State=S.StateName,
                              City=CP.CityName,
                              Password=E.Password
                          }).ToList();


            return result;
        }

        public Employee GetSingleEmployee(int id)
        {
            return _dbContext.Employee.Single(x => x.Id == id);
        }

        public string UpdateEmployee(Employee employee)
        {
            var employeevalue = this._dbContext.Employee.Find(employee.Id);
            if (employeevalue != null) 
            {
                employeevalue.FirstName = employee.FirstName;
                employeevalue.LastName = employee.LastName;
                employeevalue.Email = employee.Email;
                employeevalue.Gender = employee.Gender;
                employeevalue.Hobbies = employee.Hobbies;
                employeevalue.MaritalStatus = employee.MaritalStatus;
                employeevalue.BirthDate = employee. BirthDate;
                employee.Salary = employee.Salary;  
                //employeevalue.Address = employee.Address;
                employeevalue.CityId = employee.CityId;
                employeevalue.StateId = employee.StateId;
                employeevalue.CountryId = employee.CountryId;
                employeevalue.ZipCode = employee.ZipCode;
                employeevalue.Password = employee.Password;
                this._dbContext.Update(employeevalue);
                this._dbContext.SaveChanges();  
                return " Sucessfully updated the record";

            }
            else
                return " No record found";
        }

         string IEmployee.FileUploads(FileUpload fileUpload)
        {
            this._dbContext.FileUpload.Add(fileUpload);
            this._dbContext.SaveChanges();
            return " Record added sucessfully";
        }
    }
}
