using System.Data.Entity;
using System.Linq;
using Core;
using Core.Domain;
using Data;
using WebServices.Interface;

namespace WebServices.Implementation
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

        public UserService()
        {
            _userRepository = new EfRepository<User>(new DataDbContext());
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUserByName(string name)
        {
            //return _userRepository.Table.Include(o => o.Roles).Include(o => o.Address)
            //    .FirstOrDefault(o => o.UserName.Equals(name));

            return _userRepository.Table.FirstOrDefault(o => o.UserName.Equals(name));
        }
    }
}
