using System;

namespace mlwinum.petshop.core.Models
{
    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public PetType Type { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }

        public Pet(int id, string name, PetType type, DateTime birthDate, DateTime soldDate, string colour,
            double price)
        {
            ID = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type;
            BirthDate = birthDate;
            SoldDate = soldDate;
            Colour = colour ?? throw new ArgumentNullException(nameof(colour));
            Price = price;
        }
    }
}