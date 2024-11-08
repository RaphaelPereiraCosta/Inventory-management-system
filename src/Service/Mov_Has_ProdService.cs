using System;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Repository;

namespace Gerenciador_de_estoque.src.Services
{
    internal class Mov_Has_ProdService
    {
        // Reference to the repository for handling data operations
        private readonly Mov_Has_ProdRepository _repository;

        // Constructor to initialize the repository
        public Mov_Has_ProdService()
        {
            _repository = new Mov_Has_ProdRepository(new DbConnect());
        }

        // Method to add a movement of product to the database
        public void AddMov_has_Prod(int idMovement, int idProduct, int movedAmount)
        {
            try
            {
                // Calls the repository method to add the movement
                _repository.AddMov_has_Prod(idMovement, idProduct, movedAmount);
                Console.WriteLine("Product movement successfully added.");
            }
            catch (Exception ex)
            {
                // Displays an error message if something goes wrong in the service layer
                Console.WriteLine(
                    $"Error adding product movement in the service layer: {ex.Message}"
                );
            }
        }
    }
}
