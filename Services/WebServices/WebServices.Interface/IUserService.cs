using System.ServiceModel;
using Core.Domain;

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
        User GetUserById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [OperationContract]
        User GetUserByName(string name);
    }
}
