using SilverSocialNetwork.BLL.Exceptions;
using SilverSocialNetwork.BLL.Models;
using SilverSocialNetwork.BLL.Services;
using SilverSocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilverSocialNetwork.PLL.Views
{
    public class FriendView
    {
        FriendService friendService;
        UserService userService;

        public FriendView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public  void Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Что вы хотите сделать добавить друзей или удалить друзей?");
                Console.WriteLine("Добавить друзей (нажмите 1)");
                Console.WriteLine("Удалить друзей (нажмите 2)");
                Console.WriteLine("Выйти из меню (нажмите 0)");
                string keyValue = Console.ReadLine();

                if (keyValue == "0") break;

                switch (keyValue)
                {
                    case "1":
                        {
                            Console.WriteLine("Для добавления пользователя в друзья введите его почтовый адрес.");
                            string friendEmail = Console.ReadLine();

                            try
                            {
                                var findUser = userService.FindByEmail(friendEmail);
                                friendService.AddFriend(user, findUser);
                                SuccessMessage.Show($"Вы добавили в друзья - {findUser.FirstName} {findUser.LastName}");
                            }
                            catch (UserNotFoundException)
                            {
                                AlertMessage.Show("Пользователь с таким почтовым адресом не найден");
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Для удаления пользователя из друзей введите его почтовый адрес.");
                            string friendEmail = Console.ReadLine();

                            try
                            {
                                var findUser = userService.FindByEmail(friendEmail);
                                friendService.RemoveFriend(user, findUser);
                                SuccessMessage.Show($"Вы удалили из друзей - {findUser.FirstName} {findUser.LastName}");
                            }
                            catch(UserNotFoundException)
                            {
                                AlertMessage.Show("У вас нет друга с таким почтовым адресом не найден");
                            }
                            break;
                        }
                }



                


            }
        }
    }
}
