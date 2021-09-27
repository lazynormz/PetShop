using System;

namespace mlwinum.PetShop.WebApi.DTO
{
    public class PetDTO
    {
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public int OwnerId { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Colour { get; set; }
        public double Price { get; set; }
    }
}