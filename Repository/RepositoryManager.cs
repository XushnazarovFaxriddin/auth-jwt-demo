using Contracts;
using Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager : IRepositoryMannager
    {
        private readonly RepositoryContext _repositoryContext;
        private IUserRepository userRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
        public IUserRepository User
        {
            get
            {
                if (userRepository is null)
                    userRepository = new UserRepository(_repositoryContext);
                return userRepository;
            }
        }

        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();
    }
}
