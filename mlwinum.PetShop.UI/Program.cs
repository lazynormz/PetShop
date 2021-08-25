using System;
using mlwinum.petshop.core.IServices;
using mlwinum.PetShop.Domain.Services;

namespace mlwinum.PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IPetService _petService = new PetService();
            Menu menu = new Menu(_petService);
        }
    }
}