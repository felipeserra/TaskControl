using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task.Domain.Core;
using Task.Domain.Interfaces.Repositories.User;
using Task.Domain.Models.Interfaces.Service;
using TaskControl.Domain.Commands.User;

namespace Task.DomainService.User
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserWriteRepository _userWriteRepository;
        private readonly IUserReadRepository _userReadRepository;

        public UserDomainService(IUserWriteRepository userWriteRepository, IUserReadRepository userReadRepository)
        {
            _userWriteRepository = userWriteRepository;
            _userReadRepository = userReadRepository;
        }

        public async Task<EntityResult<Domain.Models.Entity.User>> Create(RegisterUserCommand command)
        {
            var result = Domain.Models.Entity.User.TryCreateToInsert(command.Name, command.Email, command.Password);

            if (result.Valid)
                await _userWriteRepository.Add(result.Entity);

            return result;
        }        

        public async Task<EntityResult<Domain.Models.Entity.User>> Update(UpdateUserCommand command)
        {
            var result = 
                Domain.Models.Entity.User.TryCreateToUpdate(command.Id, command.Name, command.Email, command.Password);

            if (result.Valid)
                await _userWriteRepository.Update(result.Entity);

            return result;
        }

        public async System.Threading.Tasks.Task Remove(RemoveUserCommand command)
            => await _userWriteRepository.Delete(command.Id);


        public async Task<IEnumerable<Domain.Models.Entity.User>> GetAll()
            => await _userReadRepository.GetAll();

        public async Task<Domain.Models.Entity.User> GetById(Guid id)
            => await _userReadRepository.GetById(id);

        public async Task<EntityResult<Domain.Models.Entity.User>> Login(string email, string password)
        {
            var userToLogin = await _userReadRepository.GetByEmail(email);

            if (userToLogin == null || !userToLogin.Password.Equals(password))
                return EntityResult<Domain.Models.Entity.User>.CreateNotification(new Flunt.Notifications.Notification("User", "Usuário não localizado"));

            return EntityResult<Domain.Models.Entity.User>.ValidateAndReturn(userToLogin);
        }
    }
}