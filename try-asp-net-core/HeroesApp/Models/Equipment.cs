using System.Collections.Generic;

namespace HeroesApp.Models
{
    public class Equipment
    {
        private static IList<Equipment> _equipments = new List<Equipment>();

        public string Name { get; set; }

        public static Equipment Create(string name)
        {
            var equipment = new Equipment();
            equipment.Name = name;
            _equipments.Add(equipment);
            return equipment;
        }

        public static IList<Equipment> GetAll()
        {
            return _equipments;
        }
    }
}