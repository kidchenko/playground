using LinqUp;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqUpTests
{
    public class GroupTest
    {
        private List<Person> TestPersons = new List<Person> {
            new Person(1, "Chip", new string[] { "Pringle" }, new DateTimeOffset(DateTimeOffset.Now.Year - 40, 01, 01, 0, 0, 0, TimeSpan.Zero), "Blue"),
            new Person(2, "Chuck", new string[] { "Lays" }, new DateTimeOffset(DateTimeOffset.Now.Year - 14, 01, 01, 0, 0, 0, TimeSpan.Zero), "Red"),
        };

        #region Tests for GetMembers
        [Fact]
        public void ReturnsAllMembers()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var members = group.GetMembers();

            Assert.Equal(2, members.Count());
            Assert.Collection(members,
                item => Assert.Equal(TestPersons[0], item),
                item => Assert.Equal(TestPersons[1], item));
        }
        #endregion Tests for GetMembers

        #region Test for GetMemberById

        [Fact]
        public void GivenAnExistingIdReturnsMatchingMember()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var member = group.GetMemberById(TestPersons[1].ReallyUniqueNumber);

            Assert.Equal(TestPersons[1], member);
        }

        [Fact]
        public void GivenAnUnknownIdThrowsException()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var exception = Assert.Throws<InvalidOperationException>(() => group.GetMemberById(129340129));

            Assert.Equal("Member with specified identifier is not in group", exception.Message);
        }

        [Fact]
        public void GivenAnDuplicateIdThrowsException()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[0] });

            var exception = Assert.Throws<InvalidOperationException>(() => group.GetMemberById(TestPersons[0].ReallyUniqueNumber));

            Assert.Equal("Duplicate identifier in group", exception.Message);
        }

        #endregion Test for GetMemberById
    
        #region Tests for GetNumberOne

        [Fact]
        public void GivenMemberWithNumber1ExistsReturnsMatchingMember()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var member = group.GetNumberOne();

            Assert.NotNull(member);
            Assert.Equal(TestPersons[0], member);
        }

        [Fact]
        public void GivenMemberWithNumber1DoesNotExistsReturnsMatchingMember()
        {
            var group = new Group(new List<Person> { TestPersons[1] });

            var member = group.GetNumberOne();

            Assert.Null(member);
        }

        #endregion Tests for GetNumberOne

        #region Tests for MembersWhoLike

        [Fact]
        public void GivenFavoriteColorReturnsMatchingMember()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var members = group.GetMembersWhoLike("Blue");

            Assert.Collection(members,
                item => Assert.Equal(TestPersons[0], item));
        }        

        #endregion Tests for MembersWhoLike

        #region Tests for OrderByAge

        [Fact]
        public void GivenUnorderedMembersReturnsOrdered()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var members = group.OrderByAge();

            Assert.Collection(members,
                item => Assert.Equal(TestPersons[1], item),
                item => Assert.Equal(TestPersons[0], item));
        }

        [Fact]
        public void GivenOrderedMembersReturnsOrdered()
        {
            var group = new Group(new List<Person> { TestPersons[1], TestPersons[0] });

            var members = group.OrderByAge();

            Assert.Collection(members,
                item => Assert.Equal(TestPersons[1], item),
                item => Assert.Equal(TestPersons[0], item));
        }   

        #endregion Tests for OrderByAge

        #region Tests for GetPage

        [Fact]
        public void GivenPage1ReturnsFirstFourMembers()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[0], TestPersons[0], TestPersons[0], TestPersons[1], TestPersons[1] });

            var members = group.GetPage(1);

            Assert.Collection(members,
                item => Assert.Equal(TestPersons[0], item),
                item => Assert.Equal(TestPersons[0], item),
                item => Assert.Equal(TestPersons[0], item),
                item => Assert.Equal(TestPersons[0], item));
        }

        [Fact]
        public void GivenPage2ReturnsLastTwoMembers()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[0], TestPersons[0], TestPersons[0], TestPersons[1], TestPersons[1] });

            var members = group.GetPage(2);

            Assert.Collection(members,
                item => Assert.Equal(TestPersons[1], item),
                item => Assert.Equal(TestPersons[1], item));
        }    

        #endregion Tests for GetPage

        #region Tests for GetSummedAgeOfAllMembers

        [Fact]
        public void GivenMembersReturnsSummedAge()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var totalAge = group.GetSummedAgeOfAllMembers();

            Assert.Equal(54, totalAge);
        }

        #endregion Tests for GetSummedAgeOfAllMembers

        #region Tests for GetYoungestMember

        [Fact]
        public void GivenMembersReturnsYoungestMember()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var member = group.GetYoungestMember();

            Assert.Equal(member, TestPersons[1]);
        }

        #endregion Tests for GetYoungestMember

        #region Tests for GetOldestMember

        [Fact]
        public void GivenMembersReturnsYOldestMember()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var member = group.GetOldestMember();

            Assert.Equal(member, TestPersons[0]);
        }

        #endregion Tests for GetOldestMember

        #region Tests for GetNumberOfMembersWithAge

        [Fact]
        public void GivenMembersReturnsNumberOfMembersForEachAge()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[0], TestPersons[0], TestPersons[0], TestPersons[1], TestPersons[1] });

            var membersWithAge = group.GetNumberOfMembersWithAge();

            Assert.Collection(membersWithAge,
                item => Assert.Equal((age: 40, numberOfMembers: 4), item),
                item => Assert.Equal((age: 14, numberOfMembers: 2), item));
        }    

        #endregion Tests for GetNumberOfMembersWithAge

        #region Tests for GetMembersByFavoriteColor

        [Fact]
        public void GivenMembersReturnsMembersGroupedByFavoriteColor()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[0], TestPersons[0], TestPersons[0], TestPersons[1], TestPersons[1] });

            var members = group.GetMembersByFavoriteColor();

            Assert.Collection(members,
                item => 
                {
                    Assert.Equal("Blue", item.Key);
                    Assert.Collection(item.Value,
                        item => Assert.Equal(TestPersons[0], item),
                        item => Assert.Equal(TestPersons[0], item),
                        item => Assert.Equal(TestPersons[0], item),
                        item => Assert.Equal(TestPersons[0], item));
                },
                item => 
                {
                    Assert.Equal("Red", item.Key);
                    Assert.Collection(item.Value,
                        item => Assert.Equal(TestPersons[1], item),
                        item => Assert.Equal(TestPersons[1], item));
                });
        }    

        #endregion Tests for GetMembersByFavoriteColor

        #region Tests for GetAllNamesAndAliases

        [Fact]
        public void GivenMembersReturnsAllNamesAndAliases()
        {
            var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });

            var names = group.GetAllNamesAndAliases();

            Assert.Collection(names,
                item => Assert.Equal(TestPersons[0].Name, item),
                item => Assert.Equal(TestPersons[0].Aliases[0], item),
                item => Assert.Equal(TestPersons[1].Name, item),
                item => Assert.Equal(TestPersons[1].Aliases[0], item));
        }

        #endregion Tests for GetAllNamesAndAliases

        #region Tests for GetGroupAgeMultiplied

        [Fact]
        public void GivenMultiplyAgeOfMembers()
        {
			var group = new Group(new List<Person> { TestPersons[0], TestPersons[1] });
			var multiply = group.GetGroupAgeMultiplied();

            Assert.Equal(TestPersons[0].AgeInYears * TestPersons[1].AgeInYears, multiply);
		}

        #endregion Tests for GetGroupAgeMultiplied


    }
}
