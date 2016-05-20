using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using Data;
using Service.Interface;

namespace Service.Implement
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object"/> class.
        /// </summary>
        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
