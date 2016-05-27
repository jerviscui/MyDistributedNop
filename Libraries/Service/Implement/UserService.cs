using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Core.Domain;
using DataService.Interface;

namespace DataService.Implement
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetUserByName(string name)
        {
            return _userRepository.Table.FirstOrDefault(o => o.UserName.Equals(name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<User> GetUserByNameAsync(string name)
        {
            var user = await _userRepository.Table.FirstOrDefaultAsync(o => o.UserName.Equals(name));
            return user;
        }
    }
}
