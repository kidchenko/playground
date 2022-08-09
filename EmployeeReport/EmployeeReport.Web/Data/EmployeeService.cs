using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeReport.Web.Data
{
    public class EmployeeService
    {
        public Task<EmployeeViewModel[]> GetForecastAsync()
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new EmployeeViewModel
            {
                Name = "Juca",
                Age = 18
            }).ToArray());
        }
    }
}
