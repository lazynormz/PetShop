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

        public Pet(){}
        public Pet(string name, PetType type, DateTime birthDate, DateTime soldDate, string colour,
            double price)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Type = type ?? throw new ArgumentNullException(nameof(type));
            BirthDate = birthDate;
            SoldDate = soldDate;
            Colour = colour ?? throw new ArgumentNullException(nameof(colour));
            Price = price;
        }
    }
}