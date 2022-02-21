using Entitys.Models.Users;
using Entitys;
using Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Contracts
{
    public interface IUserRepository
    {
        Task<User> LoginAsync(string login, string password,
            bool isDeleted, CancellationToken canselationToken = default);
    }
}
