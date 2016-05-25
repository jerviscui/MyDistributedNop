using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
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

            Console.WriteLine("get user");

            var user = _userRepository.Table.FirstOrDefault(o => o.UserName.Equals(name));

            Console.WriteLine("get user");

            if (user != null)
            {
                var serializer = new DataContractSerializer(typeof(User),
                    new DataContractSerializerSettings() { DataContractResolver = new ProxyDataContractResolver() });
                using (var stream = new MemoryStream())
                {
                    serializer.WriteObject(stream, user);
                    stream.Seek(0, SeekOrigin.Begin);
                    user = serializer.ReadObject(stream) as User;
                }
            }

            return user;
        }
    }
}
