using Domain.Models;
using Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Diagnostics.Eventing.Reader;
using static System.Net.Mime.MediaTypeNames;

namespace EmployeeAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employee;
        private static IWebHostEnvironment _webHostEnvironment;
        

        public EmployeeController(IEmployee employee,IWebHostEnvironment webHostEnvironment)
        {
            this._employee = employee;
            _webHostEnvironment = webHostEnvironment;
            
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public IActionResult GetAllRecords() 
        {
            var respone=this._employee.GetEmployees();
            return Ok(respone);
        }


        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddRecords(Employee employee )
        {

            return Ok(this._employee.AddEmployee(employee));
        }


        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult Delete(int id)
        {
            return Ok(this._employee.DeleteEmployee(id));  
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee(Employee employee)
        {
            return Ok(this._employee.UpdateEmployee(employee));
        }

        [HttpPost]
        [Route("AddFile")]


        public string Upload([FromForm] FileUpload obj)
        {
            if (obj.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                    }
                    using (FileStream filestream = System.IO.File.Create((_webHostEnvironment.WebRootPath + "\\Images\\" + obj.files.FileName)))
                    {
                        obj.files.CopyTo(filestream);
                        filestream.Flush();
                        obj.ImageName = obj.files.FileName;
                        this._employee.FileUploads( obj);
                        return "\\Images\\" + obj.files.FileName;
                    }
                }
                catch (Exception ex)

                {
                    return ex.ToString();
                }

            }
            else
            {

                return "Upload Failed";

            }
        }

    }
}
