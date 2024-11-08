using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Service
{
    internal class MovementTypeService : IDisposable
    {
        // Reference to the repository for handling data operations related to types
        private readonly MovementTypeRepository _typeRepository;

        // Constructor to initialize the type repository
        public MovementTypeService()
        {
            _typeRepository = new MovementTypeRepository(new DbConnect());
        }

        // Method to retrieve all types from the repository
        public List<MovementType> GetAllMovementTypes()
        {
            try
            {
                return _typeRepository.GatherMovementTypes();
            }
            catch (Exception ex)
            {
                // Throwing an exception with additional context if an error occurs
                throw new ApplicationException($"Error while getting all types: {ex.Message}", ex);
            }
        }

        // Method to retrieve a single type by its ID
        public MovementType GetMovementTypeById(int id)
        {
            try
            {
                return _typeRepository.GetOneMovementType(id);
            }
            catch (Exception ex)
            {
                // Throwing an exception with additional context if an error occurs
                throw new ApplicationException($"Error while getting the type with ID {id}: {ex.Message}", ex);
            }
        }

        // Method to release resources and dispose of the repository
        public void Dispose()
        {
            _typeRepository.Dispose();
        }
    }
}
