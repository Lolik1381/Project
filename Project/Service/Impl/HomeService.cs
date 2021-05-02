using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Data;
using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Service.Impl
{
    public class HomeService : IHomeService
    {
        private ApplicationContext applicationContext;

        public HomeService(ApplicationContext applicationContext)
        {
            this.applicationContext = applicationContext;
        }

        public User getUserById(int id)
        {
            return applicationContext.users
                .Include(user => user.profile)
                    .ThenInclude(profile => profile.mainPhoto)
                .Include(user => user.profile)
                    .ThenInclude(profile => profile.userInfo)
                .Include(user => user.profile)
                    .ThenInclude(profile => profile.backgroundPhoto)
                .Where(user => user.id == id)
                .Single();
        }

        public Photo getPhotoByName(string name)
        {
            return applicationContext.photos
                .Where(photo => photo.name.Equals(name))
                .FirstOrDefault();
        }

        public User getUserByLoginAndPassword(string login, string password)
        {
            return applicationContext.users
                .Include(user => user.profile)
                    .ThenInclude(profile => profile.mainPhoto)
                .Include(user => user.profile)
                    .ThenInclude(profile => profile.userInfo)
                .Where(user => user.login.Equals(login) && user.password.Equals(password))
                .FirstOrDefault();
        }

        public List<Direction> getDirections()
        {
            return applicationContext.directions
                 .Include(direction => direction.mainPhoto)
                 .Include(direction => direction.photos)

                 .Include(direction => direction.landmarks)
                    .ThenInclude(landmark => landmark.reviews)

                 .Include(direction => direction.hotels)
                    .ThenInclude(hotels => hotels.reviews)

                 .Include(direction => direction.restaurants)
                    .ThenInclude(restaurants => restaurants.reviews)
                 .ToList();
        }

        public void startMigrationData()
        {
            if (DefaultSettings.isFirstData)
            {
                new DefaultData(applicationContext).createDefaultData();
            }
        }

        public void savePhoto(Photo photo)
        {
            applicationContext.photos.Add(photo);
            applicationContext.SaveChanges();
        }

        public void changeProfile(Profile profile, Photo mainPhoto, string name, string lastName, Photo backgroundPhoto)
        {
            profile.mainPhoto = mainPhoto != null ? mainPhoto : profile.mainPhoto;
            profile.name = name != null ? name : profile.name;
            profile.lastName = lastName != null ? lastName : profile.lastName;
            profile.backgroundPhoto = backgroundPhoto != null ? backgroundPhoto : profile.backgroundPhoto;
            applicationContext.SaveChanges();
        }

        public void changeUserInfo(UserInfo userInfo, string placeResidence, string personalInformation, string hrefWebSite)
        {
            userInfo.placeResidence = placeResidence != null ? placeResidence : userInfo.placeResidence;
            userInfo.personalInformation = personalInformation != null ? personalInformation : userInfo.personalInformation;
            userInfo.hrefWebSite = hrefWebSite != null ? hrefWebSite : userInfo.hrefWebSite;
            applicationContext.SaveChanges();
        }

        public List<Review> getReviewsByUserId(int userId)
        {
            return applicationContext.reviews
                 .Include(review => review.user)
                    .ThenInclude(user => user.profile)
                        .ThenInclude(profile => profile.mainPhoto)
                 .Include(review => review.user)
                    .ThenInclude(user => user.profile)
                        .ThenInclude(profile => profile.userInfo)
                 .Include(review => review.photos)
                 .Where(review => review.user.id == userId)
                 .ToList();
        }

        public Photo getPhotoById(int id)
        {
            return applicationContext.photos
                .Where(photo => photo.id == id)
                .FirstOrDefault();
        }

        public void saveUser(User user)
        {
            applicationContext.users.Add(user);
            applicationContext.SaveChanges();
        }

        public User getUserByLogin(string login)
        {
            return applicationContext.users
               .Include(user => user.profile)
                   .ThenInclude(profile => profile.mainPhoto)
               .Include(user => user.profile)
                   .ThenInclude(profile => profile.userInfo)
               .Where(user => user.login.Equals(login))
               .FirstOrDefault();
        }

        public Landmark getLandmarkByName(string name)
        {
            return applicationContext.landmarks
                .Include(landmark => landmark.photos)
                .Include(landmark => landmark.reviews)
                .Where(l => l.name.Equals(name))
                .FirstOrDefault();
        }

        public Direction getDirectionById(int id)
        {
            Direction direction = applicationContext.directions
                .Include(direction => direction.mainPhoto)
                .Include(direction => direction.photos)

                .Include(direction => direction.landmarks)
                    .ThenInclude(landmark => landmark.photos)
                .Include(direction => direction.landmarks)
                    .ThenInclude(hotel => hotel.mainPhoto)
                .Include(direction => direction.landmarks)
                    .ThenInclude(landmark => landmark.reviews)

                .Include(direction => direction.hotels)
                    .ThenInclude(landmark => landmark.photos)
                .Include(direction => direction.hotels)
                    .ThenInclude(hotel => hotel.mainPhoto)
                .Include(direction => direction.hotels)
                    .ThenInclude(hotel => hotel.reviews)

                .Include(direction => direction.restaurants)
                    .ThenInclude(landmark => landmark.photos)
                .Include(direction => direction.restaurants)
                    .ThenInclude(restaurant => restaurant.mainPhoto)
                .Include(direction => direction.restaurants)
                    .ThenInclude(restaurant => restaurant.reviews)

                .Where(d => d.id == id)
                .FirstOrDefault();
            
            if (direction != null)
            {
                foreach (var landmarks in direction.landmarks)
                {
                    landmarks.rating = landmarks.reviews.Count > 0
                        ? landmarks.reviews.Sum(review => review.rating) / landmarks.reviews.Count
                        : 0;
                }

                foreach (var hotel in direction.hotels)
                {
                    hotel.rating = hotel.reviews.Count > 0
                        ? hotel.reviews.Sum(review => review.rating) / hotel.reviews.Count
                        : 0;
                }

                foreach (var restaurants in direction.restaurants)
                {
                    restaurants.rating = restaurants.reviews.Count > 0
                        ? restaurants.reviews.Sum(review => review.rating) / restaurants.reviews.Count
                        : 0;
                }
            }

            return direction;
        }

        public Hotel getHotelById(int? id)
        {
            Hotel hotel = applicationContext.hotels
                 .Include(hotel => hotel.mainPhoto)
                 .Include(hotel => hotel.reviews)
                 .Where(hotel => hotel.id == id)
                 .FirstOrDefault();

            if (hotel != null)
            {
                hotel.rating = hotel.reviews.Count > 0
                    ? hotel.reviews.Sum(review => review.rating) / hotel.reviews.Count
                    : 0;
            }

            return hotel;
        }

        public Landmark getLandmarkById(int? id)
        {
            Landmark landmark = applicationContext.landmarks
                 .Include(landmark => landmark.mainPhoto)
                 .Include(landmark => landmark.reviews)
                 .Where(landmark => landmark.id == id)
                 .FirstOrDefault();

            if (landmark != null)
            {
                landmark.rating = landmark.reviews.Count > 0
                    ? landmark.reviews.Sum(review => review.rating) / landmark.reviews.Count
                    : 0;
            }

            return landmark;
        }

        public Restaurant getRestaurantById(int? id)
        {
            Restaurant restaurant = applicationContext.restaurants
                 .Include(restaurant => restaurant.mainPhoto)
                 .Include(restaurant => restaurant.reviews)
                 .Where(restaurant => restaurant.id == id)
                 .FirstOrDefault();

            if (restaurant != null)
            {
                restaurant.rating = restaurant.reviews.Count > 0
                    ? restaurant.reviews.Sum(review => review.rating) / restaurant.reviews.Count
                    : 0;
            }

            return restaurant;
        }
    }
}