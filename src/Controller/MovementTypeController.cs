using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Service;

namespace Gerenciador_de_estoque.src.Controllers
{
    internal class MovementTypeController : IDisposable
    {
        // Service to handle movement type-related operations
        private readonly MovementTypeService _movementTypeService;

        // Constructor to initialize the movement type service
        public MovementTypeController()
        {
            _movementTypeService = new MovementTypeService();
        }

        // Method to retrieve all movement types from the database
        public List<MovementType> GetAllMovementTypes()
        {
            try
            {
                return _movementTypeService.GetAllMovementTypes();
            }
            catch (Exception ex)
            {
                // Throw an application exception if something goes wrong
                throw new ApplicationException($"Error retrieving all movement types: {ex.Message}", ex);
            }
        }

        // Method to retrieve a specific movement type by its ID
        public MovementType GetOneMovementType(int id)
        {
            try
            {
                return _movementTypeService.GetMovementTypeById(id);
            }
            catch (Exception ex)
            {
                // Throw an application exception if something goes wrong
                throw new ApplicationException($"Error retrieving movement type with ID {id}: {ex.Message}", ex);
            }
        }

        // Dispose method to clean up resources
        public void Dispose()
        {
            _movementTypeService.Dispose();
        }
    }
}
