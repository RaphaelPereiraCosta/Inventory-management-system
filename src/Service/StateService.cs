using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Connection;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Repositories;

namespace Gerenciador_de_estoque.src.Service
{
    internal class StateService : IDisposable
    {
        // Reference to the repository for handling data operations related to states
        private readonly StateRepository _stateRepository;

        // Constructor to initialize the state repository
        public StateService()
        {
            _stateRepository = new StateRepository(new DbConnect());
        }

        // Method to retrieve all states from the repository
        public List<State> GetAllStates()
        {
            try
            {
                return _stateRepository.GatherStates();
            }
            catch (Exception ex)
            {
                // Throwing an exception with additional context if an error occurs
                throw new ApplicationException($"Error while getting all states: {ex.Message}", ex);
            }
        }

        // Method to retrieve a single state by its ID
        public State GetStateById(int id)
        {
            try
            {
                return _stateRepository.GetOneState(id);
            }
            catch (Exception ex)
            {
                // Throwing an exception with additional context if an error occurs
                throw new ApplicationException($"Error while getting the state with ID {id}: {ex.Message}", ex);
            }
        }

        // Method to release resources and dispose of the repository
        public void Dispose()
        {
            _stateRepository.Dispose();
        }
    }
}
