using System;
using mlwinum.petshop.core.IServices;
using mlwinum.PetShop.Domain.IRepositories;
using mlwinum.PetShop.Domain.Services;
using mlwinum.PetShop.Infrastructure.Data;
using mlwinum.PetShop.Infrastructure.Data.Repositories;

namespace mlwinum.PetShop.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();
        }
    }
}