using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployReport
{

    public class Scheduler
    {
        public IReadOnlyList<Employee> employees;

        public Scheduler(IReadOnlyList<Employee> employees)
        {
            this.employees = employees;
        }

        public Employees GetWorkShift(
            WorkshiftOptions options)
        {
            return options
                .Query(new Employees(employees));
        }
	}
}
