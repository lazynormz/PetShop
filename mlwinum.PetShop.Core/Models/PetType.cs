using System;

namespace mlwinum.petshop.core.Models
{
    public class PetType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public PetType(int id, string name)
        {
            ID = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}