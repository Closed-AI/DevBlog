using DevBlog.BusinessLogicLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.BusinessLogicLayer.Interfaces
{
    public interface IUserService :IDisposable
    {
        UserDTO GetUser(Guid id);

        IEnumerable<UserDTO> GetUsers();

        void CreateUser(UserDTO userDto);

        void UpdateUser(UserDTO userDto);

        void DeleteUser(UserDTO userDto);
    }
}
