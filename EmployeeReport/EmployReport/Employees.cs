using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployReport
{
	public class Employees
	{
		private IReadOnlyList<Employee> employeesList { get; }

		public Employees(IReadOnlyList<Employee> employeesList)
		{
			this.employeesList = employeesList;
		}

		public Employees Filter(WorkshiftOptions workshiftOptions)
		{
			return new Employees(
				workshiftOptions.Filter != null ?
					employeesList.Where(workshiftOptions.Filter).ToList() :
					employeesList
				);
		}

		public Employees Transform(WorkshiftOptions workshiftOptions)
		{
			return new Employees(
				workshiftOptions.Transform != null ?
				employeesList.Select(workshiftOptions.Transform).ToList() :
				employeesList
			);
		}

		public Employees Order(WorkshiftOptions workshiftOptions)
		{
			return workshiftOptions.Order != default ?
				OrderBy(workshiftOptions) :
				new Employees(employeesList);
		}

		private Employees OrderBy(WorkshiftOptions workshiftOptions)
		{
			var order = workshiftOptions.Order;
			var ascOrDesc = order.Item1;
			var predicate = order.Item2;

			return new Employees(ascOrDesc == AscOrDesc.Asc ?
				employeesList.OrderBy(predicate).ToList() :
				employeesList.OrderByDescending(predicate).ToList()
			);
		}

		public IReadOnlyList<Employee> ToList()
		{
			return employeesList.ToList();
		}
	}
}
