using System;

namespace mlwinum.PetShop.Infrastructure.Data.Entities
{
    public class PetEntity
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public PetTypeEntity Type { get; set; }
        public int OwnerId { get; set; }
        public OwnerEntity Owner { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }  
    }
}