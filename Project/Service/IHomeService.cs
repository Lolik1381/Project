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
       
        public Task<List<Direction>> getDirections();
        public Task<List<Review>> getReviewsByUserId(string userId);
        public Task<User> getUserById(string id);
        public Task<Photo> getPhotoByName(string name);
        public Photo getPhotoById(int id);
        public Landmark getLandmarkByName(string name);
        public Direction getDirectionById(int id);

        public Task<List<Landmark>> getLandmarks();
        public Task<Landmark> getLandmarkById(int? id);

        public Task<List<Hotel>> getHotels();
        public Task<Hotel> getHotelById(int? id);

        public Task<List<Restaurant>> getRestaurants();
        public Task<Restaurant> getRestaurantById(int? id);

        public void changeProfile(Profile profile, Photo mainPhoto, string name, string lastName, Photo backgroundPhoto);
        public void changeUserInfo(UserInfo userInfo, string placeResidence, string personalInformation, string hrefWebSite);

        public void savePhoto(Photo photo);
        public void saveUser(User user);
    }
}
