using System;
using System.Collections.Generic;

namespace LinqUp
{
    /// <summary>
    /// An arbitrary group of persons. It exposes ways to query the group for members.
    /// </summary>
    public class Group
    {
        private readonly List<Person> Members;

        /// <summary>
        /// Initializes a group with the specified members
        /// </summary>
        /// <param name="members">Collection of members of this group</param>
        public Group(IEnumerable<Person> members)
        {
            Members = new List<Person>(members);
        }

        /// <summary>
        /// Returns all members
        /// </summary>
        /// <returns>All members of the group</returns>
        public IEnumerable<Person> GetMembers()
        {
            return Members.AsReadOnly();
        }

        /// <summary>
        /// Retrieves the group member with the specified identifier
        /// </summary>
        /// <param name="uniqueIdentfier"></param>
        /// <returns>A single member</returns>
        /// <exception cref="InvalidOperationException">The specified identifier does not belong to any member or it belongs to more than than one member</exception>
        /// <exception cref="InvalidOperationException">The identifier is not unique</exception>
        public Person GetMemberById(int uniqueIdentfier)
        {
            Person? result = null;
            foreach (Person member in Members)
            {
                if (member.ReallyUniqueNumber == uniqueIdentfier)
                {
                    if (result != null)
                    {
                        throw new InvalidOperationException("Duplicate identifier in group");
                    }

                    result = member;
                }
            }

            if (result == null)
            {
                throw new InvalidOperationException("Member with specified identifier is not in group");
            }

            return result;
        }

        /// <summary>
        /// Retrieves the group member indentifier number 1 or null if they are not a member of this group
        /// </summary>
        /// <param name="uniqueIdentfier"></param>
        /// <returns>A single member</returns>
        /// <exception cref="InvalidOperationException">The specified identifier belongs to more than than one member</exception>
        public Person? GetNumberOne()
        {
            Person? result = null;
            foreach (Person member in Members)
            {
                if (member.ReallyUniqueNumber == 1)
                {
                    if (result != null)
                    {
                        throw new InvalidOperationException("Duplicate identifier in group");
                    }

                    result = member;
                }
            }

            return result;
        }

        /// <summary>
        /// Get a list of all members whose favorite color matched the specified color
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public IEnumerable<Person> GetMembersWhoLike(string color)
        {
            foreach (Person member in Members)
            {
                if (member.FavoriteColor.Equals(color, StringComparison.InvariantCultureIgnoreCase))
                {
                    yield return member;
                }
            }
        }

        /// <summary>
        /// Returns group members ordered by age
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> OrderByAge()
        {
            static int AgeComparer(Person left, Person Right)
            {
                return left.AgeInYears - Right.AgeInYears;
            }
            List<Person> copyOfMembers = new List<Person>(Members);
            copyOfMembers.Sort(AgeComparer);
            return copyOfMembers;
        }

        /// <summary>
        /// Supports pagination by returning a subset of members for a specific page.
        /// </summary>
        /// <param name="pageNumber">The page number. First result will be the page number * the number of members per page</param>
        /// <param name="numberOfMembersPerPage">The number of members to put on a page</param>
        /// <returns></returns>
        public IEnumerable<Person> GetPage(int pageNumber, int numberOfMembersPerPage = 4)
        {
            int startAt = (pageNumber - 1) * numberOfMembersPerPage;
            if (startAt > Members.Count)
            {
                yield break;
            }

            int stopAt = pageNumber * numberOfMembersPerPage;
            if (stopAt > Members.Count)
            {
                stopAt = Members.Count;
            }

            for (int i = startAt; i < stopAt; i++)
            {
                yield return Members[i];
            }
        }

        /// <summary>
        /// Adds up the ages of all members.
        /// </summary>
        /// <returns></returns>
        public int GetSummedAgeOfAllMembers()
        {
            int summedAge = 0;
            foreach (var member in Members)
            {
                summedAge += member.AgeInYears;
            }
            return summedAge;
        }

        /// <summary>
        /// Gets the youngest member of the group
        /// </summary>
        /// <returns></returns>
        public Person? GetYoungestMember()
        {
            Person? youngestMember = null;
            foreach (var member in Members)
            {
                if (youngestMember == null || member.DateOfBirth > youngestMember.DateOfBirth)
                {
                    youngestMember = member;
                }
            }
            return youngestMember;
        }

        /// <summary>
        /// Gets the oldest member of the group
        /// </summary>
        /// <returns></returns>
        public Person? GetOldestMember()
        {
            Person? oldestMember = null;
            foreach (var member in Members)
            {
                if (oldestMember == null || member.DateOfBirth < oldestMember.DateOfBirth)
                {
                    oldestMember = member;
                }
            }
            return oldestMember;
        }

        /// <summary>
        /// Returns all ages that are represented in the group with the number of members in the group that have that age.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(int age, int numberOfMembers)> GetNumberOfMembersWithAge()
        {
            List<(int age, int numberOfMembers)> result = new List<(int age, int numberOfMembers)>();
            foreach (var member in Members)
            {
                // Check if age alread exists in the result=                
                (int age, int numberOfMembers)? existingGroup = null;
                for (int i = 0; i < result.Count; i++)
                {
                    if (member.AgeInYears == result[i].age)
                    {
                        existingGroup = result[i];
                        
                    }
                }

                // Get the number of members with the same age so far
                int currentMembersWithSameAge = 0;
                if (existingGroup.HasValue)
                {
                    currentMembersWithSameAge = existingGroup.Value.numberOfMembers;
                    result.Remove(existingGroup.Value);
                }
                
                result.Add((age: member.AgeInYears, numberOfMembers: currentMembersWithSameAge + 1));
            }
            return result;
        }

        /// <summary>
        /// Returns a dictionary keyed by favorite colors containing the members who have that favorite color
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, List<Person>> GetMembersByFavoriteColor()
        {
            var result = new Dictionary<string, List<Person>>();
            foreach (var member in Members)
            {
                if (result.ContainsKey(member.FavoriteColor))
                {
                    result[member.FavoriteColor].Add(member);
                }
                else
                {
                    result.Add(member.FavoriteColor, new List<Person> { member });
                }
            }
            return result;
        }

        /// <summary>
        /// Gets all the names and aliases that belong to members in this group.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetAllNamesAndAliases()
        {
            List<string> names = new List<string>();
            foreach (var member in Members)
            {
                names.Add(member.Name);
                names.AddRange(member.Aliases);
            }
            return names;
        }
    }
}