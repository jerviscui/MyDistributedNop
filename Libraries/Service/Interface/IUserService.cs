﻿using Core.Domain;

namespace DataService.Interface
{
    public interface IUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetUserById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User GetUserByName(string name);
    }
}
