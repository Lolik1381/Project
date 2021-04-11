using Project.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Data
{
    public class DefaultData
    {
        ApplicationContext dataBase;

        public DefaultData(ApplicationContext applicationContext)
        {
            this.dataBase = applicationContext;
        }

        public void createDefaultData()
        {
            // Фотографии
            Models.Photo photo1 = new Models.Photo { image = getByteImage(@"wwwroot\img\vail.jpg"), name = "vail.jpg" };
            Models.Photo photo2 = new Models.Photo { image = getByteImage(@"wwwroot\img\vail.jpg"), name = "vail.jpg" };
            Models.Photo photo3 = new Models.Photo { image = getByteImage(@"wwwroot\img\vail.jpg"), name = "vail.jpg" };
            dataBase.photos.AddRange(photo1);

            // Информация о пользователе
            Models.UserInfo userInfo1 = new Models.UserInfo { city = "Москва", country = "Россия", create = DateTime.Today };
            dataBase.userInfos.AddRange(userInfo1);

            // Профиль пользователя
            Models.Profile profileForUser1 = new Models.Profile { 
                name = "Example Name", 
                lastName = "Example LastName",
                countPublications = 0, 
                photos = new List<Models.Photo> { photo1, photo2, photo3 }, 
                userInfo = userInfo1 
            };
            dataBase.profiles.AddRange(profileForUser1);

            // Пользователь
            Models.User user1 = new Models.User { 
                login = "admin", 
                password = "admin",
                profile = profileForUser1
            };
            dataBase.users.AddRange(user1);

            dataBase.SaveChanges();
        }

        private byte[] getByteImage(string filePath)
        {
            byte[] imageData;

            using(FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                imageData = new byte[fileStream.Length];
                fileStream.Read(imageData, 0, imageData.Length);
            }
            return imageData;
        }

        //private void savePhotoOfByte(string name, byte[] data) 
        //{
        //    using (FileStream fileStream = new FileStream(name, FileMode.OpenOrCreate))
        //    {
        //        fileStream.Write(data, 0, data.Length);
        //    }
        //}
    }
}