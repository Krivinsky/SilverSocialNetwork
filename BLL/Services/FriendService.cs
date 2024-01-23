using SilverSocialNetwork.BLL.Models;
using SilverSocialNetwork.BLL.Exceptions;
using SilverSocialNetwork.DAL.Entities;
using SilverSocialNetwork.DAL.Repositories;

namespace SilverSocialNetwork.BLL.Services
{
    public class FriendService
    {
        FriendRepository friendRepository;

        public FriendService()
        {
            this.friendRepository = new FriendRepository();
        }

        public void AddFriend(User user, User friend)
        {
            FriendEntity friendEntity = new FriendEntity()
            {
                user_id = user.Id,
                friend_id = friend.Id
            };

            friendRepository.Create(friendEntity);
        }

        public void RemoveFriend(User user, User friend)
        {
            var allFriends = friendRepository.FindAllByUserId(user.Id);

            foreach (var friendEntity in allFriends)
            {
                 if (friendEntity.friend_id == friend.Id) 
                    friendRepository.Delete(friendEntity.id);
                 else throw new UserNotFoundException("У вас нет друга с таким почтовым адресом");
            }

        }
    }
}
