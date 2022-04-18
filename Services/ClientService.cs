using CSharpFunctionalExtensions;
using System;
using VegaIT.Timesheet.Core.Entities;
using VegaIT.Timesheet.Core.Repositories;

namespace VegaIT.Timesheet.Core.Services
{
    public class ClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        public Result CreateNew(Client client)
        {
            var maybeClient = _clientRepository.FindByNameOrId(client);
            if (maybeClient.HasValue) return Result.Failure("Client with same name or id already exists");

            _clientRepository.Add(client);
            return Result.Success();
        }

        public Result Remove(Guid clientId)
        {
            var maybeClient = _clientRepository.FindById(clientId);
            if (maybeClient.HasNoValue) return Result.Failure("Client with provided id doesn't exist");

            _clientRepository.Remove(clientId);
            return Result.Success();
        }

        public Result Update(Client client)
        {
            var maybeClient = _clientRepository.FindById(client.Id);
            if (maybeClient.HasNoValue) return Result.Failure("Client with provided id doesn't exist");

            _clientRepository.Update(client);
            return Result.Success();
        }
    }
}