using System.Threading.Tasks;
using Task.Domain.Core;
using TaskControl.Domain.Commands.User;

namespace Task.Domain.Models.Interfaces.Service
{
    public interface IUserDomainService :
        TaskControl.Domain.Interfaces.Service.Core.IRegisterDomainService<Entity.User, RegisterUserCommand>,
        TaskControl.Domain.Interfaces.Service.Core.IUpdateDomainService<Entity.User, UpdateUserCommand>,
        TaskControl.Domain.Interfaces.Service.Core.IRemoveDomainService<RemoveUserCommand>,
        Core.IReadDomainService<Entity.User>
    {
        Task<EntityResult<Entity.User>> Login(string email, string password);
    }
}