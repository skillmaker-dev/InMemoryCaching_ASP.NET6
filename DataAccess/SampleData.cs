using DataAccess.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SampleData : ISampleData
    {
        private readonly IMemoryCache _memoryCache;

        public SampleData(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public List<Employee> GetEmployees()
        {
            //Simulate databsae delay
            Thread.Sleep(3000);

            var output = new List<Employee>()
            {
                new Employee {FirstName = "Anas",LastName = "Chahid",Salary = 5500m},
                new Employee {FirstName = "Ahmed",LastName = "Medo",Salary = 4800m},
                new Employee {FirstName = "Ayoub",LastName = "Rahmani",Salary = 6300m}
            };

            return output;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            //Simulate databsae delay
            await Task.Delay(3000);

            var output = new List<Employee>()
            {
                new Employee {FirstName = "Anas",LastName = "Chahid",Salary = 5500m},
                new Employee {FirstName = "Ahmed",LastName = "Medo",Salary = 4800m},
                new Employee {FirstName = "Ayoub",LastName = "Rahmani",Salary = 6300m}
            };

            return output;
        }

        public async Task<List<Employee>> GetEmployeesCached()
        {
            List<Employee> output;
            //Get the employees list from the cache
            output = _memoryCache.Get<List<Employee>>("employees");

            if(output is null)
            {
                output = await GetEmployeesAsync();

                //Set the cache as key value pair when the output is null and save it for 1 minute (we don't want to save data in cache forever)
                _memoryCache.Set("employees", output,TimeSpan.FromMinutes(1));
            }


            return output;
        }
    }
}
