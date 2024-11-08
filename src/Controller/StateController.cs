using System;
using System.Collections.Generic;
using Gerenciador_de_estoque.src.Models;
using Gerenciador_de_estoque.src.Service;

namespace Gerenciador_de_estoque.src.Controllers
{
    internal class StateController : IDisposable
    {
        // Service to handle state-related operations
        private readonly StateService _stateService;

        // Constructor to initialize the state service
        public StateController()
        {
            _stateService = new StateService();
        }

        // Method to retrieve all states from the database
        public List<State> GetAllStates()
        {
            try
            {
                return _stateService.GetAllStates();
            }
            catch (Exception ex)
            {
                // Throw an application exception if something goes wrong
                throw new ApplicationException($"Error retrieving all states: {ex.Message}", ex);
            }
        }

        // Method to retrieve a specific state by its ID
        public State GetStateById(int id)
        {
            try
            {
                return _stateService.GetStateById(id);
            }
            catch (Exception ex)
            {
                // Throw an application exception if something goes wrong
                throw new ApplicationException($"Error retrieving state with ID {id}: {ex.Message}", ex);
            }
        }

        // Dispose method to clean up resources
        public void Dispose()
        {
            _stateService.Dispose();
        }
    }
}
