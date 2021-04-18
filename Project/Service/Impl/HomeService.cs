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
    }
}