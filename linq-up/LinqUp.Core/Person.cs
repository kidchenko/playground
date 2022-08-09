using System;

namespace LinqUp
{
    public class Person
    {
        public Person(
            int reallyUniqueNumber,
            string name,
            string[] aliases,
            DateTimeOffset dateOfBirth,
            string favoriteColor)
        {
            ReallyUniqueNumber = reallyUniqueNumber;
            Name = name;
            Aliases = aliases;
            DateOfBirth = dateOfBirth;
            AgeInYears = CalculateAge(dateOfBirth, DateTimeOffset.Now);
            FavoriteColor = favoriteColor;
        }

        public int ReallyUniqueNumber { get; }
        
        public string Name { get; }

        public string[] Aliases { get; }

        public DateTimeOffset DateOfBirth { get; }

        public int AgeInYears { get; }

        public string FavoriteColor { get; }

        private int CalculateAge(DateTimeOffset dateOfBirth, DateTimeOffset now)
        {
            // Calculate the age.
            var age = now.Year - dateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            if (dateOfBirth.Date > now.AddYears(-age)) age--;
            return age;
        }
    }
}
