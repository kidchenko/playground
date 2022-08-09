using System;

namespace EmployReport
{
	public class WorkshiftOptions
	{
		public Func<Employee, bool> Filter { get; }
		public Func<Employee, Employee> Transform { get; }
		public (AscOrDesc, Func<Employee, string>) Order { get; }

		public AscOrDesc AscOrDesc { get; set; }

		public WorkshiftOptions(
			Func<Employee, bool> filter,
			Func<Employee, Employee> transform,
			(AscOrDesc, Func<Employee, string>) order
			)
		{
			Filter = filter;
			Transform = transform;
			Order = order;
		}

		public Employees Query(Employees employees)
		{
			var result = employees
				.Filter(this)
				.Transform(this)
				.Order(this);

			return result;
		}
	}

	public class SundayWorkers : WorkshiftOptions
	{
		public SundayWorkers() : base(emp => emp.CanWorkOnSunday(), null, default) { }
	}

	public class OrderByEmployeeName : WorkshiftOptions
	{
		public OrderByEmployeeName(AscOrDesc ascOrDesc) : base(
			filter: emp => true,
			transform: null,
			order: (ascOrDesc, (emp) => emp.Name.Value))
		{
		}
	}

	public class CapitalizeName : WorkshiftOptions
	{
		public CapitalizeName() : base(emp => true, emp => emp.CapitalizeName(), default)
		{
		}
	}

	public class LowerCaseName : WorkshiftOptions
	{
		public LowerCaseName() : base(filter: emp => true, transform: emp => emp.LowerCaseName(), default)
		{
		}
	}

	public class ChangeAge : WorkshiftOptions
	{
		public ChangeAge() : base(f => true, emp => new Employee(Name.Of(emp.Name.Value), Age.Of(emp.Age.Value + 1)), default)
		{
		}
	}
}
