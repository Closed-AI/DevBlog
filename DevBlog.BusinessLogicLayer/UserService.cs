using DevBlog.BusinessLogicLayer.Entities;
using DevBlog.BusinessLogicLayer.Interfaces;
using DevBlog.DataAccessLayer.Interfaces;
using DevBlog.DataAccessLayer;
using DevBlog.DataAccessLayer.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevBlog.BusinessLogicLayer
{
    public class UserService : IUserService
    {
        private IUnitOfWork database;

        public UserService()
        {
            database = new UnitOfWork();
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            List<UserDTO> result = new List<UserDTO>();

            foreach (var item in database.Users.Get())
                result.Add(mapper.Map<User, UserDTO>(item));

            return result;
        }

        public UserDTO GetUser(Guid id)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
            var user = database.Users.GetById((Guid)id);

            if (id == null || user == default)
                return null;

            return mapper.Map<User, UserDTO>(user);
        }

        public void CreateUser(UserDTO userDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            database.Users.Create(mapper.Map<UserDTO, User>(userDto));
            database.Save();
        }

        public void UpdateUser(UserDTO userDto)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<UserDTO, User>()).CreateMapper();
            var user = mapper.Map<UserDTO, User>(userDto);

            database.Users.Update(user);
            database.Save();
        }

        public void DeleteUser(UserDTO userDto)
        {
            if (userDto == null) return;
            database.Users.Delete(userDto.Id);
            database.Save();
        }

        public void Dispose()
        {
            database.Dispose();
        }
    }
}
