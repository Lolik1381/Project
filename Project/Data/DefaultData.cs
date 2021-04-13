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
            createUser();
            createDirection();
        }

        public void createUser()
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
            Models.Profile profileForUser1 = new Models.Profile
            {
                name = "Example Name",
                lastName = "Example LastName",
                countPublications = 0,
                photos = new List<Models.Photo> { photo1, photo2, photo3 },
                userInfo = userInfo1
            };
            dataBase.profiles.AddRange(profileForUser1);

            // Пользователь
            Models.User user1 = new Models.User
            {
                login = "admin",
                password = "admin",
                profile = profileForUser1
            };
            dataBase.users.AddRange(user1);

            dataBase.SaveChanges();
        }

        public void createDirection()
        {
            Models.Photo photo1 = new Models.Photo { image = getByteImage(@"wwwroot\img\vail.jpg"), name = @"img\vail.jpg" };
            Models.Photo photo2 = new Models.Photo { image = getByteImage(@"wwwroot\img\caption.jpg"), name = @"img\caption.jpg" };
            Models.Photo photo3 = new Models.Photo { image = getByteImage(@"wwwroot\img\caption1.jpg"), name = @"img\caption1.jpg" };
            Models.Photo photo4 = new Models.Photo { image = getByteImage(@"wwwroot\img\caption2.jpg"), name = @"img\caption2.jpg" };
            Models.Photo photo5 = new Models.Photo { image = getByteImage(@"wwwroot\img\caption3.jpg"), name = @"img\caption3.jpg" };
            Models.Photo photo6 = new Models.Photo { image = getByteImage(@"wwwroot\img\caption4.jpg"), name = @"img\caption4.jpg" };
            Models.Photo photo7 = new Models.Photo { image = getByteImage(@"wwwroot\img\caption5.jpg"), name = @"img\caption5.jpg" };
            Models.Photo photo8 = new Models.Photo { image = getByteImage(@"wwwroot\img\caption6.jpg"), name = @"img\caption6.jpg" };
            Models.Photo photo9 = new Models.Photo { image = getByteImage(@"wwwroot\img\caption7.jpg"), name = @"img\caption7.jpg" };
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9);

            Models.Direction direction1 = new Models.Direction { mainPhoto = photo1 };
            Models.Direction direction2 = new Models.Direction { mainPhoto = photo2 };
            Models.Direction direction3 = new Models.Direction { mainPhoto = photo3 };
            Models.Direction direction4 = new Models.Direction { mainPhoto = photo4 };
            Models.Direction direction5 = new Models.Direction { mainPhoto = photo5 };
            Models.Direction direction6 = new Models.Direction { mainPhoto = photo6 };
            Models.Direction direction7 = new Models.Direction { mainPhoto = photo7 };
            Models.Direction direction8 = new Models.Direction { mainPhoto = photo8 };
            Models.Direction direction9 = new Models.Direction { mainPhoto = photo9 };
            dataBase.directions.AddRange(direction1, direction2, direction3, direction4, direction5, direction6, direction7, direction8, direction9);

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