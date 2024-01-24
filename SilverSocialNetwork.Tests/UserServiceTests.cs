using Moq;
using NUnit.Framework;
using SilverSocialNetwork.BLL.Models;
using SilverSocialNetwork.BLL.Services;
using SilverSocialNetwork.DAL.Entities;
using SilverSocialNetwork.DAL.Repositories;

namespace SilverSocialNetwork.Tests
{
    [TestFixture]
    public class UserServiceTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void RegisterMustReturnUserEntity() //TODO
        {
            UserEntity userEntity1 = new UserEntity()
            {
                id = 1,
                email = "ivan@mail.ru",
            };
            
            UserEntity userEntity2 = new UserEntity()
            {
                id = 1,
                email = "petr@mail.ru",
            };


            var mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(u => u.FindByEmail("ivan@mail.ru")).Returns(userEntity1);
            mockUserRepository.Setup(u => u.FindByEmail("petr@mail.ru")).Returns(userEntity2);

            var mockMessageService = new Mock<MessageService>();
           
            IEnumerable<Message> messages = new List<Message>();
            mockMessageService.Setup(m => m.GetIncomingMessagesByUserId(1)).Returns(messages);

            var userServiceTests = new UserService(mockMessageService.Object, mockUserRepository.Object);

            User user = userServiceTests.FindByEmail("ivan@mail.ru");

            Assert.AreEqual(user.Id, userEntity1.id);
        }

        [Test]
        public void RegisterMustThrowException()
        {
            var userServiceTests = new UserService();

            UserRegistrationData userRegistrationData = new UserRegistrationData()
            {
                FirstName = "",
                LastName = "Ivanov",
                Password = "01010101",
                Email = "ivan@mail.ru"
            };

            Assert.Throws<ArgumentNullException> (() =>  userServiceTests.Register(userRegistrationData));
        }
    }
}