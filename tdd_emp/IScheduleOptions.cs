namespace tdd_emp
{
    public interface IScheduleOptions
    {
		public bool OrderByDesc { get; }

		public bool WorkOnSunday {get;}

		public bool CapitalizeResult {get;}

    }

    public class ScheduleOptions : IScheduleOptions
    {
		public static ScheduleOptions Default = new ScheduleOptions(false, true);

		public static ScheduleOptions CanWorkOnSunday = new ScheduleOptions(true, true);

		public static ScheduleOptions CapitalizeSearch = new ScheduleOptions(false, false, true);


		private ScheduleOptions(bool workOnSunday, bool orderByDesc, bool capitalize = false)
		{
			this.workOnSunday = workOnSunday;
			this.orderByDesc = orderByDesc;
			this.capitalizeResult = capitalize;
		}

        private bool orderByDesc;

		private bool workOnSunday;

		private bool capitalizeResult;

        public bool OrderByDesc => this.orderByDesc;

        public bool WorkOnSunday => this.workOnSunday;

        public bool CapitalizeResult => this.capitalizeResult;
    }
}
