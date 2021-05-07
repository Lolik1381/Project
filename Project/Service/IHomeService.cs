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
        public Task<Photo> getPhotoById(int id);

        public Task<Landmark> getLandmarkByName(string name);
        public Task<Direction> getDirectionById(int id);

        public Task<List<Landmark>> getLandmarks();
        public Task<Landmark> getLandmarkById(int? id);

        public Task<List<Hotel>> getHotels();
        public Task<Hotel> getHotelById(int? id);

        public Task<List<Restaurant>> getRestaurants();
        public Task<Restaurant> getRestaurantById(int? id);

        public Task changeProfile(Profile profile, Photo mainPhoto, string name, string lastName, Photo backgroundPhoto);
        public Task changeUserInfo(UserInfo userInfo, string placeResidence, string personalInformation, string hrefWebSite);

        public Task changeHotelReview(Hotel hotel, Review review);
        public Task changeHotelPhoto(Hotel hotel, List<Photo> photos);

        public Task changeLandmarkReview(Landmark landmark, Review review);
        public Task changeLandmarkPhoto(Landmark landmark, List<Photo> photos);

        public Task changeRestaurantReview(Restaurant restaurant, Review review);
        public Task changeRestaurantPhoto(Restaurant restaurant, List<Photo> photos);

        public Task savePhoto(Photo photo);
        public Task savePhotos(List<Photo> photos);
        public Task saveReview(Review review);
        public Task saveUser(User user);

        public Task saveChanges();
    }
}
