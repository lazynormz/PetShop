using System;
using mlwinum.petshop.core.IServices;
using mlwinum.PetShop.Domain.IRepositories;
using mlwinum.PetShop.Domain.Services;
using mlwinum.PetShop.Infrastructure.Data;

namespace mlwinum.PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            PetRepository _petRepository = new PetRepository();
            _petRepository.InitData();
            
            IPetService _petService = new PetService(_petRepository);
            Menu menu = new Menu(_petService);
            menu.PrintAllPets();
        }
    }
}