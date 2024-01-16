using SilverSocialNetwork.BLL.Models;
using SilverSocialNetwork.DAL.Entities;
using SilverSocialNetwork.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverSocialNetwork.BLL.Services
{
    public class UserService
    {
        IUserRepository userRepository;
        public UserService() 
        {
            userRepository = new UserRepository();
        }

        public void Register(UserRegistrationData userRegistrationData) 
        {
            if (string.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRegistrationData.Password.Length < 8) 
                throw new ArgumentOutOfRangeException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentException();

            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email,

            };

            if (this.userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

    }
}
