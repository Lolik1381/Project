using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service
{
    public interface IHomeService
    {
        public void startMigrationData();
       
        public List<Direction> getDirections();
        public List<Review> getReviewsByUserId(int userId);
        public User getUserByLoginAndPassword(string login, string password);
        public User getUserByLogin(string login);
        public User getUserById(int id);
        public Photo getPhotoByName(string name);
        public Photo getPhotoById(int id);
        public Landmark getLandmarkById(int? id);
        public Landmark getLandmarkByName(string name);
        public Direction getDirectionById(int id);
        public Hotel getHotelById(int? id);
        public Restaurant getRestaurantById(int? id);

        public void changeProfile(Profile profile, Photo mainPhoto, string name, string lastName, Photo backgroundPhoto);
        public void changeUserInfo(UserInfo userInfo, string placeResidence, string personalInformation, string hrefWebSite);

        public void savePhoto(Photo photo);
        public void saveUser(User user);
    }
}
