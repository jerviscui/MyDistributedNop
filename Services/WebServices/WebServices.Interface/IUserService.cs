using System.ServiceModel;
using System.Threading.Tasks;
using Core.Domain;
using ServiceFramework;

namespace WebServices.Interface
{
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        [ApplyProxyDataContractResolver]
        
        User GetUserById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract]
        [ApplyProxyDataContractResolver]
        User GetUserByName(string name);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract(Name = "GetUserByNameAsync")]
        [ApplyProxyDataContractResolver]
        Task<User> GetUserByNameAsync(string name);
    }
}
