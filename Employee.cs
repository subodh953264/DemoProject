using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace API.Models
{
    public class Employee
    {
        public string FirstName;
        public string LastName;
        public string Gender;
        public long salary;
        public Int32 Age;
        public Int32 Id;

        public List<Employee> GetallEmployees()
        {
            string[] Alllines = File.ReadAllLines(@"C:\Users\subodhsingh\Desktop\WebAPIDB\Employee.txt");
            List<Employee> Emp = new List<Employee>();
            for (int i = 0;i< Alllines.Length;i++)
            {
                string[] getEmployee = Alllines[i].ToString().Split(',');
                Employee e = new Employee();
                e.FirstName = getEmployee[0];
                e.LastName = getEmployee[1];
                e.Gender = getEmployee[2];
                e.salary =Convert.ToInt64( getEmployee[3]);
                e.Age =  Convert.ToInt32(getEmployee[4]);
                e.Id = Convert.ToInt32(getEmployee[5]);
                Emp.Add(e);
            }
            return Emp;
            
        }

        public void Addemployee(Employee emp)
        {
            try
            {
                String NewEmployee = emp.FirstName + "," + emp.LastName + "," + emp.Gender + "," + emp.salary + "," + emp.Age + "," + emp.Id;
                File.AppendAllText(@"C:\Users\subodhsingh\Desktop\WebAPIDB\Employee.txt",Environment.NewLine+ NewEmployee);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public int UpdateEmployee(Employee emp)
        {
            try
            {
                string[] Alllines = File.ReadAllLines(@"C:\Users\subodhsingh\Desktop\WebAPIDB\Employee.txt");
                List<Employee> Emp = new List<Employee>();
                for (int i = 0; i < Alllines.Length; i++)
                {
                   
                    string[] getEmployee = Alllines[i].ToString().Split(',');
                    if (Convert.ToInt32(getEmployee[5])==emp.Id)
                    { 
                        Alllines[i]= emp.FirstName + "," + emp.LastName + "," + emp.Gender + "," + emp.salary + "," + emp.Age + "," + emp.Id;
                        File.WriteAllLines(@"C:\Users\subodhsingh\Desktop\WebAPIDB\Employee.txt",Alllines);
                        return 1;
                        break;
                    }
                           

                  
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public void DeletEmployee(int id)
        //{
        //    try
        //    {
        //        String NewEmployee = emp.FirstName + "," + emp.LastName + "," + emp.Gender + "," + emp.salary + "," + emp.Age + "," + emp.Id;
        //        File.AppendAllText(@"C:\Users\subodhsingh\Desktop\WebAPIDB\Employee.txt", Environment.NewLine + NewEmployee);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
    }
}