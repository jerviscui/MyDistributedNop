using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Domain;

namespace Service.Interface
{
    public interface IUserService
    {
        User GetUserById(int id);
    }
}
