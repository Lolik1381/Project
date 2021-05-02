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
            createUser();
            createReview();
            createLandmark();
            createHotel();
            createRestaurant();
            createDirection();
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
                photos = new List<Photo> { photo23 },
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
                description = "Пунта-Кана — это потрясающее место и настоящий источник самых разных удовольствий. Вы можете начать свой день на будто сошедшем с открыток пляже Макао, а закончить в ночном клубе в пещере. А когда Вы не нежитесь на солнце и не танцуете всю ночь напролет, каждую минуту Вас ждут другие развлечения, которые предлагают безупречные курорты Пунта-Каны, работающие по системе все включено, от потрясающего Hard Rock Punta Cana до безмятежного и уединенного Le Sivory Punta Cana. Насладившись теплым солнцем и белоснежным песком, попробуйте один из местных маршрутов канатного спуска, отправьтесь на остров Саона, познакомьтесь с историей Доминиканы в Альтос-де-Чавоне и посетите волшебные лагуны экологического парка Indigenous Eyes."
            };
            Direction direction3 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Hana Highway - Road to Hana")).Single()
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
                    dataBase.landmarks.Where(l => l.name.Equals("Центральный парк")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Пляж Playa Delfines")).Single()
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

/*            Photo photo13 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn.jpg"), name = @"img\old-faithful-inn.jpg"};
            Photo photo14 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn1.jpg"), name = @"img\old-faithful-inn1.jpg"};
            Photo photo15 = new Photo {image = Util.getByteImage(@"wwwroot\img\old-faithful-inn2.jpg"), name = @"img\old-faithful-inn2.jpg"};
            Photo photo16 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge-Cabins.jpg"), name = @"img\Roosevelt-Lodge-Cabins.jpg"};
            Photo photo17 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge-Cabins1.jpg"), name = @"img\Roosevelt-Lodge-Cabins1.jpg"};
            Photo photo18 = new Photo {image = Util.getByteImage(@"wwwroot\img\roosevelt-lodge-cabins2.jpg"), name = @"img\roosevelt-lodge-cabins2.jpg"};
            Photo photo19 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground.jpg"), name = @"img\madison-campground.jpg"};
            Photo phot20 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground1.jpg"), name = @"img\madison-campground1.jpg"};
            Photo photo21 = new Photo {image = Util.getByteImage(@"wwwroot\img\madison-campground2.jpg"), name = @"img\madison-campground2.jpg"};*/

            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12, photo13, photo14, photo15, photo16, photo17, photo18, photo19, photo20, photo21);
            
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
            Hotel hotel5 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60999-d220121-Reviews-Old_Faithful_Inn-Yellowstone_National_Park_Wyoming.html
                name = "Old Faithful Inn",
                location = "3200 Old Faithful Inn Rd, Йеллоустонский национальный парк, WY 82190",
                countStars = 2,
                languages = "Английский",
                mainPhoto = photo13,
                photos = new List<Photo> {photo14, photo15},
            };
            Hotel hotel6 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g60999-d220052-Reviews-Roosevelt_Lodge_Cabins-Yellowstone_National_Park_Wyoming.html
                name = "Roosevelt Lodge Cabins",
                location = "100 Roosevelt Lodge Rd, Йеллоустонский национальный парк, WY 82190",
                countStars = 2,
                languages = "Английский",
                mainPhoto = photo16,
                photos = new List<Photo> {photo17, photo18},
            };

            //direction1
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
                photos = new List<Photo> {photo23, photo24},
            };
            Hotel hotel9 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g150807-d154868-Reviews-Le_Blanc_Spa_Resort_Cancun-Cancun_Yucatan_Peninsula.html
                name = "Le Blanc Spa Resort Cancun",
                location = "Boulevard Kukulcan Km 10 Zona Hotelera, Канкун 77550 Мексика",
                phoneNumber = "810 1 888-205-9375",
                description = "Ищете романтический курорт все включено в Канкуне? Можете больше не искать. Ле Бланк Спа Резорт подойдет вам наилучшим образом. Учитывая близкое расположение таких популярных достопримечательностей, как Scorpion’s Temple (1,9 км) и Avenida Kukulkan (2,9 км), гости курорта \"все включено\" Le Blanc без труда смогут посетить одни из самых известных мест Канкуна. Номера оборудованы ТВ с плоским экраном, кондиционером и мини-баром, а гости могут в любой момент быть онлайн благодаря бесплатному Wi-Fi, который предлагает курорт все включено. Le Blanc Resort предлагает обслуживание в номер и услуги консьержа, чтобы сделать пребывание гостей здесь еще более приятным. К услугам гостей также бассейн и бесплатный завтрак. Те, кто приезжает в Ле Бланк Спа Резорт на машине, могут воспользоваться бесплатной парковкой. Если вы любите итальянские рестораны, курорт все включено Le Blanc удобно расположен рядом с Casa Rolandi, Limoncello и Restaurante Chianti. Во время своей поездки обязательно посетите популярные художественные галереи, например Antaras Onix и Galeria Balance Cancun, расположенные в шаговой доступности от курорта все включено. Сотрудники Ле Бланк Спа Резорт с нетерпением вас ждут. Вы будете приятно удивлены уровнем обслуживания.",
                hrefSite = "https://www.leblancsparesorts.com/cancun/en/offers",
                countStars = 5,
                styleHotel = "С видом на океан ; Роскошный",
                languages = "Английский, Испанский",
                mainPhoto = photo7,
                photos = new List<Photo> {photo8, photo9},
            };
            Hotel hotel10 = new Hotel
            {
                //https://www.tripadvisor.ru/Hotel_Review-g150807-d154868-Reviews-Le_Blanc_Spa_Resort_Cancun-Cancun_Yucatan_Peninsula.html
                name = "Le Blanc Spa Resort Cancun",
                location = "Boulevard Kukulcan Km 10 Zona Hotelera, Канкун 77550 Мексика",
                phoneNumber = "810 1 888-205-9375",
                description = "Ищете романтический курорт все включено в Канкуне? Можете больше не искать. Ле Бланк Спа Резорт подойдет вам наилучшим образом. Учитывая близкое расположение таких популярных достопримечательностей, как Scorpion’s Temple (1,9 км) и Avenida Kukulkan (2,9 км), гости курорта \"все включено\" Le Blanc без труда смогут посетить одни из самых известных мест Канкуна. Номера оборудованы ТВ с плоским экраном, кондиционером и мини-баром, а гости могут в любой момент быть онлайн благодаря бесплатному Wi-Fi, который предлагает курорт все включено. Le Blanc Resort предлагает обслуживание в номер и услуги консьержа, чтобы сделать пребывание гостей здесь еще более приятным. К услугам гостей также бассейн и бесплатный завтрак. Те, кто приезжает в Ле Бланк Спа Резорт на машине, могут воспользоваться бесплатной парковкой. Если вы любите итальянские рестораны, курорт все включено Le Blanc удобно расположен рядом с Casa Rolandi, Limoncello и Restaurante Chianti. Во время своей поездки обязательно посетите популярные художественные галереи, например Antaras Onix и Galeria Balance Cancun, расположенные в шаговой доступности от курорта все включено. Сотрудники Ле Бланк Спа Резорт с нетерпением вас ждут. Вы будете приятно удивлены уровнем обслуживания.",
                hrefSite = "https://www.leblancsparesorts.com/cancun/en/offers",
                countStars = 5,
                styleHotel = "С видом на океан ; Роскошный",
                languages = "Английский, Испанский",
                mainPhoto = photo7,
                photos = new List<Photo> {photo8, photo9},
            };

            dataBase.hotels.AddRange(hotel1, hotel2, hotel3, hotel4, hotel5, hotel6, hotel7);
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
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12);

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

            dataBase.restaurants.AddRange(restaurant1, restaurant2, restaurant3, restaurant4);
            dataBase.SaveChanges();
        }
    }
}