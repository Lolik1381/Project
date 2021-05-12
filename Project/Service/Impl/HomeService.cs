using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Data;
using Project.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Service.Impl
{
    public class HomeService : IHomeService
    {
        private ApplicationContext applicationContext;
        private UserManager<User> userManager;

        public HomeService(ApplicationContext applicationContext, UserManager<User> userManager)
        {
            this.applicationContext = applicationContext;
            this.userManager = userManager;
        }

        public void startMigrationData()
        {
            if (DefaultSettings.isFirstData)
            {
                new DefaultData(applicationContext, userManager).createDefaultData();
            }
        }

        public async Task<User> getUserById(string id)
        {
            return await applicationContext.users
                .Include(user => user.profile)
                    .ThenInclude(profile => profile.mainPhoto)
                .Include(user => user.profile)
                    .ThenInclude(profile => profile.userInfo)
                .Include(user => user.profile)
                    .ThenInclude(profile => profile.backgroundPhoto)
                .Where(user => user.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Photo> getPhotoByName(string name)
        {
            return await applicationContext.photos
                .Where(photo => photo.name.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<List<Direction>> getDirections()
        {
            return await applicationContext.directions
                 .Include(direction => direction.mainPhoto)
                 .Include(direction => direction.photos)

                 .Include(direction => direction.landmarks)
                    .ThenInclude(landmark => landmark.reviews)

                 .Include(direction => direction.hotels)
                    .ThenInclude(hotels => hotels.reviews)

                 .Include(direction => direction.restaurants)
                    .ThenInclude(restaurants => restaurants.reviews)
                 .ToListAsync();
        }

        public async Task savePhoto(Photo photo)
        {
            await applicationContext.photos.AddAsync(photo);
            await applicationContext.SaveChangesAsync();
        }

        public async Task changeProfile(Profile profile, Photo mainPhoto, string name, string lastName, Photo backgroundPhoto)
        {
            profile.mainPhoto = mainPhoto != null ? mainPhoto : profile.mainPhoto;
            profile.name = name != null ? name : profile.name;
            profile.lastName = lastName != null ? lastName : profile.lastName;
            profile.backgroundPhoto = backgroundPhoto != null ? backgroundPhoto : profile.backgroundPhoto;
            await applicationContext.SaveChangesAsync();
        }

        public async Task changeUserInfo(UserInfo userInfo, string placeResidence, string personalInformation, string hrefWebSite)
        {
            userInfo.placeResidence = placeResidence != null ? placeResidence : userInfo.placeResidence;
            userInfo.personalInformation = personalInformation != null ? personalInformation : userInfo.personalInformation;
            userInfo.hrefWebSite = hrefWebSite != null ? hrefWebSite : userInfo.hrefWebSite;
            await applicationContext.SaveChangesAsync();
        }

        public async Task<List<Review>> getReviewsByUserId(string userId)
        {
            return await applicationContext.reviews
                 .Include(review => review.user)
                    .ThenInclude(user => user.profile)
                        .ThenInclude(profile => profile.mainPhoto)
                 .Include(review => review.user)
                    .ThenInclude(user => user.profile)
                        .ThenInclude(profile => profile.userInfo)
                 .Include(review => review.photos)
                 .Where(review => review.user.Id == userId)
                 .ToListAsync();
        }

        public async Task<Photo> getPhotoById(int id)
        {
            return await applicationContext.photos
                .Where(photo => photo.id == id)
                .FirstOrDefaultAsync();
        }

        public async Task saveUser(User user)
        {
            await applicationContext.users.AddAsync(user);
            await applicationContext.SaveChangesAsync();
        }

        public async Task<Landmark> getLandmarkByName(string name)
        {
            return await applicationContext.landmarks
                .Include(landmark => landmark.photos)
                .Include(landmark => landmark.reviews)
                .Where(l => l.name.Equals(name))
                .FirstOrDefaultAsync();
        }

        public async Task<Direction> getDirectionById(int id)
        {
            Direction direction = await applicationContext.directions
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
                .FirstOrDefaultAsync();
            
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

        public async Task<Hotel> getHotelById(int? id)
        {
            Hotel hotel = await applicationContext.hotels
                 .Include(hotel => hotel.mainPhoto)

                 .Include(hotel => hotel.reviews)
                    .ThenInclude(review => review.user)
                        .ThenInclude(user => user.profile)
                            .ThenInclude(profile => profile.mainPhoto)
                 .Include(hotel => hotel.reviews)
                    .ThenInclude(review => review.photos)

                 .Include(hotel => hotel.roomEquipment)
                    .ThenInclude(roomEquipment => roomEquipment.photo)
                 .Include(hotel => hotel.roomType)
                    .ThenInclude(roomType => roomType.photo)
                 .Include(hotel => hotel.services)
                    .ThenInclude(services => services.photo)

                 .Include(hotel => hotel.photos)
                 .Where(hotel => hotel.id == id)
                 .FirstOrDefaultAsync();

            if (hotel != null)
            {
                hotel.rating = hotel.reviews.Count > 0
                    ? hotel.reviews.Sum(review => review.rating) / hotel.reviews.Count
                    : 0;
            }

            return hotel;
        }

        public async Task<Landmark> getLandmarkById(int? id)
        {
            Landmark landmark = await applicationContext.landmarks
                 .Include(landmark => landmark.mainPhoto)

                 .Include(landmark => landmark.reviews)
                    .ThenInclude(review => review.user)
                        .ThenInclude(user => user.profile)
                            .ThenInclude(profile => profile.mainPhoto)
                 .Include(landmark => landmark.reviews)
                    .ThenInclude(review => review.photos)

                 .Include(landmark => landmark.photos)
                 .Where(landmark => landmark.id == id)
                 .FirstOrDefaultAsync();

            if (landmark != null)
            {
                landmark.rating = landmark.reviews.Count > 0
                    ? landmark.reviews.Sum(review => review.rating) / landmark.reviews.Count
                    : 0;
            }

            return landmark;
        }

        public async Task<Restaurant> getRestaurantById(int? id)
        {
            Restaurant restaurant = await applicationContext.restaurants
                 .Include(restaurant => restaurant.mainPhoto)

                 .Include(hotel => hotel.reviews)
                    .ThenInclude(review => review.user)
                        .ThenInclude(user => user.profile)
                            .ThenInclude(profile => profile.mainPhoto)
                 .Include(landmark => landmark.reviews)
                    .ThenInclude(review => review.photos)

                 .Include(restaurant => restaurant.photos)
                 .Where(restaurant => restaurant.id == id)
                 .FirstOrDefaultAsync();

            if (restaurant != null)
            {
                restaurant.rating = restaurant.reviews.Count > 0
                    ? restaurant.reviews.Sum(review => review.rating) / restaurant.reviews.Count
                    : 0;
            }

            return restaurant;
        }

        public async Task<List<Landmark>> getLandmarks()
        {
            return await applicationContext.landmarks
                .Include(landmark => landmark.mainPhoto)
                .ToListAsync();
        }

        public async Task<List<Hotel>> getHotels()
        {
            return await applicationContext.hotels
                .Include(hotel => hotel.mainPhoto)
                .ToListAsync();
        }

        public async Task<List<Restaurant>> getRestaurants()
        {
            return await applicationContext.restaurants
                .Include(restaurant => restaurant.mainPhoto)
                .ToListAsync();
        }

        public async Task savePhotos(List<Photo> photos)
        {
            await applicationContext.photos.AddRangeAsync(photos);
            await applicationContext.SaveChangesAsync();
        }

        public async Task saveReview(Review review)
        {
            await applicationContext.reviews.AddAsync(review);
            await applicationContext.SaveChangesAsync();
        }

        public async Task saveChanges()
        {
            await applicationContext.SaveChangesAsync();
        }

        public async Task changeHotelReview(Hotel hotel, Review review)
        {
            hotel.reviews.Add(review);
            await applicationContext.SaveChangesAsync();
        }

        public async Task changeLandmarkReview(Landmark landmark, Review review)
        {
            landmark.reviews.Add(review);
            await applicationContext.SaveChangesAsync();
        }

        public async Task changeRestaurantReview(Restaurant restaurant, Review review)
        {
            restaurant.reviews.Add(review);
            await applicationContext.SaveChangesAsync();
        }

        public async Task changeHotelPhoto(Hotel hotel, List<Photo> photos)
        {
            hotel.photos.AddRange(photos);
            await applicationContext.SaveChangesAsync();
        }

        public async Task changeLandmarkPhoto(Landmark landmark, List<Photo> photos)
        {
            landmark.photos.AddRange(photos);
            await applicationContext.SaveChangesAsync();
        }

        public async Task changeRestaurantPhoto(Restaurant restaurant, List<Photo> photos)
        {
            restaurant.photos.AddRange(photos);
            await applicationContext.SaveChangesAsync();
        }
    }
}