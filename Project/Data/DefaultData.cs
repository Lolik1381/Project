using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Context;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Data
{
    public class DefaultData
    {
        ApplicationContext dataBase;
        UserManager<User> userManager;

        public DefaultData(ApplicationContext applicationContext, UserManager<User> userManager)
        {
            this.dataBase = applicationContext;
            this.userManager = userManager;
        }

        public void createDefaultData()
        {
            createPhoto();
            createUser();
            createReview();
            createLandmark();
            createHotel();
            createRestaurant();
            createDirection();
        }

        public void createPhoto()
        {
            Photo photo1 = new Photo { image = Util.getByteImage(@"wwwroot\img\white.jpg"), name = "white.jpg" };

            Photo photo2 = new Photo { image = Util.getByteImage(@"wwwroot\img\sliderLeft.png"), name = "sliderLeft.jpg" };
            Photo photo3 = new Photo { image = Util.getByteImage(@"wwwroot\img\sliderRight.png"), name = "sliderRight.jpg" };

            dataBase.photos.AddRange(photo1, photo2, photo3);
            dataBase.SaveChanges();
        }

        public void createUser()
        {
            #region userinfo
            UserInfo userInfo1 = new UserInfo { placeResidence = "Москва, Россия", create = DateTime.Today };
            UserInfo userInfo2 = new UserInfo { placeResidence = "Пенза, Россия", create = DateTime.Today };
            UserInfo userInfo3 = new UserInfo { placeResidence = "Уфа, Россия", create = DateTime.Today };
            UserInfo userInfo4 = new UserInfo { placeResidence = "Минск, Белоруссия", create = DateTime.Today };
            UserInfo userInfo5 = new UserInfo { placeResidence = "Бостон, Массачусетс", create = DateTime.Today };
            UserInfo userInfo6 = new UserInfo { placeResidence = "Katy, Техас", create = DateTime.Today };
            dataBase.userInfos.AddRange(userInfo1, userInfo2, userInfo3, userInfo4, userInfo5, userInfo6);
            #endregion

            #region photo
            Photo photo1 = new Photo { image = Util.getByteImage(@"wwwroot\img\user1.jpg"), name = @"img\user1.jpg" };
            Photo photo2 = new Photo { image = Util.getByteImage(@"wwwroot\img\user2.jpg"), name = @"img\user2.jpg" };
            Photo photo3 = new Photo { image = Util.getByteImage(@"wwwroot\img\user3.jpg"), name = @"img\user3.jpg" };
            Photo photo4 = new Photo { image = Util.getByteImage(@"wwwroot\img\user4.jpg"), name = @"img\user4.jpg" };
            Photo photo5 = new Photo { image = Util.getByteImage(@"wwwroot\img\user5.jpg"), name = @"img\user5.jpg" };
            Photo photo6 = new Photo { image = Util.getByteImage(@"wwwroot\img\user6.jpg"), name = @"img\user6.jpg" };
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6);
            #endregion

            #region profile
            Profile profileForUser1 = new Profile
            {
                name = "Юлия",
                lastName = "Раджабова",
                mainPhoto = photo1,
                userInfo = userInfo1,
            };
            Profile profileForUser2 = new Profile
            {
                name = "Станислав",
                lastName = "Лычагин",
                mainPhoto = photo2,
                userInfo = userInfo2,
            };
            Profile profileForUser3 = new Profile
            {
                name = "Русаков",
                lastName = "Никита",
                mainPhoto = photo3,
                userInfo = userInfo3,
            };
            Profile profileForUser4 = new Profile
            {
                name = "Михаил",
                lastName = "Поляков",
                mainPhoto = photo4,
                userInfo = userInfo4,
            };
            Profile profileForUser5 = new Profile
            {
                name = "Anastasia",
                lastName = "Sya",
                mainPhoto = photo5,
                userInfo = userInfo5,
            };
            Profile profileForUser6 = new Profile
            {
                name = "Denis",
                lastName = "Kotov",
                mainPhoto = photo6,
                userInfo = userInfo6,
            };

            dataBase.profiles.AddRange(profileForUser1, profileForUser2, profileForUser3, profileForUser4, profileForUser5, profileForUser6);
            dataBase.SaveChanges();
            #endregion

            #region user
            User user1 = new User { 
                profile = profileForUser1, 
                Email = "example1@example.com", 
                UserName = "example1@example.com"
            };
            User user2 = new User
            {
                profile = profileForUser2,
                Email = "example2@example.com",
                UserName = "example2@example.com"
            };
            User user3 = new User
            {
                profile = profileForUser3,
                Email = "example3@example.com",
                UserName = "example3@example.com"
            };
            User user4 = new User
            {
                profile = profileForUser4,
                Email = "example4@example.com",
                UserName = "example4@example.com"
            };
            User user5 = new User
            {
                profile = profileForUser5,
                Email = "example5@example.com",
                UserName = "example5@example.com"
            };
            User user6 = new User
            {
                profile = profileForUser6,
                Email = "example6@example.com",
                UserName = "example6@example.com"
            };

            List<IdentityResult> result = new List<IdentityResult>();
            result.Add(userManager.CreateAsync(user1, "flluMv%40Q3V").Result);
            result.Add(userManager.CreateAsync(user2, "flluMv%40Q3V").Result);
            result.Add(userManager.CreateAsync(user3, "flluMv%40Q3V").Result);
            result.Add(userManager.CreateAsync(user4, "flluMv%40Q3V").Result);
            result.Add(userManager.CreateAsync(user5, "flluMv%40Q3V").Result);
            result.Add(userManager.CreateAsync(user6, "flluMv%40Q3V").Result);
            result.ForEach(error =>
            {
                if (!error.Succeeded)
                {
                    throw new Exception("Не удалось сохранить пользователя!");
                }
            });

            #endregion
        }

        public void createReview()
        {
            #region reviewForLandmark1
            #endregion

            #region reviewForLandmark2
            #endregion

            #region reviewForLandmark3
            Review review3 = new Review
            {
                user = dataBase.users
                    .Include(user => user.profile)
                    .Where(user => user.profile.name.Equals("Станислав"))
                    .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "После Оаху и карибов дорога не впечатлила.",
                rating = 3,
                description = "Ездили вдвоем на спорт машине, Камаро СС без крыши. Дорога началась с трафика что мы в принципе и ожидали. Остановки делали постоянно, но все как то не окупалось такой дорогой и цены которые они просили за свои услуги и виды. Да, есть маленькие водопадики, обросшие гавайскими цветами и джунгли, отличные фиш тако продавались по дороге и кстати очень не дорого, неплохие сады за которые просили 15$ с человека,- нас после Оаху эти сады не зашли совсем, но Оаху были круче сады и бесплатно с дорогами на водопады. В совокупности для нас все это показалось очень накручено, да и вообще остров Мау,очень накрученные в интернете, пляжи хорошие, но на Арубе лучше, джунгли есть, но в Мексике круче, да и на соседнем Оуаху и Куаи есть места получше. Две горы с затухшими вулканами тоже мех...нам очень понравился остров Оаху, и пляжи лучше и горы красивее, не даров Аватар и Парк Юрского периода снимали не на Мауи, а на Оаху."
            };
            #endregion

            #region reviewForLandmark4
            Review review1 = new Review
            {
                user = dataBase.users
                    .Include(user => user.profile)
                    .Where(user => user.profile.name.Equals("Станислав"))
                    .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Красивое место",
                rating = 5,
                description = "Конечно специально не станешь лететь ради этого места в Доминикану. Но если есть возможность его посетить, то не упустите)"
            };
            #endregion

            #region reviewForLandmark5
            #endregion

            #region reviewForLandmark6
            #endregion

            #region reviewForLandmark7
            #endregion

            #region reviewForLandmark8
            #endregion

            #region reviewForLandmark9
            #endregion

            #region reviewForLandmark10
            #endregion

            #region reviewForLandmark11
            #endregion

            #region reviewForLandmark12
            Review review2 = new Review
            {
                user = dataBase.users
                    .Include(user => user.profile)
                    .Where(user => user.profile.name.Equals("Станислав"))
                    .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Лучше билет am/pm.",
                rating = 4.6M,
                description = "Взял билет на 86 (открытый балкон) и на 102 (закрытый) за $80. На 102 делать особо нечего, кроме фото без ограждений сзади. Потом вечером взял только на открытый на 86 этаже за $47. Лучше брать сразу билет am/pm. Для двух посещений."
            };
            #endregion

            dataBase.reviews.AddRange(review1, review2, review3);
            dataBase.SaveChanges();
        }

        public void createLandmark()
        {
            #region photo
            Photo photo1 = new Photo { image = Util.getByteImage(@"wwwroot\img\Upper_Geyser_Basin.jpg"), name = @"img\Upper_Geyser_Basin.jpg" };
            Photo photo2 = new Photo { image = Util.getByteImage(@"wwwroot\img\Upper_Geyser_Basin_1.jpg"), name = @"img\Upper_Geyser_Basin_1.jpg" };
            Photo photo3 = new Photo { image = Util.getByteImage(@"wwwroot\img\big_prisma.jpg"), name = @"img\big_prisma.jpg" };
            Photo photo4 = new Photo { image = Util.getByteImage(@"wwwroot\img\azul.jpg"), name = @"img\azul.jpg" };
            Photo photo5 = new Photo { image = Util.getByteImage(@"wwwroot\img\azul_1.jpg"), name = @"img\azul_1.jpg" };
            Photo photo6 = new Photo { image = Util.getByteImage(@"wwwroot\img\hana.jpg"), name = @"img\hana.jpg" };
            Photo photo7 = new Photo { image = Util.getByteImage(@"wwwroot\img\magic-kingdom.jpg"), name = @"img\magic-kingdom.jpg" };
            Photo photo8 = new Photo { image = Util.getByteImage(@"wwwroot\img\universal.jpg"), name = @"img\universal.jpg" };
            Photo photo9 = new Photo { image = Util.getByteImage(@"wwwroot\img\universal_1.jpg"), name = @"img\universal_1.jpg" };
            Photo photo10 = new Photo { image = Util.getByteImage(@"wwwroot\img\soldiers-pass.jpg"), name = @"img\soldiers-pass.jpg" };
            Photo photo11 = new Photo { image = Util.getByteImage(@"wwwroot\img\bridge-trail.jpg"), name = @"img\punta-kana.jpg" };
            Photo photo12 = new Photo { image = Util.getByteImage(@"wwwroot\img\maya-museum.jpg"), name = @"img\maya-museum.jpg" };
            Photo photo13 = new Photo { image = Util.getByteImage(@"wwwroot\img\El-Rey.jpg"), name = @"img\El-Rey.jpg" };
            Photo photo14 = new Photo { image = Util.getByteImage(@"wwwroot\img\El-Rey_1.jpg"), name = @"img\El-Rey_1.jpg" };
            Photo photo15 = new Photo { image = Util.getByteImage(@"wwwroot\img\playa-delfines.jpg"), name = @"img\playa-delfines.jpg" };
            Photo photo16 = new Photo { image = Util.getByteImage(@"wwwroot\img\empire-state-building.jpg"), name = @"img\empire-state-building.jpg" };
            Photo photo17 = new Photo { image = Util.getByteImage(@"wwwroot\img\Brooklyn-bridge.jpg"), name = @"img\Brooklyn-bridge.jpg" };
            Photo photo18 = new Photo { image = Util.getByteImage(@"wwwroot\img\central-park.jpg"), name = @"img\central-park.jpg" };
            Photo photo19 = new Photo { image = Util.getByteImage(@"wwwroot\img\Strip.jpg"), name = @"img\Strip.jpg" };
            Photo photo20 = new Photo { image = Util.getByteImage(@"wwwroot\img\Nevada_garden.jpg"), name = @"img\Nevada_garden.jpg" };
            Photo photo21 = new Photo { image = Util.getByteImage(@"wwwroot\img\Nevada_garden_1.jpg"), name = @"img\Nevada_garden_1.jpg" };
            Photo photo22 = new Photo { image = Util.getByteImage(@"wwwroot\img\tower-of-London.jpg"), name = @"img\tower-of-London.jpg" };
            Photo photo23 = new Photo { image = Util.getByteImage(@"wwwroot\img\tower-of-London_1.jpg"), name = @"img\tower-of-London_1.jpg" };
            Photo photo24 = new Photo { image = Util.getByteImage(@"wwwroot\img\British-museum.jpg"), name = @"img\British-museum.jpg" };
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12, photo13, photo14, photo15, photo16, photo17, photo18, photo19, photo20, photo21, photo22, photo23, photo24);
            #endregion

            #region landmarkForDirection1
            Landmark landmark1 = new Landmark
            {
                name = "Upper Geyser Basin",
                rating = 5,
                mainPhoto = photo1,
                photos = new List<Photo> { photo2 },
            };
            Landmark landmark2 = new Landmark
            {
                name = "Большой призматический источник",
                rating = 4.9M,
                mainPhoto = photo3
            };
            #endregion

            #region landmarkForDirection2
            Landmark landmark3 = new Landmark
            {
                name = "Лагуна Азул",
                rating = 4.7M,
                mainPhoto = photo5,
                photos = new List<Photo> { photo4 },
                reviews = new List<Review>
                {
                    dataBase.reviews.Where(review => review.header.Equals("После Оаху и карибов дорога не впечатлила.")).Single()
                }
            };
            #endregion

            #region landmarkForDirection3
            Landmark landmark4 = new Landmark
            {
                name = "Hana Highway - Road to Hana",
                rating = 4.5M,
                mainPhoto = photo6,
                reviews = new List<Review>
                {
                    dataBase.reviews.Where(review => review.header.Equals("Красивое место")).Single()
                }
            };
            #endregion

            #region landmarkForDirection4
            Landmark landmark5 = new Landmark
            {
                name = "Magic Kingdom",
                rating = 4.3M,
                mainPhoto = photo7
            };
            Landmark landmark6 = new Landmark
            {
                name = "Universal Studios Florida",
                rating = 4.4M,
                mainPhoto = photo8,
                photos = new List<Photo> { photo9 },
            };
            #endregion

            #region landmarkForDirection5
            Landmark landmark7 = new Landmark
            {
                name = "Soldier Pass",
                rating = 4.4M,
                mainPhoto = photo10
            };
            Landmark landmark8 = new Landmark
            {
                name = "Devil's Bridge Trail",
                rating = 4,
                mainPhoto = photo11
            };
            #endregion

            #region landmarkForDirection6
            Landmark landmark9 = new Landmark
            {
                name = "Mayan Museum of Cancun",
                rating = 4.2M,
                mainPhoto = photo12
            };
            Landmark landmark10 = new Landmark
            {
                name = "Руины Эль-Рей",
                rating = 4,
                mainPhoto = photo13,
                photos = new List<Photo> { photo14 }
            };
            Landmark landmark11 = new Landmark
            {
                name = "Пляж Playa Delfines",
                rating = 4.4M,
                mainPhoto = photo15
            };
            #endregion

            #region landmarkForDirection7
            Landmark landmark12 = new Landmark
            {
                name = "Empire state building",
                rating = 3.9M,
                mainPhoto = photo16,
                reviews = new List<Review>
                {
                    dataBase.reviews.Where(review => review.header.Equals("Лучше билет am/pm.")).Single()
                }
            };
            Landmark landmark13 = new Landmark
            {
                name = "Бруклинский мост",
                rating = 4.3M,
                mainPhoto = photo17
            };
            Landmark landmark14 = new Landmark
            {
                name = "Центральный парк",
                rating = 4.4M,
                mainPhoto = photo18
            };
            #endregion

            #region landmarkForDirection8
            Landmark landmark15 = new Landmark
            {
                name = "The Strip",
                rating = 4.2M,
                mainPhoto = photo19
            };
            Landmark landmark16 = new Landmark
            {
                name = "Bellagio Conservatory & Botanical Garden",
                rating = 4.3M,
                mainPhoto = photo20,
                photos = new List<Photo> { photo21 }
            };
            #endregion

            #region landmarkForDirection9
            Landmark landmark17 = new Landmark
            {
                name = "Лондонский Тауэр",
                rating = 4.4M,
                mainPhoto = photo22,
                photos = new List<Photo> { photo23, photo1, photo10, photo11, photo13, photo14 },
            };
            Landmark landmark18 = new Landmark
            {
                name = "Британский музей",
                rating = 4.5M,
                mainPhoto = photo24
            };
            #endregion

            dataBase.landmarks.AddRange(landmark1, landmark2, landmark3, landmark4, landmark5, landmark6, landmark7, landmark8, landmark9, landmark10, landmark11, landmark12, landmark13, landmark14, landmark15, landmark16, landmark17, landmark18);
            dataBase.SaveChanges();

            // Привязка review к landmark
            dataBase.reviews.Where(review => review.header.Equals("Красивое место")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("Hana Highway - Road to Hana")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Лучше билет am/pm.")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("Empire state building")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("После Оаху и карибов дорога не впечатлила.")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("Лагуна Азул")).Select(landmark => landmark.id).Single();
        }

        public void createDirection()
        {
            #region photo
            Photo photo1 = new Photo { image = Util.getByteImage(@"wwwroot\img\yellowstone-national.jpg"), name = @"img\yellowstone-national.jpg" };
            Photo photo2 = new Photo { image = Util.getByteImage(@"wwwroot\img\punta-kana.jpg"), name = @"img\punta-kana.jpg" };
            Photo photo3 = new Photo { image = Util.getByteImage(@"wwwroot\img\mauyi.jpg"), name = @"img\mauyi.jpg" };
            Photo photo4 = new Photo { image = Util.getByteImage(@"wwwroot\img\orlando.jpg"), name = @"img\orlando.jpg" };
            Photo photo5 = new Photo { image = Util.getByteImage(@"wwwroot\img\sedona.jpg"), name = @"img\sedona.jpg" };
            Photo photo6 = new Photo { image = Util.getByteImage(@"wwwroot\img\kankun.jpg"), name = @"img\kankun.jpg" };
            Photo photo7 = new Photo { image = Util.getByteImage(@"wwwroot\img\new-york.jpg"), name = @"img\new-york.jpg" };
            Photo photo8 = new Photo { image = Util.getByteImage(@"wwwroot\img\las-vegas.jpg"), name = @"img\las-vegas.jpg" };
            Photo photo9 = new Photo { image = Util.getByteImage(@"wwwroot\img\london.jpg"), name = @"img\london.jpg" };

            Photo photo11 = new Photo { image = Util.getByteImage(@"wwwroot\img\yellowstone-national.jpg"), name = @"img\yellowstone-national.jpg" };
            Photo photo12 = new Photo { image = Util.getByteImage(@"wwwroot\img\punta-kana.jpg"), name = @"img\punta-kana.jpg" };
            Photo photo13 = new Photo { image = Util.getByteImage(@"wwwroot\img\mauyi.jpg"), name = @"img\mauyi.jpg" };
            Photo photo14 = new Photo { image = Util.getByteImage(@"wwwroot\img\orlando.jpg"), name = @"img\orlando.jpg" };
            Photo photo15 = new Photo { image = Util.getByteImage(@"wwwroot\img\sedona.jpg"), name = @"img\sedona.jpg" };
            Photo photo16 = new Photo { image = Util.getByteImage(@"wwwroot\img\kankun.jpg"), name = @"img\kankun.jpg" };
            Photo photo17 = new Photo { image = Util.getByteImage(@"wwwroot\img\new-york.jpg"), name = @"img\new-york.jpg" };
            Photo photo18 = new Photo { image = Util.getByteImage(@"wwwroot\img\las-vegas.jpg"), name = @"img\las-vegas.jpg" };
            Photo photo19 = new Photo { image = Util.getByteImage(@"wwwroot\img\london.jpg"), name = @"img\london.jpg" };
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9);
            #endregion

            Direction direction1 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Upper Geyser Basin")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Большой призматический источник")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Old Faithful Inn")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Roosevelt Lodge Cabins")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Madison Campground")).Single()
                },
                photos = new List<Photo> { photo11 },
                mainPhoto = photo1, 
                name = "Йеллоустонский национальный парк, Вайоминг",
                shortDescription = "Йеллоустонский национальный парк: обзор", 
                description = "Йеллоустоунский национальный парк, созданный в 1872 году, является подлинным национальным достоянием. Основная част парка расположена в Вайоминге, но частично парк также расположен в штатах Монтана и Айдахо. В Йеллоустоуне велика геотермальная активность; по всему парку можно найти гейзеры и бурлящие грязевые бассейны. Самым известным гейзером является Верный старик (Old Faithful): уже много лет его извержения происходят строго по часам. Путешественникам следует знать, что июль в Йеллоустоуне – месяц максимальной туристической активности. В этот период парк посещает около миллиона туристов. В парке существует система туристических автобусов, девять гостевых центров и 2 000 лагерей."
            };
            Direction direction2 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Лагуна Азул")).Single()
                },
                photos = new List<Photo> { photo12 },
                mainPhoto = photo2,
                name = "Пунта-Кана, Доминикана",
                shortDescription = "Прекрасные пляжи и расслабляющий отдых со всеми удобствами лишь часть очарования Пунта-Каны.",
                description = "Пунта-Кана — это потрясающее место и настоящий источник самых разных удовольствий. Вы можете начать свой день на будто сошедшем с открыток пляже Макао, а закончить в ночном клубе в пещере. А когда Вы не нежитесь на солнце и не танцуете всю ночь напролет, каждую минуту Вас ждут другие развлечения, которые предлагают безупречные курорты Пунта-Каны, работающие по системе все включено, от потрясающего Hard Rock Punta Cana до безмятежного и уединенного Le Sivory Punta Cana. Насладившись теплым солнцем и белоснежным песком, попробуйте один из местных маршрутов канатного спуска, отправьтесь на остров Саона, познакомьтесь с историей Доминиканы в Альтос-де-Чавоне и посетите волшебные лагуны экологического парка Indigenous Eyes.",
            
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Sanctuary Cap Cana")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Zoetry Agua Punta Cana")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Excellence Punta Cana")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Royalton Punta Cana Resort & Casino")).Single()
                }
            };
            Direction direction3 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Hana Highway - Road to Hana")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Hotel Wailea")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Hana-Maui Resort")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Andaz Maui At Wailea Resort")).Single()
                },
                photos = new List<Photo> { photo13 },
                mainPhoto = photo3,
                name = "Остров Мауи, Гавайи", 
                shortDescription = "Радушный оазис для любителей природы, пляжи которого — воплощенная мечта",
                description = "Суровые вулканические пейзажи, изумрудные долины и пляжи с черным песком — Мауи воистину привносит драматический эффект. Конечно, здесь хватает курортов и отелей, однако Мауи не теряет своей самобытности в угоду туризму. Напротив, он остается верен живописной природе, гавайской культуре и духу Алоха. А вид на восход солнца с вершины вулкана Халеакала или поездка по шоссе Хана даже самого искушенного путешественника заставят подумать, что он попал в рай."
            };
            Direction direction4 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Magic Kingdom")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Universal Studios Florida")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Disney's Animal Kingdom Lodge")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Hilton Orlando Bonnet Creek")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Alfond Inn")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Four Seasons Resort Orlando at Walt Disney World Resort")).Single()
                },
                photos = new List<Photo> { photo14 },
                mainPhoto = photo4, 
                name = "Орландо, Флорида",
                shortDescription = "Мечтаете побывать в волшебном мире Диснея? Вы найдете его в Орландо. Но возможности для семейного отдыха и развлечений на этом не заканчиваются.",
                description = "Орландо — город, полный чудес. Все они начинаются в Волшебном королевстве Диснея, но здесь есть и другие места, полные магического очарования. Те, кто молод, и те, кто молод душой, могут творить заклинания в Волшебном мире Гарри Поттера от Universal Studios или воплотить свои мечты о сафари в Царстве животных Диснея. И это только для начала. Насытившись острыми ощущениями, отправляйтесь насладиться потрясающей живой музыкой в таких заведениях, как B.B. King’s House of Blues, или изысканной кухней в одном из местных ресторанов, количество которых постоянно растет. А если захотите отдохнуть от переполняющих эмоций, здесь есть такие идиллические места, как ландшафтно-парковый комплекс Harry P. Leu Gardens, полный столь необходимыми Вам тишиной и покоем."
            };
            Direction direction5 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Soldier Pass")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Devil's Bridge Trail")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("El Portal Sedona Hotel")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("L'Auberge de Sedona")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Enchantment Resort")).Single()                },
                photos = new List<Photo> { photo15 },
                mainPhoto = photo5, 
                name = "Седона, Аризона",
                shortDescription = "Страна красных скал",
                description = "Седона — настоящий оазис посреди Аризонской пустыни, отрада глаз для отдыхающих. Здесь есть все, что только можно пожелать: курорты, спа, каньоны, красные скалы. Скала Белл-Рок и каньон Оак Крик — отличные места для хайкинга, а архитектура церкви Святого Креста сама по себе достойна восхищения. После заката начинается самое ценное представление, которое может предложить Седона: открывается вид на ночное небо."
            };
            Direction direction6 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Mayan Museum of Cancun")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Руины Эль-Рей")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Пляж Playa Delfines")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("NIZUC Resort and Spa")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Hyatt Zilara Cancun")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Le Blanc Spa Resort Cancun")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Secrets Playa Mujeres Golf & Spa Resort")).Single()
                },
                restaurants = new List<Restaurant>
                {
                    dataBase.restaurants.Where(r => r.name.Equals("Lorenzillo's")).Single()
                },
                photos = new List<Photo> { photo16 },
                mainPhoto = photo6, 
                name = "Канкун, Мексика",
                shortDescription = "Конечно, море, солнце и глоток текилы по-прежнему воплощают душу Канкуна, но у него есть и более мягкая сторона.",
                description = "Когда-то изречение Вечная весна было неофициальным девизом Канкуна, но самый знаменитый город-праздник в Мексике — это не только идеальные пляжи и бесшабашные ночные клубы. Шикарные курортные отели, такие как Nizuc и Atelier Playa Mujeres, представляют высочайший уровень роскоши, а парк развлечений Xohimilco by Xcaret и впечатляющие пирамиды Чичен-Ицы прекрасно подходят для семейного времяпрепровождения. Если же Вы предпочитаете вечеринки, не волнуйтесь: в Канкуне есть все, что Вам нужно. В таких клубах, как Coco Bongo, The City и Hard Rock Cafe, Вы будете веселиться допоздна. А когда захотите сменить обстановку, белый песок и неоново-голубые воды Карибского моря будут Вас ждать всего в нескольких шагах от отеля." 
            };
            Direction direction7 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Empire state building")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Бруклинский мост")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Центральный парк")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Park Central Hotel New York")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Moxy NYC Chelsea")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Standard, East Village")).Single()
                },
                photos = new List<Photo> { photo17 },
                mainPhoto = photo7, 
                name = "Нью-Йорк, Нью-Йорк",
                shortDescription = "Приезжайте сюда за своими заветными мечтами и ярким солнцем и оставайтесь ради местных красот и лучшей в мире пиццы.",
                description = "Самые высокие здания, самые большие музеи и лучшая пицца. Нью-Йорк — это город-гипербола, и обо всем здесь можно говорить в превосходной степени. От ошеломляющего Бродвея до галерей мирового класса MoMA, бутиков Сохо и множества ресторанов, предлагающих блюда из кухонь всех уголков мира. Каждый раз, когда Вы оказываетесь в Нью-Йорке, он открывается с новой стороны. Однако, помимо всех этих знаковых достопримечательностей, Вы можете обнаружить и более скрытую сторону Нью-Йорка. Возможно, даже во время короткой прогулки Вы наткнетесь на винтажные магазинчики инди и места, где местные жители любят проводить время за бранчем. А когда оживленные шумные улицы утомят Вас, просто посмотрите вверх: эти очертания на фоне неба напомнят, почему Вы здесь."
            };
            Direction direction8 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("The Strip")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Bellagio Conservatory & Botanical Garden")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("ARIA Resort & Casino")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Bellagio Las Vegas")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Cosmopolitan of Las Vegas, Autograph Collection")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Venetian Resort")).Single()
                },
                photos = new List<Photo> { photo18 },
                mainPhoto = photo8, 
                name = "Лас-Вегас, Невада",
                shortDescription = "Азартные игроки или просто любопытствующие — в Лас-Вегасе найдутся развлечения на любой вкус.",
                description = "Отправьтесь в кулинарное путешествие по мишленовским ресторанам, попытайте удачу в знаменитых казино или сходите на великолепное представление. Простая прогулка по Лас-Вегас-Стрип заставит Ваши эндорфины вырабатываться с невероятной скоростью. А когда Вы устанете от этой суматохи, отправляйтесь в городские парки и природные заповедники или посетите Неоновый музей, где старые неоновые вывески обретают новую жизнь."
            };
            Direction direction9 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Лондонский Тауэр")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Британский музей")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Vintry & Mercer")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Landmark London")).Single()
                },
                photos = new List<Photo> { photo19 },
                mainPhoto = photo9, 
                name = "Лондон, UK",
                shortDescription = "Царственный город в окружении суеты современной жизни",
                description = "Лондон полон истории: здесь Средневековье и Викторианская эпоха уживаются с роскошным и энергичным современным миром. Лондонский Тауэр и Вестминстер находятся по соседству с местными пабами и рынками, а устаревшие церемонии, например смена караула, происходят в то время, как пассажиры спешат в подземку. Это место, в котором путешественники могут перемещаться во времени, гуляя по городу, а устав, поступить так же, как лондонцы, то есть выпить чашечку чая."
            };
          
            dataBase.directions.AddRange(direction1, direction2, direction3, direction4, direction5, direction6, direction7, direction8, direction9);

            dataBase.SaveChanges();
        }

        public void createHotel()
        {
            Photo photo1 = new Photo {image = Util.getByteImage(@"wwwroot\img\nizuc-resort-and-spa.jpg"), name = @"img\nizuc-resort-and-spa.jpg"};
            Photo photo2 = new Photo {image = Util.getByteImage(@"wwwroot\img\nizuc-resort-and-spa1.jpg"), name = @"img\nizuc-resort-and-spa1.jpg"};
            Photo photo3 = new Photo {image = Util.getByteImage(@"wwwroot\img\nizuc-resort-and-spa2.jpg"), name = @"img\nizuc-resort-and-spa2.jpg"};
            Photo photo4 = new Photo {image = Util.getByteImage(@"wwwroot\img\hyatt-zilara-cancun.jpg"), name = @"img\hyatt-zilara-cancun.jpg"};
            Photo photo5 = new Photo {image = Util.getByteImage(@"wwwroot\img\hyatt-zilara-cancun1.jpg"), name = @"img\hyatt-zilara-cancun1.jpg"};
            Photo photo6 = new Photo {image = Util.getByteImage(@"wwwroot\img\hyatt-zilara-cancun2.jpg"), name = @"img\hyatt-zilara-cancun2.jpg"};
            Photo photo7 = new Photo {image = Util.getByteImage(@"wwwroot\img\le-blanc-spa-resort-cancun.jpg"), name = @"img\le-blanc-spa-resort-cancun.jpg"};
            Photo photo8 = new Photo {image = Util.getByteImage(@"wwwroot\img\le-blanc-spa-resort-cancun1.jpg"), name = @"img\le-blanc-spa-resort-cancun1.jpg"};
            Photo photo9 = new Photo {image = Util.getByteImage(@"wwwroot\img\le-blanc-spa-resort-cancun2.jpg"), name = @"img\le-blanc-spa-resort-cancun2.jpg"};
            Photo photo10 = new Photo {image = Util.getByteImage(@"wwwroot\img\secrets-playa.jpg"), name = @"img\secrets-playa.jpg"};
            Photo photo11 = new Photo {image = Util.getByteImage(@"wwwroot\img\secrets-playa1.jpg"), name = @"img\secrets-playa1.jpg"};
            Photo photo12 = new Photo {image = Util.getByteImage(@"wwwroot\img\secrets-playa2.jpg"), name = @"img\secrets-playa2.jpg"};
            Photo photo13 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn.jpg"), name = @"img\old-faithful-inn.jpg"};
            Photo photo14 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn1.jpg"), name = @"img\old-faithful-inn1.jpg"};
            Photo photo15 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn2.jpg"), name = @"img\old-faithful-inn2.jpg"};
            Photo photo16 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge-Cabins.jpg"), name = @"img\Roosevelt-Lodge-Cabins.jpg"};
            Photo photo17 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge-Cabins1.jpg"), name = @"img\Roosevelt-Lodge-Cabins1.jpg"};
            Photo photo18 = new Photo {image = Util.getByteImage(@"wwwroot\img\roosevelt-lodge-cabins2.jpg"), name = @"img\roosevelt-lodge-cabins2.jpg"};
            Photo photo19 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground.jpg"), name = @"img\madison-campground.jpg"};
            Photo photo20 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground1.jpg"), name = @"img\madison-campground1.jpg"};
            Photo photo21 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground2.jpg"), name = @"img\madison-campground2.jpg"};
            Photo photo22 = new Photo {image = Util.getByteImage(@"wwwroot\img\sanctuary-cap-cana-aerial.jpg"), name = @"img\sanctuary-cap-cana-aerial.jpg"};
            Photo photo23 = new Photo {image = Util.getByteImage(@"wwwroot\img\sanctuary-cap-cana-aerial1.jpg"), name = @"img\sanctuary-cap-cana-aerial1.jpg"};
            Photo photo24 = new Photo {image = Util.getByteImage(@"wwwroot\img\sanctuary-cap-cana-aerial2.jpg"), name = @"img\sanctuary-cap-cana-aerial2.jpg"};
            Photo photo25 = new Photo {image = Util.getByteImage(@"wwwroot\img\Zoetry-Agua-Punta-Cana.jpg"), name = @"img\Zoetry-Agua-Punta-Cana.jpg" };
            Photo photo26 = new Photo {image = Util.getByteImage(@"wwwroot\img\Zoetry-Agua-Punta-Cana1.jpg"), name = @"img\Zoetry-Agua-Punta-Cana1.jpg" };
            Photo photo27 = new Photo {image = Util.getByteImage(@"wwwroot\img\Zoetry-Agua-Punta-Cana2.jpg"), name = @"img\Zoetry-Agua-Punta-Cana2.jpg" };
            Photo photo28 = new Photo {image = Util.getByteImage(@"wwwroot\img\Excellence-Punta-Cana.jpg"), name = @"img\Excellence-Punta-Cana.jpg" };
            Photo photo29 = new Photo {image = Util.getByteImage(@"wwwroot\img\Excellence-Punta-Cana1.jpg"), name = @"img\Excellence-Punta-Cana1.jpg" };
            Photo photo30 = new Photo {image = Util.getByteImage(@"wwwroot\img\Excellence-Punta-Cana2.jpg"), name = @"img\Excellence-Punta-Cana2.jpg" };
            Photo photo31 = new Photo { image = Util.getByteImage(@"wwwroot\img\Royalton-Punta-Cana-Resort.jpg"), name = @"img\Royalton-Punta-Cana-Resort.jpg" };
            Photo photo32 = new Photo { image = Util.getByteImage(@"wwwroot\img\Royalton-Punta-Cana-Resort1.jpg"), name = @"img\Royalton-Punta-Cana-Resort1.jpg" };
            Photo photo33 = new Photo { image = Util.getByteImage(@"wwwroot\img\Royalton-Punta-Cana-Resort2.jpg"), name = @"img\Royalton-Punta-Cana-Resort2.jpg" };
            Photo photo34 = new Photo { image = Util.getByteImage(@"wwwroot\img\Hotel-Wailea.jpg"), name = @"img\Hotel-Wailea.jpg" };
            Photo photo35 = new Photo { image = Util.getByteImage(@"wwwroot\img\Hotel-Wailea1.jpg"), name = @"img\Hotel-Wailea1.jpg" };
            Photo photo36 = new Photo { image = Util.getByteImage(@"wwwroot\img\Hotel-Wailea2.jpg"), name = @"img\Hotel-Wailea2.jpg" };
            Photo photo37 = new Photo { image = Util.getByteImage(@"wwwroot\img\hana-maui-resort.jpg"), name = @"img\hana-maui-resort.jpg" };
            Photo photo38 = new Photo { image = Util.getByteImage(@"wwwroot\img\hana-maui-resort1.jpg"), name = @"img\hana-maui-resort1.jpg" };
            Photo photo39 = new Photo { image = Util.getByteImage(@"wwwroot\img\hana-maui-resort2.jpg"), name = @"img\hana-maui-resort2.jpg" };
            Photo photo40 = new Photo { image = Util.getByteImage(@"wwwroot\img\andaz-maui-at-wailea.jpg"), name = @"img\andaz-maui-at-wailea.jpg" };
            Photo photo41 = new Photo { image = Util.getByteImage(@"wwwroot\img\andaz-maui-at-wailea1.jpg"), name = @"img\andaz-maui-at-wailea1.jpg" };
            Photo photo42 = new Photo { image = Util.getByteImage(@"wwwroot\img\andaz-maui-at-wailea2.jpg"), name = @"img\andaz-maui-at-wailea2.jpg" };
            Photo photo43 = new Photo { image = Util.getByteImage(@"wwwroot\img\disney-s-animal-kingdom.jpg"), name = @"img\disney-s-animal-kingdom.jpg" };
            Photo photo44 = new Photo { image = Util.getByteImage(@"wwwroot\img\disney-s-animal-kingdom1.jpg"), name = @"img\disney-s-animal-kingdom1.jpg" };
            Photo photo45 = new Photo { image = Util.getByteImage(@"wwwroot\img\disney-s-animal-kingdom2.jpg"), name = @"img\disney-s-animal-kingdom2.jpg" };
            Photo photo46 = new Photo { image = Util.getByteImage(@"wwwroot\img\hilton-orlando-bonnet.jpg"), name = @"img\hilton-orlando-bonnet.jpg" };
            Photo photo47 = new Photo { image = Util.getByteImage(@"wwwroot\img\hilton-orlando-bonnet1.jpg"), name = @"img\hilton-orlando-bonnet1.jpg" };
            Photo photo48 = new Photo { image = Util.getByteImage(@"wwwroot\img\hilton-orlando-bonnet2.jpg"), name = @"img\hilton-orlando-bonnet2.jpg" };
            Photo photo49 = new Photo { image = Util.getByteImage(@"wwwroot\img\four-seasons-resort-orlando.jpg"), name = @"img\four-seasons-resort-orlando.jpg" };
            Photo photo50 = new Photo { image = Util.getByteImage(@"wwwroot\img\four-seasons-resort-orlando1.jpg"), name = @"img\four-seasons-resort-orlando1.jpg" };
            Photo photo51 = new Photo { image = Util.getByteImage(@"wwwroot\img\four-seasons-resort-orlando2.jpg"), name = @"img\four-seasons-resort-orlando2.jpg" };
            Photo photo52 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-alfond-inn.jpg"), name = @"img\the-alfond-inn.jpg" };
            Photo photo53 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-alfond-inn1.jpg"), name = @"img\the-alfond-inn1.jpg" };
            Photo photo54 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-alfond-inn2.jpg"), name = @"img\the-alfond-inn2.jpg" };
            Photo photo55 = new Photo { image = Util.getByteImage(@"wwwroot\img\el-portal-sedona-hotel.jpg"), name = @"img\el-portal-sedona-hotel.jpg" };
            Photo photo56 = new Photo { image = Util.getByteImage(@"wwwroot\img\el-portal-sedona-hotel1.jpg"), name = @"img\el-portal-sedona-hotel1.jpg" };
            Photo photo57 = new Photo { image = Util.getByteImage(@"wwwroot\img\el-portal-sedona-hotel2.jpg"), name = @"img\el-portal-sedona-hotel2.jpg" };
            Photo photo58 = new Photo { image = Util.getByteImage(@"wwwroot\img\Auberge-de-Sedona.jpg"), name = @"img\Auberge-de-Sedona.jpg" };
            Photo photo59 = new Photo { image = Util.getByteImage(@"wwwroot\img\Auberge-de-Sedona1.jpg"), name = @"img\Auberge-de-Sedona1.jpg" };
            Photo photo60 = new Photo { image = Util.getByteImage(@"wwwroot\img\Auberge-de-Sedona2.jpg"), name = @"img\Auberge-de-Sedona2.jpg" };
            Photo photo61 = new Photo { image = Util.getByteImage(@"wwwroot\img\enchantment-resort.jpg"), name = @"img\enchantment-resort.jpg" };
            Photo photo62 = new Photo { image = Util.getByteImage(@"wwwroot\img\enchantment-resort1.jpg"), name = @"img\enchantment-resort1.jpg" };
            Photo photo63 = new Photo { image = Util.getByteImage(@"wwwroot\img\enchantment-resort2.jpg"), name = @"img\enchantment-resort2.jpg" };
            Photo photo64 = new Photo { image = Util.getByteImage(@"wwwroot\img\park-central.jpg"), name = @"img\park-central.jpg" };
            Photo photo65 = new Photo { image = Util.getByteImage(@"wwwroot\img\park-central1.jpg"), name = @"img\park-central1.jpg" };
            Photo photo66 = new Photo { image = Util.getByteImage(@"wwwroot\img\park-central2.jpg"), name = @"img\park-central2.jpg" };
            Photo photo67 = new Photo { image = Util.getByteImage(@"wwwroot\img\Moxy-NYC-Chelsea.jpg"), name = @"img\Moxy-NYC-Chelsea.jpg" };
            Photo photo68 = new Photo { image = Util.getByteImage(@"wwwroot\img\Moxy-NYC-Chelsea1.jpg"), name = @"img\Moxy-NYC-Chelsea1.jpg" };
            Photo photo69 = new Photo { image = Util.getByteImage(@"wwwroot\img\Moxy-NYC-Chelsea2.jpg"), name = @"img\Moxy-NYC-Chelsea2.jpg" };
            Photo photo70 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Standard.jpg"), name = @"img\The-Standard.jpg" };
            Photo photo71 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Standard1.jpg"), name = @"img\The-Standard1.jpg" };
            Photo photo72 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Standard2.jpg"), name = @"img\The-Standard2.jpg" };
            Photo photo73 = new Photo { image = Util.getByteImage(@"wwwroot\img\aria.jpg"), name = @"img\aria.jpg" };
            Photo photo74 = new Photo { image = Util.getByteImage(@"wwwroot\img\aria1.jpg"), name = @"img\aria1.jpg" };
            Photo photo75 = new Photo { image = Util.getByteImage(@"wwwroot\img\aria2.jpg"), name = @"img\aria2.jpg" };
            Photo photo76 = new Photo { image = Util.getByteImage(@"wwwroot\img\bellagio-las-vegas.jpg"), name = @"img\bellagio-las-vegas.jpg" };
            Photo photo77 = new Photo { image = Util.getByteImage(@"wwwroot\img\bellagio-las-vegas1.jpg"), name = @"img\bellagio-las-vegas1.jpg" };
            Photo photo78 = new Photo { image = Util.getByteImage(@"wwwroot\img\bellagio-las-vegas2.jpg"), name = @"img\bellagio-las-vegas2.jpg" };
            Photo photo79 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cosmopolitan.jpg"), name = @"img\Cosmopolitan.jpg" };
            Photo photo80 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cosmopolitan1.jpg"), name = @"img\Cosmopolitan1.jpg" };
            Photo photo81 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cosmopolitan2.jpg"), name = @"img\Cosmopolitan2.jpg" };
            Photo photo82 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-venetian-las-vegas.jpg"), name = @"img\the-venetian-las-vegas.jpg" };
            Photo photo83 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-venetian-las-vegas1.jpg"), name = @"img\the-venetian-las-vegas1.jpg" };
            Photo photo84 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-venetian-las-vegas2.jpg"), name = @"img\the-venetian-las-vegas2.jpg" };
            Photo photo85 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vintry-&-Mercer.jpg"), name = @"img\Vintry-&-Mercer.jpg" };
            Photo photo86 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vintry-&-Mercer1.jpg"), name = @"img\Vintry-&-Mercer1.jpg" };
            Photo photo87 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vintry-&-Mercer2.jpg"), name = @"img\Vintry-&-Mercer2.jpg" };
            Photo photo88 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Landmark-London.jpg"), name = @"img\The-Landmark-London.jpg" };
            Photo photo89 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Landmark-London1.jpg"), name = @"img\The-Landmark-London1.jpg" };
            Photo photo90 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Landmark-London2.jpg"), name = @"img\The-Landmark-London2.jpg" };
            
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12, photo13, photo14, photo15, photo16, photo17, photo18, photo19, photo20, photo21, photo22, photo23, photo24, photo25, photo26, photo27, photo28, photo29, photo30, photo31, photo32, photo33, photo34, photo35, photo36, photo37, photo38, photo39, photo40, photo41, photo42, photo43, photo44, photo45, photo46, photo47, photo48, photo49, photo50, photo51, photo52, photo53, photo54, photo55, photo56, photo57, photo58, photo59, photo60, photo61, photo62, photo63, photo64, photo65, photo66, photo67, photo68, photo69, photo70, photo71, photo72, photo73, photo74, photo75, photo76, photo77, photo78, photo79, photo80, photo81, photo82, photo83, photo84, photo85, photo86, photo87, photo88, photo89, photo90);

            RoomEquipment roomEquipment1 = new RoomEquipment { name = "ewq", photo = photo1 };

            Hotel hotel1 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g150807-d3580898-Reviews-NIZUC_Resort_and_Spa-Cancun_Yucatan_Peninsula.html
                name = "NIZUC Resort and Spa",
                location = "Blvd Kukulcan Km 21 Lote 1-03 Km 21.26, Канкун 77500 Мексика",
                description = "Ищете романтический курорт в Канкуне? Можете больше не искать. Ниcук Резорт & Спа подойдет вам наилучшим образом.Номера оборудованы ТВ с плоским экраном, кондиционером и холодильником, а гости могут в любой момент быть онлайн благодаря бесплатному Wi-Fi, который предлагает курорт.Ниcук Резорт & Спа предлагает услуги консьержа и обслуживание в номер, чтобы сделать пребывание гостей здесь еще более приятным. К услугам гостей также бассейн и завтрак. Те, кто приезжает в Ниcук Резорт & Спа на машине, могут воспользоваться бесплатной парковкой.Не премините посетить итальянские рестораны, например Bacoli Tratoria, Restaurante Condimento и Da Vinci, расположенные недалеко от Ниcук Резорт & Спа.Если у вас будет достаточно времени, посетите Руины Эль-Рей, Yamil Lu'um и Scorpion’s Temple — популярные древние руины, до которых достаточно легко добраться.Сотрудники Ниcук Резорт & Спа с нетерпением вас ждут. Вы будете приятно удивлены уровнем обслуживания.",
                countStars = 5,
                styleHotel = "Роскошный ; Романтический",
                languages = "Испанский",
                mainPhoto = photo1,
                photos = new List<Photo> {photo2, photo3},
            };
            Hotel hotel2 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g150807-d642781-Reviews-Hyatt_Zilara_Cancun-Cancun_Yucatan_Peninsula.html
                name = "Hyatt Zilara Cancun",
                location = "Boulevard Kukulcan Zona Hotelera, Канкун 77500 Мексика",
                phoneNumber = "810 52 55 7005 8701",
                description = "Роял — это отличный выбор для гостей Канкуна, элитная атмосфера и множество полезных услуг сделают пребывание здесь очень приятным. Номера оборудованы ТВ с плоским экраном, мини-баром и холодильником, а выйти в Сеть в Royal Cancun очень просто благодаря бесплатному Wi-Fi. Вы также можете воспользоваться следующими услугами, которые предлагает курорт \"все включено\": услугами консьержа и обслуживанием номеров. Кроме того, к услугам гостей есть бассейн и завтрак. Дополнительное удобство для гостей — бесплатная парковка. Расположенные поблизости достопримечательности, такие как Scorpion’s Temple (1,1 км) и Avenida Kukulkan (2,1 км), превращают курорт все включено Роял в отличное место пребывания для гостей Канкуна. При посещении Канкуна вам может захотеться отведать омаров в одном из близлежащих ресторанов, например в Lorenzillo's, Harry's Cancún или Puerto Madero. И самое главное — проживая в курорте \"все включено\" Cancun Royal, вы легко сможете посетить многие великолепные достопримечательности Канкуна, например Tres Rios Ecopark, Parque Urbano Kabah и arte Garden, которые являются популярными парками. Желаем приятно провести время в Канкуне!",
                countStars = 4,
                styleHotel = "С красивым видом ; С зелеными насаждениями",
                languages = "Испанский",
                mainPhoto = photo4,
                photos = new List<Photo> {photo5, photo6},
            };
            Hotel hotel3 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g150807-d154868-Reviews-Le_Blanc_Spa_Resort_Cancun-Cancun_Yucatan_Peninsula.html
                name = "Le Blanc Spa Resort Cancun",
                location = "Boulevard Kukulcan Km 10 Zona Hotelera, Канкун 77550 Мексика",
                phoneNumber = "810 1 888-205-9375",
                description = "Ищете романтический курорт все включено в Канкуне? Можете больше не искать. Ле Бланк Спа Резорт подойдет вам наилучшим образом. Учитывая близкое расположение таких популярных достопримечательностей, как Scorpion’s Temple (1,9 км) и Avenida Kukulkan (2,9 км), гости курорта все включено Le Blanc без труда смогут посетить одни из самых известных мест Канкуна. Номера оборудованы ТВ с плоским экраном, кондиционером и мини-баром, а гости могут в любой момент быть онлайн благодаря бесплатному Wi-Fi, который предлагает курорт все включено. Le Blanc Resort предлагает обслуживание в номер и услуги консьержа, чтобы сделать пребывание гостей здесь еще более приятным. К услугам гостей также бассейн и бесплатный завтрак. Те, кто приезжает в Ле Бланк Спа Резорт на машине, могут воспользоваться бесплатной парковкой. Если вы любите итальянские рестораны, курорт все включено Le Blanc удобно расположен рядом с Casa Rolandi, Limoncello и Restaurante Chianti. Во время своей поездки обязательно посетите популярные художественные галереи, например Antaras Onix и Galeria Balance Cancun, расположенные в шаговой доступности от курорта все включено. Сотрудники Ле Бланк Спа Резорт с нетерпением вас ждут. Вы будете приятно удивлены уровнем обслуживания.",
                hrefSite = "https://www.leblancsparesorts.com/cancun/en/offers",
                countStars = 5,
                styleHotel = "С видом на океан ; Роскошный",
                languages = "Английский, Испанский",
                mainPhoto = photo7,
                photos = new List<Photo> {photo8, photo9},
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment1,
                    roomEquipment2
                }
            };
            Hotel hotel4 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g1229340-d6510287-Reviews-Secrets_Playa_Mujeres_Golf_Spa_Resort-Playa_Mujeres_Yucatan_Peninsula.html
                name = "Secrets Playa Mujeres Golf & Spa Resort",
                location = "Prolongacion Bonampak S/N, Плайя-Мухерес 77400 Мексика",
                phoneNumber = "810 52 998 271 6304",
                countStars = 5,
                styleHotel = "С видом на бухту ; С видом на океан",
                languages = "Испанский",
                mainPhoto = photo10,
                photos = new List<Photo> {photo11, photo12},
            };
            

            //direction1
            Hotel hotel5 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60999-d220121-Reviews-Old_Faithful_Inn-Yellowstone_National_Park_Wyoming.html
                name = "Old Faithful Inn",
                location = "3200 Old Faithful Inn Rd, Йеллоустонский национальный парк, WY 82190",
                countStars = 2,
                languages = "Английский",
                mainPhoto = photo13,
                photos = new List<Photo> { photo14, photo15 },
            };
            Hotel hotel6 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60999-d220052-Reviews-Roosevelt_Lodge_Cabins-Yellowstone_National_Park_Wyoming.html
                name = "Roosevelt Lodge Cabins",
                location = "100 Roosevelt Lodge Rd, Йеллоустонский национальный парк, WY 82190",
                countStars = 2,
                languages = "Английский",
                mainPhoto = photo16,
                photos = new List<Photo> { photo17, photo18 },
            };
            Hotel hotel7 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60999-d219061-Reviews-Madison_Campground-Yellowstone_National_Park_Wyoming.html
                name = "Madison Campground",
                location = "30 Madison Campground Rd, Йеллоустонский национальный парк, WY 82190",
                countStars = 1,
                styleHotel = "Семейный",
                languages = "Английский",
                mainPhoto = photo19,
                photos = new List<Photo> {photo20, photo21},
            };
            //direction2
            Hotel hotel8 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g16884615-d1022212-Reviews-Sanctuary_Cap_Cana-Cap_Cana_Punta_Cana_La_Altagracia_Province_Dominican_Republic.html
                name = "Sanctuary Cap Cana",
                location = "Boulevard Zona Hotelera Playa Juanillo, Cap Cana, Пунта-Кана 23000 Доминикана",
                phoneNumber = "810 1 833-297-5292",
                description = "Sanctuary Cap Cana by Playa Hotels & Resorts — это отличный выбор для путешественников в Пунта-Кане. Это хорошее соотношение цены и качества, комфорта и удобства, романтической атмосферы и услуг, призванных сделать пребывание здесь очень приятным. Номера в Sanctuary Cap Cana Hotel оборудованы ТВ с плоским экраном, холодильником и мини-баром. Гости могут быть постоянно на связи благодаря платному Wi-Fi. К вашим услугам во время пребывания в Sanctuary Cap Cana Hotel также бассейн и бар у бассейна. Ищете, где оставить машину? Sanctuary Cap Cana by Playa Hotels & Resorts предлагает бесплатная парковка предоставляется Если вы ищете хороший паб, вам стоит сходить в Api Beach, Bohemian Tapas & Wine Bar или La Taberna de Charlo, если вы остановились в отеле Sanctuary Cap Cana Hotel. Если вы хотите лучше узнать Пунта-Кана, посетите парк, например Экологический парк Indigenous Eyes. Мы уверены, что Sanctuary Cap Cana by Playa Hotels & Resorts вам понравится. Проживая здесь, вы сможете увидеть все, что Пунта-Кана предлагает своим гостям.",
                hrefSite = "https://sanctuarycapcana.com/?utm_source=Tripadvisor&utm_medium=hotelwebsite&utm_campaign=businessadvantage",
                countStars = 5,
                styleHotel = "С красивым видом",
                languages = "Английский, Испанский",
                mainPhoto = photo22,
                photos = new List<Photo> { photo23, photo24 },
            };
            Hotel hotel9 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g147293-d649099-Reviews-Zoetry_Agua_Punta_Cana-Punta_Cana_La_Altagracia_Province_Dominican_Republic.html
                name = "Zoetry Agua Punta Cana",
                location = "Playas de Uvero Alto, Пунта-Кана 23000 Доминикана",
                countStars = 5,
                styleHotel = "Скрытая жемчужина ; С красивым видом",
                languages = "Испанский",
                mainPhoto = photo25,
                photos = new List<Photo> { photo26, photo27 },
            };
            Hotel hotel10 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g147293-d218524-Reviews-Excellence_Punta_Cana-Punta_Cana_La_Altagracia_Province_Dominican_Republic.html
                name = "Excellence Punta Cana",
                location = "Playas Uvero Alto, Пунта-Кана 23000 Доминикана",
                phoneNumber = "810 1 866-211-6223",
                hrefSite = "https://www.tripadvisor.ru/Hotel_Review-g147293-d218524-Reviews-Excellence_Punta_Cana-Punta_Cana_La_Altagracia_Province_Dominican_Republic.html",
                countStars = 5,
                styleHotel = "С видом на океан ; С зелеными насаждениями",
                languages = "Испанский",
                mainPhoto = photo28,
                photos = new List<Photo> { photo29, photo30 },
            };
            Hotel hotel11 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g147293-d4939796-Reviews-Royalton_Punta_Cana_Resort_Casino-Punta_Cana_La_Altagracia_Province_Dominican_Republic.html
                name = "Royalton Punta Cana Resort & Casino",
                location = "Playa Arena Gorda, Carretera Macao, Пунта-Кана 23000 Доминикана",
                description = "Добро пожаловать в Royalton Punta Cana Resort & Casino! Вы будете чувствовать себя в Пунта-Кане как дома благодаря услугам, которые предлагает этот курорт \"все включено\". Номера оборудованы ТВ с плоским экраном, кондиционером и холодильником, а выйти в Сеть в Royalton Punta Cana Resort & Casino очень просто благодаря бесплатному Интернету. Вы также можете воспользоваться следующими услугами, которые предлагает курорт \"все включено\": обслуживанием номеров и услугами консьержа. Кроме того, к услугам гостей есть бассейн и бесплатный завтрак. Дополнительное удобство для гостей — парковка. Во время пребывания в Пунта-Кане, возможно, вам захочется посетить некоторые рестораны рядом с Royalton Punta Cana Resort & Casino, например Kukua Beach Club (1,5 км), Montserrat Manor Restaurant (1,4 км) и Ciao (1,5 км). Если вы остановитесь в Royalton Punta Cana Resort & Casino, то все лучшее, что только есть в Пунта-Кане, будет у вас под рукой, и у вас останутся прекрасные впечатления от поездки.",
                hrefSite = "https://sanctuarycapcana.com/?utm_source=Tripadvisor&utm_medium=hotelwebsite&utm_campaign=businessadvantage",
                countStars = 4,
                styleHotel = "Современно ; Семейный",
                languages = "Испанский",
                mainPhoto = photo31,
                photos = new List<Photo> { photo32, photo33 },
            };
            //3
            Hotel hotel12 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g609129-d247776-Reviews-Hotel_Wailea-Wailea_Maui_Hawaii.html
                name = "Hotel Wailea",
                location = "555 Kaukahi Street, Вайлеа, Остров Мауи",
                phoneNumber = "810 1 808 - 419 - 7280",
                description = "Добро пожаловать в Отель Уейли! Вы будете чувствовать себя в Вайлеа как дома благодаря услугам, которые предлагает этот курорт. Во время пребывания в Отель Уейли гости могут посетить Keawala'i Congregational Church (3,3 км), одну из популярных достопримечательностей Wailea. Номера оборудованы ТВ с плоским экраном, холодильником и мини-кухней, а выйти в Сеть в Отель Уейли очень просто благодаря бесплатному Wi-Fi. Вы также можете воспользоваться следующими услугами, которые предлагает курорт: круглосуточной стойкой регистрации, обслуживанием номеров и услугами консьержа. Кроме того, к услугам гостей есть бассейн и бар у бассейна. Дополнительное удобство для гостей — парковка. Во время пребывания в Вайлеа обязательно сходите в самые популярные среди местных жителей места, где можно отведать крабов: Ferraro's Bar e Ristorante, Duo Steak & Seafood или Tommy Bahama's Restaurant & Bar. И самое главное — проживая в курорте Diamond Resort, вы легко сможете посетить некоторые великолепные достопримечательности Wailea, например Makena Landing Park, популярный парк. Если вы остановитесь в Отель Уейли, то все лучшее, что только есть в Вайлеа, будет у вас под рукой, и у вас останутся прекрасные впечатления от поездки.",
                hrefSite = "https://www.hotelwailea.com/?utm_source=tripadvisor&utm_medium=referral&utm_campaign=tabl",
                countStars = 4,
                styleHotel = "Очаровательный ; С зелеными насаждениями",
                languages = "Английский, Французский, Японский",
                mainPhoto = photo34,
                photos = new List<Photo> { photo35, photo36 },
            };
            Hotel hotel13 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60630-d120706-Reviews-Hana_Maui_Resort-Hana_Maui_Hawaii.html
                name = "Hana-Maui Resort",
                location = "5031 Hana Hwy, Ханалей, Остров Мауи, HI 96713",
                phoneNumber = "810 1 808-207-6401",
                description = "Добро пожаловать в Травааза Отель Хана! Вы будете чувствовать себя в Хане как дома благодаря услугам, которые предлагает этот отель. Близкое расположение к одним из самых популярных достопримечательностей Ханы, таким как Hana Tropicals (2,3 км) и Hana Gold (4,4 км), делает Травааза Отель Хана очень привлекательным для туристов. Номера оборудованы холодильником, а выйти в Сеть в Травааза Отель Хана очень просто благодаря бесплатному Wi-Fi. Вы также можете воспользоваться следующими услугами, которые предлагает отель: круглосуточной стойкой регистрации, обслуживанием номеров и услугами консьержа. Кроме того, к услугам гостей есть бассейн и завтрак. Дополнительное удобство для гостей — бесплатная парковка. Не премините посетить Chow Wagon, один из корейских ресторанов Ханы, расположенный недалеко от отеля Hotel Hana Maui. Если вы хотите лучше узнать Хану, посетите один из водопадов, например Hanawi Falls и Wailua Falls. Если вы остановитесь в Травааза Отель Хана, то все лучшее, что только есть в Хане, будет у вас под рукой, и у вас останутся прекрасные впечатления от поездки.",
                hrefSite = "https://www.hyatt.com/en-US/hotel/hawaii/hana-maui-resort/oggal?src=vanity_hanamauiresort.com",
                countStars = 4,
                styleHotel = "С красивым видом",
                languages = "Английский",
                mainPhoto = photo37,
                photos = new List<Photo> { photo38, photo39 },
            };
            Hotel hotel14 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g609129-d4459053-Reviews-Andaz_Maui_At_Wailea_Resort-Wailea_Maui_Hawaii.html
                name = "Andaz Maui At Wailea Resort",
                location = "3550 Wailea Alanui Dr, Вайлеа, Остров Мауи, HI 96753-9518",
                description = "Найти идеальный семейный курорт в Вайлеа не должно быть сложной задачей. Добро пожаловать в Андаз Мауи Эт Уейли, прекрасный выбор для таких путешественников, как вы. Вы сможете прекрасно отдохнуть в номерах с ТВ с плоским экраном, мини-баром и кондиционером. Вы также cможете постоянно быть на связи, так как Андаз Мауи Эт Уейли предлагает гостям бесплатный Wi-Fi. Курорт предлагает услуги консьержа и обслуживание в номер. Кроме того, к услугам гостей Андаз Мауи Эт Уейли бассейн и завтрак, что поможет отдохнуть после насыщенного дня. Гости, приехавшие на автомобиле, могут воспользоваться парковкой. Расположенный близко к Keawala'i Congregational Church (4,8 км), популярной достопримечательности Wailea, Андаз Мауи Эт Уейли превосходно подходит для туристов. Во время пребывания в Вайлеа, возможно, вам захочется посетить некоторые рестораны рядом с Андаз Мауи Эт Уейли, например Monkeypod Kitchen (1,3 км), Ka'ana Kitchen (0,1 км) и Tommy Bahama's Restaurant & Bar (0,7 км). Во время своей поездки обязательно посетите популярную художественную галерею, например Enchantress Gallery By Bootzie, расположенную недалеко от курорта. Если вы остановитесь в Андаз Мауи Эт Уейли, то все лучшее, что только есть в Вайлеа, будет у вас под рукой, и у вас останутся прекрасные впечатления от поездки.",
                countStars = 5,
                styleHotel = "С красивым видом ; С зелеными насаждениями",
                languages = "Английский, Французский, Испанский, Филиппинский, Немецкий, Итальянский, Японский, Португальский",
                mainPhoto = photo40,
                photos = new List<Photo> { photo41, photo42 },
            };
            //4
            Hotel hotel15 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g34515-d189076-Reviews-Disney_s_Animal_Kingdom_Lodge-Orlando_Florida.html
                name = "Disney's Animal Kingdom Lodge",
                location = "2901 Osceola Parkway Lake Buena Vista, Орландо, FL 32830-8410",
                description = "Добро пожаловать в Дисней'С Анимал Кингдом Лодж! Вы будете чувствовать себя в Орландо как дома благодаря услугам, которые предлагает этот курорт. Во время пребывания в курорте Disney Animal Kingdom Hotel гости могут посетить Dino-Sue (0,1 км) и Academy of Television Arts and Sciences Hall of Fame Plaza (4,3 км), одни из самых популярных достопримечательностей Орландо. Вы сможете прекрасно отдохнуть в номерах с ТВ с плоским экраном, кондиционером и холодильником. Вы также cможете постоянно быть на связи, так как Disneys Animal Kingdom Lodge предлагает гостям бесплатный Wi-Fi. Курорт предлагает услуги консьержа и обслуживание в номер. Кроме того, к услугам гостей Disney Animal Kingdom Lodge бассейн и завтрак, что поможет отдохнуть после насыщенного дня. Гости, приехавшие на автомобиле, могут воспользоваться парковкой. Во время пребывания в Орландо, возможно, вам захочется посетить некоторые рестораны рядом с Дисней'С Анимал Кингдом Лодж, например Boma - Flavors of Africa (0,1 км), Sanaa (0,3 км) и Tusker House Restaurant (1,3 км). Если у вас будет достаточно времени, посетите популярную достопримечательность Tree of Life — она находится в нескольких минутах ходьбы от курорта. Если вы остановитесь в Дисней'С Анимал Кингдом Лодж, то все лучшее, что только есть в Орландо, будет у вас под рукой, и у вас останутся прекрасные впечатления от поездки.",
                countStars = 4,
                styleHotel = "Семейный курорт ; С красивым видом",
                languages = "Английский",
                mainPhoto = photo43,
                photos = new List<Photo> { photo44, photo45 },
            };
            Hotel hotel16 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g34515-d1308392-Reviews-Hilton_Orlando_Bonnet_Creek-Orlando_Florida.html
                name = "Hilton Orlando Bonnet Creek",
                location = "14100 Bonnet Creek Resort Lane, Орландо, FL 32821-4023",
                phoneNumber = "810 1 855-605-0316",
                description = "Хилтон Орландо Боннет Крик — это отличный выбор для путешественников в Орландо. Это хорошее соотношение цены и качества, комфорта и удобства, семейной атмосферы и услуг, призванных сделать пребывание здесь очень приятным. Здесь вы будете чувствовать себя как дома, т.к. номера отеля оборудованы ТВ с плоским экраном, кондиционером и холодильником, а благодаря общественному Wi-Fi выйти в Сеть можно в любой момент. У гостей есть доступ к услугам консьержа и обслуживанию номеров во время пребывания в Hilton Orlando Bonnet Creek Hotel. Кроме того, в Хилтон Орландо Боннет Крик есть бассейн и завтрак, что сделает поездку в Орландо особенно приятной. Дополнительное удобство для гостей — парковка. Тем, кто хочет посетить популярные достопримечательности во время пребывания в Орландо, следует учесть, что Хилтон Орландо Боннет Крик расположен недалеко от таких достопримечательностей, как Disney's Boardwalk (2,2 км) и Characters in Flight (2,2 км). Если вы ищете паб, то можете сходить в Raglan Road Irish Pub & Restaurant, Miller's Ale House - Lake Buena Vista или Rose & Crown Dining Room, расположенные совсем недалеко от Хилтон Орландо Боннет Крик. В Орландо также известен великолепными историческим музеям, включая Tupperware Confidence Center и House of the Whispering Willows, которые расположены не очень далеко от отеля Хилтон Орландо Боннет Крик. Мы уверены, что Хилтон Орландо Боннет Крик вам понравится. Проживая здесь, вы сможете увидеть все, что Орландо предлагает своим гостям.",
                hrefSite = "https://www3.hilton.com/en/hotels/florida/hilton-orlando-bonnet-creek-ORLHHHH/index.html?WT.mc_id=zLADA0WW1HH2OLX3DA4HWB5TABL6ORLHHHH",
                countStars = 4,
                styleHotel = "С хорошим соотношением цены и качества ; Бизнес - класс",
                languages = "Английский, Испанский",
                mainPhoto = photo46,
                photos = new List<Photo> { photo47, photo48 },
            };
            Hotel hotel17 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g34515-d6523102-Reviews-Four_Seasons_Resort_Orlando_at_Walt_Disney_World_Resort-Orlando_Florida.html
                name = "Four Seasons Resort Orlando at Walt Disney World Resort",
                location = "10100 Dream Tree Blvd, Орландо, FL 32836-4012",
                phoneNumber = "810 1 407 - 313 - 7777",
                description = "Four Seasons Resort Orlando at Walt Disney World Resort — это отличный выбор для путешественников в Орландо. Это хорошее соотношение цены и качества, комфорта и удобства, романтической атмосферы и услуг, призванных сделать пребывание здесь очень приятным. Гостям предоставляется бесплатный Wi-Fi. Номера в Four Seasons Resort Orlando at Walt Disney World Resort оборудованы ТВ с плоским экраном, кондиционером и мини-баром. Во время пребывания здесь воспользуйтесь такими услугами, как услуги консьержа, обслуживание номеров и терраса на крыше. К услугам гостей Four Seasons Resort Orlando at Walt Disney World Resort также бассейн и завтрак. Путешественники, приехавшие на машине, могут воспользоваться парковкой. Близкое расположение к одним из самых популярных достопримечательностей Орландо, таким как Camp Disney (3,9 км) и Cinderella Castle (4,0 км), делает отель Four Seasons Resort Orlando at Walt Disney World Resort очень привлекательным для туристов. Обязательно стоит сходить в один из популярных в Орландо ресторанов, где подают крабов. Cinderella's Royal Table, Victoria & Albert's и The Boathouse расположены рядом с отелем Four Seasons Resort Orlando at Walt Disney World Resort. Если вы хотите лучше узнать Орландо, посетите исторический музей, например House of the Whispering Willows. Мы уверены, что Four Seasons Resort Orlando at Walt Disney World Resort вам понравится. Проживая здесь, вы сможете увидеть все, что Орландо предлагает своим гостям.",
                hrefSite = "https://www.fourseasons.com/orlando/",
                countStars = 5,
                styleHotel = "Роскошный ; С видом на парк",
                languages = "Английский",
                mainPhoto = photo49,
                photos = new List<Photo> { photo50, photo51 },
            };
            Hotel hotel18 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g34747-d4605231-Reviews-The_Alfond_Inn-Winter_Park_Florida.html
                name = "The Alfond Inn",
                location = "300 E New England Ave, Winter Park, FL 32789-4426",
                description = "Олфонд Инн — это отличный выбор для гостей Winter Park, романтическая атмосфера и множество полезных услуг сделают пребывание здесь очень приятным. Номера в Олфонд Инн оборудованы ТВ с плоским экраном и кондиционером. Гости могут быть постоянно на связи благодаря бесплатному Wi-Fi. К вашим услугам во время пребывания в Олфонд Инн также бассейн на крыше и завтрак. Ищете, где оставить машину? Олфонд Инн предлагает парковка предоставляется Рядом располагается Community Playground (1,3 км), что превращает отель Олфонд Инн в отличное место для проживания для тех, кто хочет посетить эту популярную достопримечательность Winter Park. Когда вы ищете, где перекусить, загляните в Prato, Braccia Ristorante и Pannullo's — популярные среди местных жителей и туристов итальянские рестораны. В Winter Park также известен великолепными художественным галереям, включая Timothy's Gallery, Crealde School of Art и Baterbys Art Gallery, которые расположены не очень далеко от отеля Олфонд Инн. Желаем приятно провести время в Winter Park!",
                countStars = 4,
                languages = "Английский, Испанский, Голландский, Португальский",
                mainPhoto = photo52,
                photos = new List<Photo> { photo53, photo54 },
            };
            //5
            Hotel hotel19 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g31352-d324197-Reviews-El_Portal_Sedona_Hotel-Sedona_Arizona.html
                name = "El Portal Sedona Hotel",
                location = "95 Portal Lane Coconino National Forest, Седона, AZ 86336-6166",
                phoneNumber = "810 1 844-647-3727",
                description = "Эл Портал Седона Отель — это отличный выбор для гостей Седоны, романтическая атмосфера и множество полезных услуг сделают пребывание здесь очень приятным. Тем, кто хочет посетить популярные достопримечательности во время пребывания в Седоне, следует учесть, что Эл Портал Седона Отель расположен недалеко от таких достопримечательностей, как Tlaquepaque Arts & Crafts Village (0,2 км) и McLean Meditation Institute (0,3 км). Гостям предоставляется бесплатный Wi-Fi. Номера в Эл Портал Седона Отель оборудованы ТВ с плоским экраном, кондиционером и холодильником. Во время пребывания здесь воспользуйтесь такими услугами, как услуги консьержа. К услугам гостей Эл Портал Седона Отель также завтрак. Путешественники, приехавшие на машине, могут воспользоваться бесплатной парковкой. Если вы любите азиатские рестораны, Эл Портал Седона Отель удобно расположен рядом с Momo's Kitchen, Thai Palace и Hiro's Sushi & Japanese Kitchen. Если вы хотите лучше узнать Седону, посетите архитектурное сооружение, например Chapel of the Holy Cross. Желаем приятно провести время в Седоне!",
                hrefSite = "https://www.elportalsedona.com/",
                countStars = 3,
                styleHotel = "С зелеными насаждениями ж Расположение в центре",
                languages = "Английский, Испанский",
                mainPhoto = photo55,
                photos = new List<Photo> { photo56, photo57 },
            };
            Hotel hotel20 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g31352-d115335-Reviews-L_Auberge_de_Sedona-Sedona_Arizona.html
                name = "L'Auberge de Sedona",
                location = "301 L'Auberge Lane, Седона, AZ 86336-4260",
                phoneNumber = "810 1 800-905-5745",
                description = "Л'Оберж Де Седона — это отличный выбор для тех, кто приехал в Седону. Это хорошее сочетание цены и качества, комфорта и удобства, романтической атмосферы и услуг, призванных сделать пребывание здесь очень приятным. Близость к таким достопримечательностям, как Schnebly Hill Road (0,8 км) и McLean Meditation Institute (0,8 км), превращает курорт L`auberge De Sedona Hotel в отличное место для проживания во время посещения Седоны. Здесь вы будете чувствовать себя как дома, т.к. номера курорта оборудованы ТВ с плоским экраном, а благодаря бесплатному Wi-Fi выйти в Сеть можно в любой момент. У гостей есть доступ к круглосуточной стойке регистрации, услугам консьержа и обслуживанию номеров во время пребывания в L Auberge De Sedona. Кроме того, в L Auberge De Sedona есть бассейн и завтрак, что сделает поездку в Седону особенно приятной. Дополнительное удобство для гостей — парковка. Когда вы ищете, где перекусить, загляните в Mariposa Latin Inspired Grill, Silver Saddle @ The Cowboy Club и Golden Goose American Grill — популярные среди местных жителей и туристов стейкхаусы. Тем, кто ищет, чем заняться в этом районе, будет интересно узнать, что Main Street (0,4 км) — это популярная достопримечательность в шаговой доступности от курорта L Auberge De Sedona Hotel. Ваш комфорт и удовлетворение — это самое главное для сотрудников Л'Оберж Де Седона. Они с нетерпением ждут вас в Седоне",
                hrefSite = "https://www.lauberge.com/?utm_source=tripadvisor.com_bl&utm_medium=media&utm_content=homepage&utm_campaign=paid_businesslisting",
                countStars = 4,
                styleHotel = "С видом на реку ; Роскошный",
                languages = "Английский, Испанский",
                mainPhoto = photo58,
                photos = new List<Photo> { photo59, photo60 },
            };
            Hotel hotel21 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g31352-d74253-Reviews-Enchantment_Resort-Sedona_Arizona.html
                name = "Enchantment Resort",
                location = "525 Boynton Canyon Rd., Седона, AZ 86336-3042",
                phoneNumber = "810 1 844-948-3594",
                description = "Найти идеальный романтический курорт в Седоне не должно быть сложной задачей. Добро пожаловать в Энчантмент Резорт, прекрасный выбор для таких путешественников, как вы. Номера в Enchantment Hotel оборудованы ТВ с плоским экраном, кондиционером и мини-баром. Гости могут быть постоянно на связи благодаря бесплатному Интернету. К вашим услугам во время пребывания в Enchantment Hotel также бассейн и завтрак. Ищете, где оставить машину? Энчантмент Резорт предлагает бесплатная парковка предоставляется Расположенный близко к Palatki Ruins (4,4 км), популярной достопримечательности Седоны, Enchantment Resort превосходно подходит для туристов. Если вы ищете, где поесть поблизости, от курорта Enchantment Hotel можно пешком дойти до некоторых популярных ресторанов, включая View 180 (0,0 км), Che Ah Chi (0,0 км) и Tii Gavo (0,0 км). Если вы ищете, чем заняться, то можете посетить достопримечательность Boynton Canyon Trail (1,0 км) — она популярна среди туристов и до нее легко добраться пешком. Если вы остановитесь в Энчантмент Резорт, то все лучшее, что только есть в Седоне, будет у вас под рукой, и у вас останутся прекрасные впечатления от поездки.",
                hrefSite = "https://www.enchantmentresort.com/?utm_sourcetripadvisor&utm_mediumonline&utm_contentwebaddress&utm_campaigntripadvisor",
                countStars = 5,
                styleHotel = "Роскошный ; С красивым видом",
                languages = "Английский, Испанский",
                mainPhoto = photo61,
                photos = new List<Photo> { photo62, photo63 },
            };
            //7
            Hotel hotel22 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60763-d93520-Reviews-Park_Central_Hotel_New_York-New_York_City_New_York.html
                name = "Park Central Hotel New York",
                location = "870 Seventh Avenue at 56th Street, Нью-Йорк, NY 10019",
                phoneNumber = "810 1 646-603-0240",
                description = "Ищете, где остановиться в Нью-Йорке? Можете больше не искать. Тихий отель Парк Централ позволит вам познакомиться с Нью-Йорком наилучшим образом. Номера оборудованы ТВ с плоским экраном и кондиционером, гости могут в любой момент быть онлайн благодаря бесплатному Интернету. Здесь вы сможете хорошо отдохнуть и восстановить свои силы. Park Central Hotel New York предлагает услуги консьержа. Кроме того, гости Park Central Ny Hotel могут воспользоваться фитнес-центром и лобби. Гостям, приехавшим на машине, предоставляется парковка. Постояльцы отеля Park Central New York смогут посетить Love Sculpture (0,3 км) и Manhattan Skyline (1,8 км), одни из самых популярных достопримечательностей Нью-Йорка. Обязательно стоит сходить в один из популярных в Нью-Йорке ресторанов, где подают тапас. Buddakan, Tao и La Esquina расположены рядом с отелем Park Central New York Hotel. Если вы ищете, чем заняться, то посещение достопримечательностей Эмпайр стейт билдинг (1,8 км), Смотровая площадка в Рокфеллер-центре (0,6 км) и American Museum of Natural History (1,9 км) — это отличная возможность хорошо провести время. И до всех этих мест можно дойти пешком от отеля Парк Централ. Мы уверены, что Парк Централ вам понравится. Проживая здесь, вы сможете увидеть все, что Нью-Йорк предлагает гостям города.",
                hrefSite = "https://www.parkcentralny.com/?utm_source=TripAdvisor&utm_medium=BusinessListings&utm_campaign=websitelink&TAHotelCode=93520",
                countStars = 3,
                styleHotel = "Расположение в центре",
                languages = "Английский, Испанский",
                mainPhoto = photo64,
                photos = new List<Photo> { photo65, photo66 },
            };
            Hotel hotel23 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60763-d14149815-Reviews-Moxy_NYC_Chelsea-New_York_City_New_York.html
                name = "Moxy NYC Chelsea",
                location = "105 W 28th St, Нью-Йорк, NY 10001-6153",
                phoneNumber = "810 1 844-631-0595",
                hrefSite = "https://www.marriott.com/reservation/availabilitySearch.mi?isSearch=false&propertyCode=NYCOS&fromDate=10/19/2021&toDate=10/20/2021&numberOfRooms=1&numberOfGuests=2&scid=b661a3c4-9c47-48c8-9e13-75b66089dd79&utm_source=BA&pid=corptaba&dclid=CKvM2-Kas_ACFQHYGQodNv0PWA",
                countStars = 3,
                languages = "Английский",
                mainPhoto = photo67,
                photos = new List<Photo> { photo68, photo69 },
            };
            Hotel hotel24 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60763-d1149402-Reviews-The_Standard_East_Village-New_York_City_New_York.html
                name = "The Standard, East Village",
                location = "25 Cooper Sq, Нью-Йорк, NY 10003-7107",
                description = "Стандард, Ист Виладж — это отличный выбор для путешественников в Нью-Йорке. Это хорошее соотношение цены и качества, комфорта и удобства, романтической атмосферы и услуг, призванных сделать пребывание здесь очень приятным. Номера в Стандард, Ист Виладж оборудованы ТВ с плоским экраном, кондиционером и мини-баром, что обеспечивает исключительный комфорт и удобство. Гости могут всегда оставаться на связи благодаря бесплатному Wi-Fi. Круглосуточная стойка регистрации, услуги консьержа и обслуживание номеров — это лишь некоторые из услуг, предлагаемых в этом отеле. Ресторан сделает пребывание в отеле еще более приятным. К услугам тех, кто приехал в The Standard, East Village Hotel на машине, есть платная общественная парковка поблизости. Близкое расположение к одним из самых популярных достопримечательностей Нью-Йорка, таким как Эмпайр стейт билдинг (2,3 км) и One World Observatory (2,5 км), делает отель The Standard, East Village Hotel очень привлекательным для туристов. Во время пребывания в Нью-Йорке, возможно, вам захочется посетить некоторые рестораны рядом с The Standard, East Village Hotel, например Eleven Madison Park (1,6 км), Eataly (1,6 км) и Buddakan (2,0 км). И самое главное — проживая в отеле The Standard, East Village Hotel, вы легко сможете посетить многие великолепные достопримечательности Нью-Йорка, например Статуя Свободы, Национальный мемориал и музей 11 сентября (Мемориал 9/11) и The Oculus, которые являются популярными монументами. Мы уверены, что Стандард, Ист Виладж вам понравится. Проживая здесь, вы сможете увидеть все, что Нью-Йорк предлагает своим гостям.",
                countStars = 4,
                styleHotel = "С красивым видом ; Модный",
                languages = "Русский, Английский, Испанский, Голландский, Немецкий, Польский, Португальский, Шведский, Украинский",
                mainPhoto = photo70,
                photos = new List<Photo> { photo71, photo72 },
            };
            //8
            Hotel hotel25 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g45963-d91925-Reviews-ARIA_Resort_Casino-Las_Vegas_Nevada.html
                name = "ARIA Resort & Casino",
                location = "3730 Las Vegas Boulevard South, Лас-Вегас, NV 89158-4300",
                phoneNumber = "810 1 866-359-7757",
                description = "Ария Резорт & Казино — это отличный выбор для тех, кто приехал в Лас-Вегас. Это хорошее сочетание цены и качества, комфорта и удобства, романтической атмосферы и услуг, призванных сделать пребывание здесь очень приятным. Постояльцы отеля Ария Резорт & Казино смогут посетить T-Mobile Arena (0,5 км) и Bellagio Chocolate Fountain (0,6 км), одни из самых популярных достопримечательностей Лас-Вегаса. Aria Hotel предлагает гостям номера, оборудованные ТВ с плоским экраном, мини-баром и кондиционером. Гости в любой момент могут выйти в Сеть благодаря бесплатному Интернету. Отель предоставляет такие услуги, как услуги консьержа и обслуживание номеров, чтобы сделать пребывание здесь еще более приятным. Также к услугам гостей бассейн и завтрак. У гостей, приехавших на автомобиле, есть доступ к парковке. Путешественники, желающие отведать омаров, могут посетить Gordon Ramsay Steak, Top of the World или Wicked Spoon. Или можно сходить в ресторан морепродуктов, например The Buffet at Wynn, Top of the World или Bacchanal Buffet. Если вы ищете, чем заняться, то посещение достопримечательностей High Roller (1,4 км), The Strip (0,7 км) и Фонтаны Белладжио (0,6 км) — это отличная возможность хорошо провести время. И до всех этих мест можно дойти пешком от отеля Ария Резорт & Казино. Ваш комфорт и удовлетворение — это самое главное для сотрудников Ария Резорт & Казино. Они с нетерпением ждут вас в Лас-Вегасе.",
                hrefSite = "https://aria.mgmresorts.com/book-room/?checkIn=2021-10-19&checkOut=2021-10-20&dfaid=1&ecid=DI_BB_HO_TAV_ED_LV_AR_010121&guests=2&inbound_redirect=%2Fredirect%2Fhotel-stay-details%2F",
                countStars = 5,
                styleHotel = "Вид на город ; Модный",
                languages = "Английский, Французский, Испанский, Китайский, Японский",
                mainPhoto = photo73,
                photos = new List<Photo> { photo74, photo75 },
            };
            Hotel hotel26 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g45963-d91703-Reviews-Bellagio_Las_Vegas-Las_Vegas_Nevada.html
                name = "Bellagio Las Vegas",
                location = "3600 Las Vegas Blvd S, Лас-Вегас, NV 89109-4303",
                phoneNumber = "810 1 888-987-6667",
                description = "Найти идеальный романтический курорт в Лас-Вегасе не должно быть сложной задачей. Добро пожаловать в Беллагио Лас-Вегас, прекрасный выбор для таких путешественников, как вы. Номера оборудованы ТВ с плоским экраном, кондиционером и мини-баром, а выйти в Сеть в Bellagio Hotel очень просто благодаря бесплатному Интернету. Вы также можете воспользоваться следующими услугами, которые предлагает курорт: обслуживанием номеров и услугами консьержа. Кроме того, к услугам гостей есть бассейн и завтрак. Дополнительное удобство для гостей — парковка. Близкое расположение к одним из самых популярных достопримечательностей Лас-Вегаса, таким как Bellagio Chocolate Fountain (0,2 км) и Eiffel Tower Viewing Deck (0,3 км), делает курорт Bellagio Vegas очень привлекательным для туристов. Путешественники, желающие отведать тапас, могут посетить Wicked Spoon, Bacchanal Buffet или Beauty & Essex. Или можно сходить в тайский ресторан, например The Buffet at Aria, Tao Restaurant and Nightclub или Wazuzu. Если вы ищете, чем заняться, то посещение достопримечательностей High Roller (0,9 км), The Strip (0,2 км) и Фонтаны Белладжио (0,1 км) — это отличная возможность хорошо провести время. И до всех этих мест можно дойти пешком от курорта Bellagio Vegas. Если вы остановитесь в Беллагио Лас-Вегас, то все лучшее, что только есть в Лас-Вегасе, будет у вас под рукой, и у вас останутся прекрасные впечатления от поездки.",
                hrefSite = "https://bellagio.mgmresorts.com/book-room/?checkIn=2021-10-19&checkOut=2021-10-20&dfaid=1&ecid=DI_BB_HO_TAV_ED_LV_BE_010121&guests=2&inbound_redirect=%2Fredirect%2Fhotel-stay-details%2F",
                countStars = 5,
                styleHotel = "Расположение в центре ; Вид на город",
                languages = "Английский, Французский, Испанский, Китайский, Японский",
                mainPhoto = photo76,
                photos = new List<Photo> { photo77, photo78 },
            };
            Hotel hotel27 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g45963-d1829539-Reviews-The_Cosmopolitan_of_Las_Vegas_Autograph_Collection-Las_Vegas_Nevada.html
                name = "The Cosmopolitan of Las Vegas, Autograph Collection",
                location = "3708 Las Vegas Boulevard South, Лас-Вегас, NV 89109-4309",
                description = "Найти идеальный элитный отель в Лас-Вегасе не должно быть сложной задачей. Добро пожаловать в Космополитан Оф Лас-Вегас, прекрасный вариант для размещения подобных вам путешественников. Близость к таким достопримечательностям, как Bellagio Chocolate Fountain (0,3 км) и Eiffel Tower Viewing Deck (0,3 км), превращает отель The Cosmopolitan Of Las Vegas Hotel в отличное место для проживания во время посещения Лас-Вегаса. Номера оборудованы ТВ с плоским экраном, кондиционером и мини-баром, гости могут в любой момент быть онлайн благодаря бесплатному Интернету. Здесь вы сможете хорошо отдохнуть и восстановить свои силы. Космополитан Оф Лас-Вегас предлагает услуги консьержа, обслуживание в номер и террасу на крыше. Кроме того, гости Космополитан Оф Лас-Вегас могут воспользоваться бассейном и завтраком. Гостям, приехавшим на машине, предоставляется парковка. Во время пребывания в Лас-Вегасе, возможно, вам захочется посетить некоторые рестораны рядом с The Cosmopolitan Of Las Vegas Hotel, например Gordon Ramsay Steak (0,3 км), The Buffet at Bellagio (0,5 км) и Mon Ami Gabi (0,4 км). Если вы хотите лучше узнать Лас-Вегас, посетите некоторые из близлежащих достопримечательностей, например High Roller (1,0 км), The Strip (0,4 км) и Фонтаны Белладжио (0,3 км). Все они находятся всего в нескольких минутах ходьбы от отеля Космополитан Оф Лас-Вегас. Сотрудники Космополитан Оф Лас-Вегас с нетерпением ждут вас в Лас-Вегасе.",
                countStars = 5,
                styleHotel = "Модный ; С красивым видом",
                languages = "Английский, Испанский",
                mainPhoto = photo79,
                photos = new List<Photo> { photo80, photo81 },
            };
            Hotel hotel28 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g45963-d97704-Reviews-The_Venetian_Resort-Las_Vegas_Nevada.html
                name = "The Venetian Resort",
                location = "3355 Las Vegas Blvd S, Лас-Вегас, NV 89109-8941",
                phoneNumber = "810 1 833-394-6435",
                description = "Любой гость Лас-Вегаса в какой-то момент захочет отдохнуть. Венетиан Резорт Отель Казино — прекрасный выбор для тех, кто хочет восстановить силы. Это место хорошо известно своей романтической атмосферой и близостью к отличным ресторанам и достопримечательностям. Проживая в Венетиан Резорт Отель Казино, вы без труда увидите все лучшее, что предлагает Лас-Вегас. Номера оборудованы ТВ с плоским экраном, кондиционером и холодильником, а выйти в Сеть в Venetian Hotel Las Vegas очень просто благодаря бесплатному Интернету. Вы также можете воспользоваться следующими услугами, которые предлагает курорт: услугами консьержа и обслуживанием номеров. Кроме того, к услугам гостей есть бассейн и завтрак. Дополнительное удобство для гостей — бесплатная парковка. Близкое расположение к одним из самых популярных достопримечательностей Лас-Вегаса, таким как Mirage Volcano (0,3 км) и Marvel Avengers S.T.A.T.I.O.N. (0,4 км), делает курорт Venetian Hotel Las Vegas очень привлекательным для туристов. Во время пребывания в Лас-Вегасе обязательно сходите в самые популярные среди местных жителей места, где можно отведать буррито: The Cheesecake Factory, The Egg & I или Senor Frog's Las Vegas. Если вы ищете, чем заняться, то посещение достопримечательностей High Roller (0,4 км), The Strip (1,0 км) и Фонтаны Белладжио (1,1 км) — это отличная возможность хорошо провести время. И до всех этих мест можно дойти пешком от курорта Venetian Reviews. Venetian Las Vegas сделает ваше пребывание в Лас-Вегасе незабываемым.",
                hrefSite = "https://www.venetian.com/?utm_source=tripadvisor&utm_medium=partner&utm_campaign=website-link",
                countStars = 5,
                styleHotel = "Романтический ; Семейный курорт",
                languages = "Английский, Испанский, Китайский",
                mainPhoto = photo82,
                photos = new List<Photo> { photo83, photo84 },
            };
            //9
            Hotel hotel29 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g186338-d13126259-Reviews-Vintry_Mercer-London_England.html
                name = "Vintry & Mercer",
                location = "20 Garlick Hill, Лондон EC4V 2AU Англия",
                phoneNumber = "810 44 20 3908 8088",
                description = "Найти идеальный элитный отель в Лондоне не должно быть сложной задачей. Добро пожаловать в Vintry and Mercer, прекрасный вариант для размещения подобных вам путешественников. Расположенный близко к одним из самых популярных достопримечательностей Лондона, таким как Биг-Бен (2,3 км) и Ситуационный центр Черчилля (2,6 км), Vintry and Mercer превосходно подходит для туристов. Номера в Vintry and Mercer оборудованы мини-баром и кондиционером. Гости могут быть постоянно на связи благодаря бесплатному Wi-Fi. К вашим услугам во время пребывания в Vintry and Mercer также фитнес-центр и завтрак. предоставляется В Лондоне много индийских ресторанов. Поэтому во время поездки сюда обязательно сходите в такие популярные места, как Dishoom Covent Garden, Benares Restaurant & Bar и Dishoom Shoreditch, где подают великолепные блюда. Если вы хотите лучше узнать Лондон, посетите один из научных музеев, например Science Museum, Royal Air Force Museum London и The British Vintage Wireless and Television Museum. Сотрудники Vintry and Mercer с нетерпением ждут вас в Лондоне.",
                hrefSite = "https://secure.vintryandmercer.com/convert/site/Vintry%20and%20Mercer/en/results.php?checkin=2021-10-19&nights=1&currency=GBP&party=2",
                countStars = 4,
                languages = "Английский",
                mainPhoto = photo85,
                photos = new List<Photo> { photo86, photo87 },
            };
            Hotel hotel30 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g186338-d193105-Reviews-The_Landmark_London-London_England.html
                name = "The Landmark London",
                location = "222 Marylebone Road, Лондон NW1 6JQ Англия",
                description = "Ландмарк Лондон — это отличный выбор для тех, кто приехал в Лондон. Это хорошее сочетание цены и качества, комфорта и удобства, семейной атмосферы и услуг, призванных сделать пребывание здесь очень приятным. Близкое расположение к одним из самых популярных достопримечательностей Лондона, таким как Harrods (2,5 км) и Букингемский дворец (2,7 км), делает отель Ландмарк Лондон очень привлекательным для туристов. Гостям предоставляется бесплатный Wi-Fi. Номера в Landmark Hotel London оборудованы ТВ с плоским экраном, холодильником и кондиционером. Во время пребывания здесь воспользуйтесь такими услугами, как услуги консьержа и обслуживание номеров. К услугам гостей Ландмарк Лондон также бассейн и завтрак. Путешественники, приехавшие на машине, могут воспользоваться парковкой. Обязательно стоит сходить в один из популярных в Лондоне ресторанов, где подают рыбу с картофелем-фри. Sketch Gallery, The Ivy и Rules Restaurant расположены рядом с отелем The Landmark London Hotel. Если вы ищете, чем заняться, то посещение достопримечательностей Гайд-Парк (1,6 км), Primrose Hill (1,9 км) и Abbey Road Studios (1,6 км) — это отличная возможность хорошо провести время. И до всех этих мест можно дойти пешком от отеля Landmark London. Ваш комфорт и удовлетворение — это самое главное для сотрудников Ландмарк Лондон. Они с нетерпением ждут вас в Лондоне.",
                countStars = 5,
                styleHotel = "Классический ; Роскошный",
                languages = "Английский, Итальянский",
                mainPhoto = photo88,
                photos = new List<Photo> { photo89, photo90 },
            };
            
            dataBase.hotels.AddRange(hotel1, hotel2, hotel3, hotel4, hotel5, hotel6, hotel7, hotel8, hotel9, hotel10, hotel11, hotel12, hotel13, hotel14, hotel15, hotel16, hotel17, hotel18, hotel19, hotel20, hotel21, hotel22, hotel23, hotel24, hotel25, hotel26, hotel27, hotel28, hotel29, hotel30);
            dataBase.SaveChanges();
        }

        public void createRestaurant()
        {
            Photo photo1 = new Photo {image = Util.getByteImage(@"wwwroot\img\lorenzillos.jpg"), name = @"img\lorenzillos.jpg"};
            Photo photo2 = new Photo {image = Util.getByteImage(@"wwwroot\img\lorenzillos1.jpg"), name = @"img\lorenzillos1.jpg"};
            Photo photo3 = new Photo {image = Util.getByteImage(@"wwwroot\img\lorenzillos2.jpg"), name = @"img\lorenzillos2.jpg"};
            Photo photo4 = new Photo {image = Util.getByteImage(@"wwwroot\img\Taqueria-Coapenitos.jpg"), name = @"img\Taqueria-Coapenitos.jpg"};
            Photo photo5 = new Photo {image = Util.getByteImage(@"wwwroot\img\Taqueria-Coapenitos1.jpg"), name = @"img\Taqueria-Coapenitos1.jpg"};
            Photo photo6 = new Photo {image = Util.getByteImage(@"wwwroot\img\Taqueria-Coapenitos2.jpg"), name = @"img\Taqueria-Coapenitos2.jpg"};
            Photo photo7 = new Photo {image = Util.getByteImage(@"wwwroot\img\les-cepages-restaurant.jpg"), name = @"img\les-cepages-restaurant.jpg"};
            Photo photo8 = new Photo {image = Util.getByteImage(@"wwwroot\img\les-cepages-restaurant1.jpg"), name = @"img\les-cepages-restaurant1.jpg"};
            Photo photo9 = new Photo {image = Util.getByteImage(@"wwwroot\img\les-cepages-restaurant2.jpg"), name = @"img\les-cepages-restaurant2.jpg"};
            Photo photo10 = new Photo {image = Util.getByteImage(@"wwwroot\img\Porfirio1.jpg"), name = @"img\Porfirio's-Cancún.jpg"};
            Photo photo11 = new Photo {image = Util.getByteImage(@"wwwroot\img\Porfirio3.jpg"), name = @"img\Porfirio's-Cancún1.jpg"};
            Photo photo12 = new Photo {image = Util.getByteImage(@"wwwroot\img\Porfirio2.jpg"), name = @"img\Porfirio's-Cancún2.jpg"};

            Photo photo13 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn.jpg"), name = @"img\old-faithful-inn.jpg"};
            Photo photo14 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn1.jpg"), name = @"img\old-faithful-inn1.jpg"};
            Photo photo15 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn2.jpg"), name = @"img\old-faithful-inn2.jpg"};
            Photo photo16 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge-Cabins.jpg"), name = @"img\Roosevelt-Lodge-Cabins.jpg"};
            Photo photo17 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge-Cabins1.jpg"), name = @"img\Roosevelt-Lodge-Cabins1.jpg"};
            Photo photo18 = new Photo {image = Util.getByteImage(@"wwwroot\img\roosevelt-lodge-cabins2.jpg"), name = @"img\roosevelt-lodge-cabins2.jpg"};
            Photo photo19 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground.jpg"), name = @"img\madison-campground.jpg"};
            Photo photo20 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground1.jpg"), name = @"img\madison-campground1.jpg"};
            Photo photo21 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground2.jpg"), name = @"img\madison-campground2.jpg"};
            Photo photo22 = new Photo {image = Util.getByteImage(@"wwwroot\img\sanctuary-cap-cana-aerial.jpg"), name = @"img\sanctuary-cap-cana-aerial.jpg"};
            Photo photo23 = new Photo {image = Util.getByteImage(@"wwwroot\img\sanctuary-cap-cana-aerial1.jpg"), name = @"img\sanctuary-cap-cana-aerial1.jpg"};
            Photo photo24 = new Photo {image = Util.getByteImage(@"wwwroot\img\sanctuary-cap-cana-aerial2.jpg"), name = @"img\sanctuary-cap-cana-aerial2.jpg"};
            Photo photo25 = new Photo {image = Util.getByteImage(@"wwwroot\img\Zoetry-Agua-Punta-Cana.jpg"), name = @"img\Zoetry-Agua-Punta-Cana.jpg" };
            Photo photo26 = new Photo {image = Util.getByteImage(@"wwwroot\img\Zoetry-Agua-Punta-Cana1.jpg"), name = @"img\Zoetry-Agua-Punta-Cana1.jpg" };
            Photo photo27 = new Photo {image = Util.getByteImage(@"wwwroot\img\Zoetry-Agua-Punta-Cana2.jpg"), name = @"img\Zoetry-Agua-Punta-Cana2.jpg" };
            Photo photo28 = new Photo {image = Util.getByteImage(@"wwwroot\img\Excellence-Punta-Cana.jpg"), name = @"img\Excellence-Punta-Cana.jpg" };
            Photo photo29 = new Photo {image = Util.getByteImage(@"wwwroot\img\Excellence-Punta-Cana1.jpg"), name = @"img\Excellence-Punta-Cana1.jpg" };
            Photo photo30 = new Photo {image = Util.getByteImage(@"wwwroot\img\Excellence-Punta-Cana2.jpg"), name = @"img\Excellence-Punta-Cana2.jpg" };
            Photo photo31 = new Photo { image = Util.getByteImage(@"wwwroot\img\Royalton-Punta-Cana-Resort.jpg"), name = @"img\Royalton-Punta-Cana-Resort.jpg" };
            Photo photo32 = new Photo { image = Util.getByteImage(@"wwwroot\img\Royalton-Punta-Cana-Resort1.jpg"), name = @"img\Royalton-Punta-Cana-Resort1.jpg" };
            Photo photo33 = new Photo { image = Util.getByteImage(@"wwwroot\img\Royalton-Punta-Cana-Resort2.jpg"), name = @"img\Royalton-Punta-Cana-Resort2.jpg" };
            Photo photo34 = new Photo { image = Util.getByteImage(@"wwwroot\img\Hotel-Wailea.jpg"), name = @"img\Hotel-Wailea.jpg" };
            Photo photo35 = new Photo { image = Util.getByteImage(@"wwwroot\img\Hotel-Wailea1.jpg"), name = @"img\Hotel-Wailea1.jpg" };
            Photo photo36 = new Photo { image = Util.getByteImage(@"wwwroot\img\Hotel-Wailea2.jpg"), name = @"img\Hotel-Wailea2.jpg" };
            Photo photo37 = new Photo { image = Util.getByteImage(@"wwwroot\img\hana-maui-resort.jpg"), name = @"img\hana-maui-resort.jpg" };
            Photo photo38 = new Photo { image = Util.getByteImage(@"wwwroot\img\hana-maui-resort1.jpg"), name = @"img\hana-maui-resort1.jpg" };
            Photo photo39 = new Photo { image = Util.getByteImage(@"wwwroot\img\hana-maui-resort2.jpg"), name = @"img\hana-maui-resort2.jpg" };
            Photo photo40 = new Photo { image = Util.getByteImage(@"wwwroot\img\andaz-maui-at-wailea.jpg"), name = @"img\andaz-maui-at-wailea.jpg" };
            Photo photo41 = new Photo { image = Util.getByteImage(@"wwwroot\img\andaz-maui-at-wailea1.jpg"), name = @"img\andaz-maui-at-wailea1.jpg" };
            Photo photo42 = new Photo { image = Util.getByteImage(@"wwwroot\img\andaz-maui-at-wailea2.jpg"), name = @"img\andaz-maui-at-wailea2.jpg" };
            Photo photo43 = new Photo { image = Util.getByteImage(@"wwwroot\img\disney-s-animal-kingdom.jpg"), name = @"img\disney-s-animal-kingdom.jpg" };
            Photo photo44 = new Photo { image = Util.getByteImage(@"wwwroot\img\disney-s-animal-kingdom1.jpg"), name = @"img\disney-s-animal-kingdom1.jpg" };
            Photo photo45 = new Photo { image = Util.getByteImage(@"wwwroot\img\disney-s-animal-kingdom2.jpg"), name = @"img\disney-s-animal-kingdom2.jpg" };
            Photo photo46 = new Photo { image = Util.getByteImage(@"wwwroot\img\hilton-orlando-bonnet.jpg"), name = @"img\hilton-orlando-bonnet.jpg" };
            Photo photo47 = new Photo { image = Util.getByteImage(@"wwwroot\img\hilton-orlando-bonnet1.jpg"), name = @"img\hilton-orlando-bonnet1.jpg" };
            Photo photo48 = new Photo { image = Util.getByteImage(@"wwwroot\img\hilton-orlando-bonnet2.jpg"), name = @"img\hilton-orlando-bonnet2.jpg" };
            Photo photo49 = new Photo { image = Util.getByteImage(@"wwwroot\img\four-seasons-resort-orlando.jpg"), name = @"img\four-seasons-resort-orlando.jpg" };
            Photo photo50 = new Photo { image = Util.getByteImage(@"wwwroot\img\four-seasons-resort-orlando1.jpg"), name = @"img\four-seasons-resort-orlando1.jpg" };
            Photo photo51 = new Photo { image = Util.getByteImage(@"wwwroot\img\four-seasons-resort-orlando2.jpg"), name = @"img\four-seasons-resort-orlando2.jpg" };
            Photo photo52 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-alfond-inn.jpg"), name = @"img\the-alfond-inn.jpg" };
            Photo photo53 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-alfond-inn1.jpg"), name = @"img\the-alfond-inn1.jpg" };
            Photo photo54 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-alfond-inn2.jpg"), name = @"img\the-alfond-inn2.jpg" };
            Photo photo55 = new Photo { image = Util.getByteImage(@"wwwroot\img\el-portal-sedona-hotel.jpg"), name = @"img\el-portal-sedona-hotel.jpg" };
            Photo photo56 = new Photo { image = Util.getByteImage(@"wwwroot\img\el-portal-sedona-hotel1.jpg"), name = @"img\el-portal-sedona-hotel1.jpg" };
            Photo photo57 = new Photo { image = Util.getByteImage(@"wwwroot\img\el-portal-sedona-hotel2.jpg"), name = @"img\el-portal-sedona-hotel2.jpg" };
            Photo photo58 = new Photo { image = Util.getByteImage(@"wwwroot\img\Auberge-de-Sedona.jpg"), name = @"img\Auberge-de-Sedona.jpg" };
            Photo photo59 = new Photo { image = Util.getByteImage(@"wwwroot\img\Auberge-de-Sedona1.jpg"), name = @"img\Auberge-de-Sedona1.jpg" };
            Photo photo60 = new Photo { image = Util.getByteImage(@"wwwroot\img\Auberge-de-Sedona2.jpg"), name = @"img\Auberge-de-Sedona2.jpg" };
            Photo photo61 = new Photo { image = Util.getByteImage(@"wwwroot\img\enchantment-resort.jpg"), name = @"img\enchantment-resort.jpg" };
            Photo photo62 = new Photo { image = Util.getByteImage(@"wwwroot\img\enchantment-resort1.jpg"), name = @"img\enchantment-resort1.jpg" };
            Photo photo63 = new Photo { image = Util.getByteImage(@"wwwroot\img\enchantment-resort2.jpg"), name = @"img\enchantment-resort2.jpg" };
            Photo photo64 = new Photo { image = Util.getByteImage(@"wwwroot\img\park-central.jpg"), name = @"img\park-central.jpg" };
            Photo photo65 = new Photo { image = Util.getByteImage(@"wwwroot\img\park-central1.jpg"), name = @"img\park-central1.jpg" };
            Photo photo66 = new Photo { image = Util.getByteImage(@"wwwroot\img\park-central2.jpg"), name = @"img\park-central2.jpg" };
            Photo photo67 = new Photo { image = Util.getByteImage(@"wwwroot\img\Moxy-NYC-Chelsea.jpg"), name = @"img\Moxy-NYC-Chelsea.jpg" };
            Photo photo68 = new Photo { image = Util.getByteImage(@"wwwroot\img\Moxy-NYC-Chelsea1.jpg"), name = @"img\Moxy-NYC-Chelsea1.jpg" };
            Photo photo69 = new Photo { image = Util.getByteImage(@"wwwroot\img\Moxy-NYC-Chelsea2.jpg"), name = @"img\Moxy-NYC-Chelsea2.jpg" };
            Photo photo70 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Standard.jpg"), name = @"img\The-Standard.jpg" };
            Photo photo71 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Standard1.jpg"), name = @"img\The-Standard1.jpg" };
            Photo photo72 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Standard2.jpg"), name = @"img\The-Standard2.jpg" };
            Photo photo73 = new Photo { image = Util.getByteImage(@"wwwroot\img\aria.jpg"), name = @"img\aria.jpg" };
            Photo photo74 = new Photo { image = Util.getByteImage(@"wwwroot\img\aria1.jpg"), name = @"img\aria1.jpg" };
            Photo photo75 = new Photo { image = Util.getByteImage(@"wwwroot\img\aria2.jpg"), name = @"img\aria2.jpg" };
            Photo photo76 = new Photo { image = Util.getByteImage(@"wwwroot\img\bellagio-las-vegas.jpg"), name = @"img\bellagio-las-vegas.jpg" };
            Photo photo77 = new Photo { image = Util.getByteImage(@"wwwroot\img\bellagio-las-vegas1.jpg"), name = @"img\bellagio-las-vegas1.jpg" };
            Photo photo78 = new Photo { image = Util.getByteImage(@"wwwroot\img\bellagio-las-vegas2.jpg"), name = @"img\bellagio-las-vegas2.jpg" };
            Photo photo79 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cosmopolitan.jpg"), name = @"img\Cosmopolitan.jpg" };
            Photo photo80 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cosmopolitan1.jpg"), name = @"img\Cosmopolitan1.jpg" };
            Photo photo81 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cosmopolitan2.jpg"), name = @"img\Cosmopolitan2.jpg" };
            Photo photo82 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-venetian-las-vegas.jpg"), name = @"img\the-venetian-las-vegas.jpg" };
            Photo photo83 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-venetian-las-vegas1.jpg"), name = @"img\the-venetian-las-vegas1.jpg" };
            Photo photo84 = new Photo { image = Util.getByteImage(@"wwwroot\img\the-venetian-las-vegas2.jpg"), name = @"img\the-venetian-las-vegas2.jpg" };
            Photo photo85 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vintry-&-Mercer.jpg"), name = @"img\Vintry-&-Mercer.jpg" };
            Photo photo86 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vintry-&-Mercer1.jpg"), name = @"img\Vintry-&-Mercer1.jpg" };
            Photo photo87 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vintry-&-Mercer2.jpg"), name = @"img\Vintry-&-Mercer2.jpg" };
            Photo photo88 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Landmark-London.jpg"), name = @"img\The-Landmark-London.jpg" };
            Photo photo89 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Landmark-London1.jpg"), name = @"img\The-Landmark-London1.jpg" };
            Photo photo90 = new Photo { image = Util.getByteImage(@"wwwroot\img\The-Landmark-London2.jpg"), name = @"img\The-Landmark-London2.jpg" };
            
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12, photo13, photo14, photo15, photo16, photo17, photo18, photo19, photo20, photo21, photo22, photo23, photo24, photo25, photo26, photo27, photo28, photo29, photo30, photo31, photo32, photo33, photo34, photo35, photo36, photo37, photo38, photo39, photo40, photo41, photo42, photo43, photo44, photo45, photo46, photo47, photo48, photo49, photo50, photo51, photo52, photo53, photo54, photo55, photo56, photo57, photo58, photo59, photo60, photo61, photo62, photo63, photo64, photo65, photo66, photo67, photo68, photo69, photo70, photo71, photo72, photo73, photo74, photo75, photo76, photo77, photo78, photo79, photo80, photo81, photo82, photo83, photo84, photo85, photo86, photo87, photo88, photo89, photo90);
            

            //direction 6 Канкун, Мексика
            Restaurant restaurant1 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g150807-d787079-Reviews-Lorenzillo_s-Cancun_Yucatan_Peninsula.html
                name = "Lorenzillo's",
                location = "Blvd. Kukulcan km 10.5 Zona Hotelera, Канкун 77500 Мексика",
                phone = "+52 998 883 1254",
                webSite = "http://www.lorenzillos.com.mx/",
                typeCuisine = "Карибская, Морепродукты, Супы",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                mainPhoto = photo1,
                photos = new List<Photo> {photo2, photo3},
            };
            Restaurant restaurant2 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g150807-d9726218-Reviews-Taqueria_Coapenitos-Cancun_Yucatan_Peninsula.html
                name = "Taqueria Coapenitos",
                location = "Av Nader No.25 Edificio Tapachula SM 02, Канкун 77500 Мексика",
                phone = "+52 998 415 4227",
                typeCuisine = "Мексиканская, Латиноамериканская, Бар",
                specialMenu = "Подходит для вегетарианцев",
                mainPhoto = photo4,
                photos = new List<Photo> {photo5, photo6},
            };
            Restaurant restaurant3 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g150807-d3378512-Reviews-Les_Cepages_Restaurant-Cancun_Yucatan_Peninsula.html
                name = "Les Cepages Restaurant",
                location = "Av. Nichupté Sm 16 Plaza Nichupté Local 15, Канкун 77505 Мексика",
                phone = "+52 998 802 1093",
                webSite = "https://www.facebook.com/RestLesCepages/",
                typeCuisine = "Французская, Европейская, Современная, Международная",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                mainPhoto = photo7,
                photos = new List<Photo> {photo8, photo9},
            };
            Restaurant restaurant4 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g150807-d8002763-Reviews-Porfirio_s_Cancun-Cancun_Yucatan_Peninsula.html
                name = "Porfirio's Cancún",
                location = "Boulevard Kukulcan 14. 2 No. 1 Zona Hotelera, Канкун 77504 Мексика",
                phone = "+52 998 840 6040",
                webSite = "https://porfirios.com.mx/restaurante-mexicano-en-cancun",
                typeCuisine = "Мексиканская, Латиноамериканская, Современная",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                mainPhoto = photo10,
                photos = new List<Photo> {photo11, photo12},
            };

            //1
             Restaurant restaurant1 = new Restaurant
            {
                //
                name = "",
                location = "",
                phone = "",
                webSite = "",
                typeCuisine = "",
                specialMenu = "",
                mainPhoto = photo1,
                photos = new List<Photo> {photo2, photo3},
            };
            dataBase.restaurants.AddRange(restaurant1, restaurant2, restaurant3, restaurant4);
            dataBase.SaveChanges();
        }
    }
}