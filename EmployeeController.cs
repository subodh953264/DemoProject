using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace API.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IEnumerable<Models.Employee> GetAllEmployees()
        {
            Models.Employee emp = new Models.Employee();
            return emp.GetallEmployees();
        }
        [HttpGet]
        public HttpResponseMessage GetAllEmployees(int id)
        {
            Models.Employee emp = new Models.Employee();
            IEnumerable<Models.Employee> foundemp= emp.GetallEmployees().Where(x => x.Id == id);
            if(foundemp.Count()>0)
            {
                return Request.CreateResponse(HttpStatusCode.OK, foundemp);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Employee Was found with this ID.");
            }
           
        }
        [HttpPost]
        public HttpResponseMessage AddEmployee([FromBody]Models.Employee Employee)
        {
            try
            {
                Models.Employee emp = new Models.Employee();
                emp.Addemployee(Employee);
                return Request.CreateResponse(HttpStatusCode.Created, "Employee Added Successfully.");

            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.ExpectationFailed, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateEmp([FromBody]Models.Employee Employee)
        {
            Models.Employee emp = new Models.Employee();
            emp.UpdateEmployee(Employee);
            return Request.CreateResponse(HttpStatusCode.Created, "Employee updated Successfully.");
        }


    }
}
