using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TupleAndCollections
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var invalidBookings = new[] { 1, 2, 3 };

            var validBookings = new[] { 1, 4, 5 };

            var result = validBookings.Except(invalidBookings);

            Assert.Equal(new[] { 4, 5 }, result);
        }

		[Fact]
		public void Test2()
		{
            var juca = "";
            string juca2 = null;
            (string, string) nullTuple = (null, null);
            Assert.Equal(nullTuple, (juca, juca2));
		}

        [Fact]
        public void Test3()
        {
            var externalNote = string.Empty;
            var licence = "";
            var abngst = "";

			
            if (licence is string juca)
			{
                externalNote += juca;
            }

            if (!string.IsNullOrEmpty(abngst))
            {
				externalNote += $"<ABN></ABN>";
            }

            Assert.Equal("", externalNote);
        }

		[Fact]
		public async Task TestAsyncCalls()
		{
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            var firstCall = GetCountries();
            var secondCall = GetStates();

            var combinedTask = await Task.WhenAll(firstCall, secondCall);

            var first = combinedTask.First();
            var second = combinedTask.First();

			watch.Stop();

            var elapsedTime = watch.ElapsedMilliseconds;
            Console.WriteLine($"Execution Time: {elapsedTime} ms");
            Assert.True(elapsedTime < 7000);
        }

		public async Task<string> GetCountries()
		{
            await Task.Delay(TimeSpan.FromSeconds(5));
            return string.Empty;
        }

        public async Task<string> GetStates()
		{
            await Task.Delay(TimeSpan.FromSeconds(5));
            return string.Empty;

            var juca = await Juca();



        }


		public Task<dynamic> Juca()
		{
            dynamic juca = new { };
            return Task.FromResult(juca);
		}

		public void PatternMatching()
		{
            var juca = (true, true);

			switch (juca)
			{
				case			
				default:
					break;
			}
		}
    }
}
