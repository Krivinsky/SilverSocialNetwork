using SilverSocialNetwork.BLL.Models;
using SilverSocialNetwork.BLL.Services;

namespace SilverSocialNetwork
{
    internal class Program
    {
        public static UserService userService = new UserService();
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t**** Welcome to SilverSocialNetwork *****");
            //Console.WriteLine("для выхода вв");
            while (true)
            {
                Console.WriteLine("Для регистрации введите имя пользователя:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Фамилию");
                string lastName = Console.ReadLine();

                Console.WriteLine("почтовый адрес");
                string email = Console.ReadLine();

                Console.WriteLine("пароль");
                string password = Console.ReadLine();

                UserRegistrationData userRegistrationData = new UserRegistrationData()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Password = password,
                    Email = email
                };

                try
                {
                    userService.Register(userRegistrationData);
                    Console.WriteLine("Регистраци произошла успешно ");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine("Поля не могут быть пустыми");
                    Console.WriteLine(ex.ToString);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Введено не корректное значение");
                    Console.WriteLine(ex.ToString);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Произошла ошибка при регистрации");
                    Console.WriteLine(ex.ToString);
                }

            }
            Console.ReadLine();
        }
    }
}
