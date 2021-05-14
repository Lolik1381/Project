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
            Photo photo4 = new Photo { image = Util.getByteImage(@"wwwroot\img\defaultUserAccountImage.jpg"), name = "defaultUserAccountImage" };
            Photo photo5 = new Photo { image = Util.getByteImage(@"wwwroot\img\maxresdefault3.jpg"), name = "defaultLoginImage" };
            Photo photo6 = new Photo { image = Util.getByteImage(@"wwwroot\img\TRIP-2.png"), name = "defaultSityImage" };
            Photo photo7 = new Photo { image = Util.getByteImage(@"wwwroot\img\maxresdefault4.jpg"), name = "defaultRegisterImage" };
            Photo photo8 = new Photo { image = Util.getByteImage(@"wwwroot\img\maxresdefault5.jpg"), name = "defaultAdditionalInformationImage" };
            Photo photo9 = new Photo { image = Util.getByteImage(@"wwwroot\img\aboutme.png"), name = "aboutMeIcon" };
            Photo photo10 = new Photo { image = Util.getByteImage(@"wwwroot\img\plus.png"), name = "plusIcon" };
            Photo photo11 = new Photo { image = Util.getByteImage(@"wwwroot\img\iconAdress.png"), name = "adressIcon" };

            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11);
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
                name = "Никита",
                lastName = "Русаков",
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
            #region Las Vegas
            //direction8 Las Vegas
            //landmark 16 Bellagio Conservatory & Botanical Garden
            Review review4 = new Review
            {
                user = dataBase.users
                    .Include(user => user.profile)
                    .Where(user => user.profile.name.Equals("Юлия"))
                    .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Ночная экскурсия по отелям Вегаса",
                rating = 5,
                description = "Каждый отель на Strip имеет свою фишку. В Белладжио это зоосад огромной высоты с гигантскими моделями животных, а также самый большой в мире шоколадный водопад."
            };
            Review review5 = new Review
            {
                user = dataBase.users
                    .Include(user => user.profile)
                    .Where(user => user.profile.name.Equals("Никита"))
                    .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Красота да и только",
                rating = 5,
                description = "Останавливался в отеле Bellagio Las Vegas в июне 2019 года на 5 ночей. Эту экспозицию строили, что называется , на моих глазах и за это время она полностью была построена-круто!"
            };
            //landmark15 The Strip
            Review review6 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Михаил"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Впечатляет",
                rating = 5,
                description = "Самая центральная улица Лас-Вегаса, надо жить и гулять по ней. Здесь находятся отели, повторяющие достопримечательности основных городов мира. Много ресторанов, кафе, есть торговые центры. Удобней проехать ее всю на автобусе."
            };
            Review review7 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Anastasia"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Fun but expensive",
                rating = 3,
                description = "The tickets and room were decently priced, bit then getting there......Room fees and taxes add up, alcoholic drinks doubled in price in the last 2 years, food was more expensive too.. The cabanas at the pools were $400 a day, and water and ice were not even free. If you think you can go for a decently cheap trip to Vegas anymore, you cannot."
            };
            //landmark24 The Neon Museum
            Review review8 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Юлия"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Разочаровательно",
                rating = 3,
                description = "Очень хотели попасть в музей неона и фотографировать тысячи светящихся старых вывесок. Представляли классные колоритные огненные фотки. И вот мы залетаем на территорию, а там... тьма. В музее неона светятся 3 крошечные вывески из тысячи! Это настолько не логично, что даже разочаровательно. Так что, если что вдруг, приезжайте днём - тут хотя бы цвета красивые, наверное. А ночью просто свалка. И лучше бронируйте заранее, на официальном сайте, потому что билеты раскуплены на неделю вперёд"
            };
            Review review9 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Никита"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Очень атмосферно!",
                rating = 5,
                description = "Очень атмосферный отель - можно отлично проследить историю Вегаса по всем этим старым неоновым вывескам. Есть какая-то магия в них.Нам очень понравилось !"
            };
            
            //ARIA Resort & Casino
            Review review10 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Юлия"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Отличный отель",
                rating = 5,
                description = "Все условия для комфортного отдыха. Отличные номера, отличная инфраструктура, отличное казино, неплохой бассейн, великолепный тренажерный зал. Непонятно, почему парковка платная, в остальном супер. Очень вкусный ресторан итальянский Корбома, рекомендуем"
            };
            Review review11 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Михаил"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Превосходный отель",
                rating = 5,
                description = "Начиная с 1994 года отели выбирали по ходу движения по стрипу с юга на север. Exalubur, New York, Monte Carlo (сейчас MGM Park) и наконец современнейший Aria. Все очень достойно, удобно, красиво, автоматизировано в номерах, но немного дороговато. Вода Fiji в номере за $35 это просто смешно. Надо быть аккуратнее с минибаром. Вытащив оттуда бутылку и рассматривая этикетку более 60 секунд, вы автоматически становитесь ее покупателем независимо от того открывали вы ее или нет. Через два дня после выезда из отеля с меня списали $38 за пользование минибаром. Пришлось разбираться через обратную связь с отелем."
            };
            //Bellagio Las Vegas
            Review review12 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Михаил"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Bellagio - вегасовская классика",
                rating = 4,
                description = "Номера довольно старые, несмотря на вcю крутизну и пафос, витающий в Bellagio. В номере, который нам достался, было просто невозможно отыскать место где можно было бы зарядить телефон и при этом находится в сидячем/лежачем положении, розетки расположены очень неудобно. Также в номере была дверь в смежную комнату, что лично меня всегда сильно напрягает, так как от шума из соседнего номера никак не избавится, особенно когда там включают телевизор. А это не совсем то, чего ожидаешь от номера за такие деньги"
            };
            //The Cosmopolitan of Las Vegas, Autograph Collection
            Review review13 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Юлия"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Крепкая 4-ка",
                rating = 4,
                description = "Отель недавно отремонтирован. У нас был Терасса Сьют на 61 этаже, просторный и уютный, с балконом. К номеру почти претензий нет, кроме двух - постоянно включающая самовольно джакузи посредине ночи, и аналогичная ситуация происходила со светом в гардеробной. Будьте готовы к отсутствию чайника и сейфа... Отсутствует отдельная очередь на чек-аут, мы выезжали в пятницу, когда был наплыв на чек-ин и пришлось простоять всю эту очередь. Неоправданно большой депозит за 3 ночи - 40к рублей, если учесть что у нас была оплаченная полностью бронь"
            };
            Review review14 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Станислав"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Неплохо",
                rating = 3,
                description = "Останавливались в этом отеле в 3 раз,но предидущие разы было лучше.В этот раз,наш номер оказался без вида на фонтаны.Это было неожиданно.Плохо работал кондиционер и уборка была сделана не вполне качественно - волосы и резинка для волос на полке так и остались лежать от прошлых гостей.Но главный кошмар - это завтрак.Вроде всего много,а есть нечего и все без вкуса.Один человек только не ресепшн и оплату берут до поэтому очереди. За кофе надо ещё отдельно платить"
            };
            //The Venetian Resort
            Review review15 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Никита"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Отличный пафосный отель",
                rating = 5,
                description = "В отель приехали на автомобиле из Лос-Анджелеса 31.12.2019, спокойно нашли свободное место на подземной парковке отеля. Для создания прекрасного новогоднего настроения был забронирован Сьюит на высоком этаже. Вид из номера позволял смотреть новогодний салют! Номер огромный - с двумя двуспальными кроватями, полноценным диваном, большой ванной. Новогодний праздничный стол заказали в их ресторане прямо в номер. Официант был очень внимателен, а ужин оказался очень вкусным! Отель огромный, людей - очень много, но так как для каждого уровня этажей сделаны свои лифты, то очереди в них нет. Удобно, что недалеко от лифта кафетерий Starbucks, можно выпить кофе прямо в домашней одежде и тапочках. Красивые каналы, напоминающие Венецию, можно покататься на гондоле. Вдоль каналов много магазинов, и кафе, приятно погулять по такой красоте. Сам отель был очень красиво украшен к Новому Году. В холле отеля огромное казино. Обслуживание на ресепшене было отличным, хоть и были очереди на регистрацию и возврат номера, но они очень быстро шли - персонал грамотный и быстрый. С удовольствием еще бы вернулись к ним."
            };
            Review review16 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Юлия"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Manuel worse manager in USA",
                rating = 1,
                description = "Я была в отеле на 2 ночи , с первой минуты моего заселения работница отеля в лобби начала мне делать проблемы с оплатой , она отправила меня сразу к мэнэджеру Мануэль , он был грубый и резкий , мне сразу это не понравилось , но я решила остаться потому что были уставшие с дороги , на второй день у меня не сработали ключи и я пошла в лобби за ключами и Главный менеджер Мануель сказал что у нас только одна ночь , хотя деньги за вторую ночь сняли с банка . Он не умеет решать проблемы и он не справляется со своей работой . Manuel you can’t handle simple problems . Change your job for easier one"
            };
            //Senor Frog's Las Vegas
            Review review17 = new Review
            {
                user = dataBase.users
                  .Include(user => user.profile)
                  .Where(user => user.profile.name.Equals("Михаил"))
                  .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Вкусно!",
                rating = 4,
                description = "Интересный интерьер, вкусное мясо, и овощи. Доброжелательный персонал.Удачное расположение рядом с кораблем"
            };
            Review review18 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Никита"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Странный диско-барчик )",
                rating = 3,
                description = "Забавный бар, но ценник показался завышенным. Мебель и все вокруг убито вечной дискотекой, на потолке смешные попы пластиковых людей )))"
            };
            //Le Cirque
            Review review19 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Юлия"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Незабываемый вечер",
                rating = 5,
                description = "Посещали с мужем перед представлением «Cirque du Soleil», столик бронировали заранее. Шикарное место! Дизайн, атмосфера, кухня, обслуживание! Все на высшем уровне, только цены кусаются, но оно того стоит)Отличные коктейли, еда как произведение искусства. Подарок в конце ужина. Только положительные эмоции)) Отличное место для романтического ужина."
            };
            Review review20 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Станислав"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "спокойно! цирк не уехал",
                rating = 5,
                description = "отличная задумка по дизайну, от атмосферы загораются глаза и становиться как то теплее и веселее. отличная кухня, порции сытные. замечательное место!"
            };
            //Triple George Grill
            Review review21 = new Review
            {
                user = dataBase.users
                   .Include(user => user.profile)
                   .Where(user => user.profile.name.Equals("Михаил"))
                   .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Неистово рекомендую!",
                rating = 5,
                description = "Стейки просто божественны. Филе миньон – 9 унций сплошного наслаждения и нектар красного калифорнийского. После ужина непременно, прямиком на Fremont Street, в его безудержное веселье."
            };
            Review review22 = new Review
            {
                user = dataBase.users
                  .Include(user => user.profile)
                  .Where(user => user.profile.name.Equals("Юлия"))
                  .Single(),
                created = DateTime.Now,
                dateTravel = DateTime.Now,
                header = "Превосходные стейки",
                rating = 5,
                description = "Этот ресторан нам посоветовали знакомые. Тут действительно подают превосходные рибаи. Могу рекомендовать"
            };
            dataBase.reviews.AddRange(review1, review2, review3, review4, review5, review6, review7, review8, review9, review10, review11, review12, review13, review14, review15, review16, review17, review18, review19, review20, review21, review22);
            dataBase.SaveChanges();
            #endregion
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
            Photo photo25 = new Photo { image = Util.getByteImage(@"wwwroot\img\dolphinIsland.jpg"), name = @"img\dolphinIsland.jpg" };
            Photo photo26 = new Photo { image = Util.getByteImage(@"wwwroot\img\dolphinIsland1.jpg"), name = @"img\dolphinIsland1.jpg" };
            Photo photo27 = new Photo { image = Util.getByteImage(@"wwwroot\img\dolphinIsland2.jpg"), name = @"img\dolphinIsland2.jpg" };
            Photo photo28 = new Photo { image = Util.getByteImage(@"wwwroot\img\Eyes.jpg"), name = @"img\Eyes.jpg" };
            Photo photo29 = new Photo { image = Util.getByteImage(@"wwwroot\img\Eyes1.jpg"), name = @"img\Eyes1.jpg" };
            Photo photo30 = new Photo { image = Util.getByteImage(@"wwwroot\img\crater.jpg"), name = @"img\crater.jpg" };
            Photo photo31 = new Photo { image = Util.getByteImage(@"wwwroot\img\crater1.jpg"), name = @"img\crater1.jpg" };
            Photo photo32 = new Photo { image = Util.getByteImage(@"wwwroot\img\Legoland.jpg"), name = @"img\Legoland.jpg" };
            Photo photo33 = new Photo { image = Util.getByteImage(@"wwwroot\img\Legoland1.jpg"), name = @"img\Legoland1.jpg" };
            Photo photo34 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cathedral-Rock.jpg"), name = @"img\Cathedral-Rock.jpg" };
            Photo photo35 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cathedral-Rock1.jpg"), name = @"img\Cathedral-Rock1.jpg" };
            Photo photo36 = new Photo { image = Util.getByteImage(@"wwwroot\img\neon-museum.jpg"), name = @"img\neon-museum.jpg" };
            Photo photo37 = new Photo { image = Util.getByteImage(@"wwwroot\img\neon-museum1.jpg"), name = @"img\neon-museum1.jpg" };
            Photo photo38 = new Photo { image = Util.getByteImage(@"wwwroot\img\Natural_History_Museum.jpg"), name = @"img\Natural_History_Museum.jpg" };
            Photo photo39 = new Photo { image = Util.getByteImage(@"wwwroot\img\Natural_History_Museum1.jpg"), name = @"img\Natural_History_Museum1.jpg" };
            Photo photo40 = new Photo { image = Util.getByteImage(@"wwwroot\img\Old-Faithful.jpg"), name = @"img\Old-Faithful.jpg" };
            Photo photo41 = new Photo { image = Util.getByteImage(@"wwwroot\img\Old-Faithful1.jpg"), name = @"img\Old-Faithful1.jpg" };
            Photo photo42 = new Photo { image = Util.getByteImage(@"wwwroot\img\Rappel-Maui.jpg"), name = @"img\Rappel-Maui.jpg" };
            Photo photo43 = new Photo { image = Util.getByteImage(@"wwwroot\img\Rappel-Maui1.jpg"), name = @"img\Rappel-Maui1.jpg" };
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12, photo13, photo14, photo15, photo16, photo17, photo18, photo19, photo20, photo21, photo22, photo23, photo24, photo25, photo26, photo27, photo28, photo29, photo30, photo31, photo32, photo33, photo34, photo35, photo36, photo37, photo38, photo39, photo40, photo41, photo42, photo43);
            #endregion
            #region Landmarks
            #region landmarkForDirection1
            Landmark landmark1 = new Landmark
            {
                name = "Upper Geyser Basin",
                rating = 5,
                mainPhoto = photo1,
                photos = new List<Photo> { photo2 },
                location = "Center Loop Road, Йеллоустонский национальный парк, WY 82190",
                phoneNumber = "+ 1 307 - 344 - 7381",
                description = "Расположенный между районом Олд Фэйтфул и дорогой Бисквит-Бейсин-роуд, Верхний бассейн Гейзера занимает площадь всего около 1 квадратной мили. На этой небольшой территории самая большая концентрация гейзеров и геотермальных источников в мире! Кроме того, гейзеры здесь также являются одними из самых больших и мощных в мире.",
                webSite = "http://www.yellowstonenationalpark.com/uppergeyser.htm"
            };
            Landmark landmark2 = new Landmark
            {
                name = "Большой призматический источник",
                rating = 4.9M,
                mainPhoto = photo3,
                location = "Midway Geyser Basin, Йеллоустонский национальный парк, WY",
                phoneNumber = "+1 307-344-7381",
                description = "Большой призматический источник (Grand Prismatic spring) – это один из символов национального парка Йеллоустоун в США, похожий на огромное око, или как его называют на картах – Гранд призматик спринг. Такое красивое название этому геотермальному источнику дали за красочное сочетание цветов и великолепное оформление. Сверху этот термальный бассейн действительно смотрится как глаз с длинными ресничками. Это самый большой геотермальный источник в США, а в мире он занимает третье место после озера Сковорода (Фрайинг пэн ейн) в Новой Зеландии и Кипящее озеро (Бойлинг Лейк) в Доминике. Глубина этого геотермального источника – 49 метров. ",
                webSite = "https://www.nps.gov/features/yell/ofvec/exhibits/treasures/thermals/hotspring/grandprismatic.htm"
            };
            Landmark landmark21 = new Landmark
            {
                name = "Old Faithful",
                rating = 4.5M,
                mainPhoto = photo40,
                photos = new List<Photo> { photo41 },
                location = "Center Loop Road, Йеллоустонский национальный парк, WY 82190",
                phoneNumber = "+1 307-547-2750",
                description = "Олд-Фе́йтфул (англ. Old Faithful — «старый служака») — один из самых знаменитых гейзеров на Земле. Во время одного извержения гейзера выбрасывается от 14 до 32 тыс. литров кипящей воды на высоту от 32 до 56 м продолжительностью от 1,5 до 5 минут[2]. Это один из самых предсказуемых гейзеров на планете, он извергается каждые 35—120 минут, и поэтому считается, что это наиболее часто фотографируемое из чудес природы. Время между извержениями имеет бимодальное распределение[en] со средним интервалом либо 65, либо 91 минута.",
                webSite = "https://www.nps.gov/yell/planyourvisit/exploreoldfaithful.htm"
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
                },
                location = "Scape Park, Cap Cana, Пунта-Кана 23000, Доминикана",
                description = "Лагуна Азул одно из самых красивейших достопримечательностей в Доминиканской республике. Озеро образовавшееся внутри скалы, за счёт скопления за многия тысячи лет дождевой воды, прошедшей через все слои почвы. Идеально чистейшее озеро."
            };
            Landmark landmark19 = new Landmark
            {
                name = "Остров дельфинов",
                rating = 5,
                mainPhoto = photo25,
                photos = new List<Photo> { photo26, photo27 },
                location = "Пунта-Кана, Доминикана",
                phoneNumber = "+1 809-221-9444",
                description = "стров Дельфинов располагается на восточном побережье Доминиканской Республики, недалеко от Пунта-Кана. Это своего рода дельфинарий в открытом море. Достопримечательность представляет собой плавучую платформу, расположенную в некотором удалении от берега. Здесь находится пять бассейнов, в которых живут несколько видов морских обитателей. Созданы все необходимые условия для содержания животных. Дельфины хорошо идут на контакт с людьми, их можно гладить, кормить или даже купаться с ними в течении 25-30 минут. Для посетителей устраивается небольшое шоу, в ходе которого животные демонстрирует свои умения. Помимо дельфинов в бассейнах можно встретить морских львов и котиков. С ними также разрешено плавать за дополнительную оплату. Для любителей экстремального отдыха, есть возможность искупаться в отсеке с акулами и скатами.",
                webSite = "https://www.dolphinislandpark.com/?utm_source=TripAdvisor.com&utm_medium=referral&utm_campaign=ficha-empresa"
            };
            Landmark landmark20 = new Landmark
            {
                name = "Экологический парк Indigenous Eyes Reserva Ecológica Ojos Indígenas",
                rating = 5,
                mainPhoto = photo28,
                photos = new List<Photo> { photo29 },
                location = "Ave. Abraham Lincoln No. 960, Пунта-Кана 23000 Доминикана",
                phoneNumber = "+1 809-959-9221",
                description = "Indigenous Eyes (что можно перевести как «Природные глаза») - экологический заповедник, расположенный на территории в 1500 га, где в первозданном виде сохранились флора и фауна тропических влажных лесов. Сюда приезжают путешественники, которые хотят увидеть столетние деревья причудливой формы, субтропические цветы невероятных размеров и окраски, замысловатые переплетения лиан. Надо отметить, что в этом парке произрастает 500 видов редких, исчезающих растений и обитает почти 100 видов птиц. Indigenous Eyes - это одиннадцать укромных лагун с прохладной прозрачной водой, действительно, напоминающих по форме человеческий глаз, в которых можно искупаться. Кристально чистые пресноводные лагуны питаются подземными реками. Древние индейцы считали, что эти воды обладают целебными свойствами. Песчаный пляж тоже никого не оставит равнодушным, поскольку там можно увидеть морских черепах, которые облюбовали это место для выкладки своих яиц в теплый белый песок."
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
                },
                location = "Route 36, Остров Мауи, HI",
                phoneNumber = "+1 808-661-8687",
                description = "Те, кто не знаком с шоссе Хана, также известным как «Дорога в Хану», посмотрят на свою карту и скажут: «О, это всего лишь 52 мили. Мы сможем добраться до Ханы примерно за час ». Ну, если только вы не летите… в буквальном смысле. Удачно названная «Шоссе развода», Дорога в Хану имеет изнурительные и много раз мучительные 617 крутых поворотов и 59 неумолимых однополосных мостов, не говоря уже о невероятном количестве слепых зон на этом пути. А поскольку ограничение скорости на всем пути составляет 25 миль в час или менее, это означает, что время в пути (с несколькими остановками или без остановок) в среднем составляет около 2,5 часов - и это без каких-либо пробок или других отклонений. О, и есть еще много препятствий, чтобы добраться туда «вовремя», например, вы будете очарованы всеми невероятно красивыми водопадами, местными украшениями ручной работы, ароматными цветами и леями, свежим ананасом, банановым хлебом и множеством других гавайских кулинарных изысков. быть обнаруженным на придорожных стендах. Вы сами решаете, на чем хотите сосредоточиться, а все остальное мы берем на себя.",
                webSite = "https://www.tourmaui.com/road-to-hana/"
            };
            Landmark landmark26 = new Landmark
            {
                name = "Кратер Халеакала",
                rating = 4.5M,
                mainPhoto = photo30,
                photos = new List<Photo> { photo31 },
                location = "Национальный парк Халеакала, Остров Мауи, HI 96768",
                phoneNumber = "+1 808-572-4400",
                description = "Склоны вулкана возвышающегося более чем на 3000 метров над уровнем моря, видны практически из любой точки острова Гавайи. Название вулкана переводится как «дом солнца». Легенда утверждает, что Maui, получеловек-полубог, поймал солнце своим лассо с вершины этой горы, чтобы замедлить его ход. Если подняться на вершину кратера, то можно погулять над облаками. Разноцветные долины, бесплодные пустыни и дикая природа дождевых лесов - ландшафты парка поражают разнообразием.",
                webSite = "https://www.nps.gov/hale/index.htm"
            };
            Landmark landmark27 = new Landmark
            {
                name = "Rappel Maui Waterfalls and Rainforest Cliffs",
                rating = 4.5M,
                mainPhoto = photo42,
                photos = new List<Photo> { photo43 },
                location = "10600 Hana Hwy, Haiku, HI 96708, USA",
                phoneNumber = "808-270-1500",
                description = "Ваше приключение на природе происходит в частной уединенной долине водопадов, одном из немногих туристических направлений в своем роде. Отойдите от всего: толпы, движения, скорости. Погрузитесь в природу: исследуйте остров Долины в более интимном, личном раю тропических лесов, водопадов, бассейнов и ручьев. Все, что вам нужно, включено; опыт не обязателен. Приглашаются новички и новички. Ваша безопасность - главный приоритет для ваших гидов, когда они проводят то, что посетители называют лучшим днем ​​своего визита на Мауи и Гавайские острова.",
                webSite = "https://www.rappelmaui.com/"
            };
            #endregion

            #region landmarkForDirection4
            Landmark landmark5 = new Landmark
            {
                name = "Magic Kingdom",
                rating = 4.3M,
                mainPhoto = photo7,
                location = "1180 Seven Seas Dr Walt Disney World, Орландо, FL 32830",
                phoneNumber = "+1 407-939-5277",
                description = "Главный и самый известный парк на территории Walt Disney World Resord. Самый посещаемый парк в мире - страна сказок, мультфильмов и фантазий. Парады любимых героев Диснея, множество захватывающих аттракционов. Весной в парке проходит уникальное зрелищное шоу - международный Фестиваль садов и цветов. Все деревья, цветы и целые сады предстают перед посетителями в виде известных диснеевских персонажей. Незабываемое зрелище - традиционный фейерверк, который раскрашивает небо тысячами красок, останется в памяти навсегда!",
                webSite = "https://disneyworld.disney.go.com/destinations/magic-kingdom/?CMP=OKC-wdw_TA_189/"
            };
            Landmark landmark6 = new Landmark
            {
                name = "Universal Studios Florida",
                rating = 4.4M,
                mainPhoto = photo8,
                photos = new List<Photo> { photo9 },
                location = "6000 Universal Boulevard, Орландо, FL 32819-7640",
                phoneNumber = "407 363 8000",
                description = "Среди самых захватывающих парков развлечений стоит отметить Развлекательный парк киностудии Universal в американском городе Орландо. Разнообразие современных аттракционов удивит даже самых искушенных любителей развлечений. Собственно парк объединяет в себе два тематических парка: Universal Studios Florida, Universal’s Islands of Adventure и развлекательный центр CityWalk. Парк Universal Studios был открыт в 1990 году. Местные аттракционы посвящены сюжетам известных фильмов и мультфильмов. В зоне Hollywood можно встретить Терминатора и повеселиться на аттракционе Universal Horrow Make-up Show, в зоне New York надо непременно заглянуть на аттракционы-катастрофы Revenge of the Mummy и Twister, Ride it out. В зоне Production Central малыши смогут развлечься в компании Шрека и Ослика, а в зоне Jimmy Neutron’s Nictoon Blast можно встретить пришельцев и побывать на далеких планетах. В парке есть веселое кладбище Beetlejuice’s Graveyrd Revue и Woody Woodpecker’s Kidzone, предназначенная для малышей, — в компании знаменитого дятла, можно веселиться на интерактивных площадках.",
                webSite = "https://www.universalorlando.com/web/en/us/theme-parks/universal-studios-florida"
            };
            Landmark landmark22 = new Landmark
            {
                name = "Legoland Florida Resort",
                rating = 4.5M,
                mainPhoto = photo32,
                photos = new List<Photo> { photo33 },
                location = "1 Legoland Way, Винтер-Хейвен, FL 33884-4139",
                phoneNumber = "+ 1 877 - 350 - 5346",
                description = "Леголенд во Флориде открыт в 2011 году. Сегодня парк занимает площадь почти 59 гектар и является вторым по площади послед Legoland в Великобритании. Всего в мире открыто для своих маленьких почитателей 6 парков Леголенд, и первый парк был открыт конечно же в Дании, где был изобретен, ныне имеющий мировую известность, конструктор Lego. Все в Леголенд крутится вокруг темы Лего и в большинстве собрано из миллионов деталек конструктора.",
                webSite = "https://www.legoland.com/florida/"
            };
            #endregion

            #region landmarkForDirection5
            Landmark landmark7 = new Landmark
            {
                name = "Soldier Pass",
                rating = 4.4M,
                mainPhoto = photo10,
                location = "Седона, AZ",
                description = "К началу тропы нужно свернуть на Soldier Pass Road с шоссе 89A к западу от центра города Седона. Дорога Soldier Pass приближается к Coffee Pot Rock, и направо следует на Rim Shadows Rd. Следуйте указателям на Soldier Pass Rd. Подъем на перевал Солдат ведет на север и составляет примерно две мили. Тропа умеренная, но легкая при спуске с общей высотой спуска 450 футов. Можно увидеть множество достопримечательностей, включая две естественные арки, Семь священных бассейнов и самую большую воронку в Седоне, кухню дьявола.",
                webSite = "http://www.sedonahikingtrails.com/soldier-pass-north.htm"
            };
            Landmark landmark8 = new Landmark
            {
                name = "Devil's Bridge Trail",
                rating = 4,
                mainPhoto = photo11,
                location = "Седона, AZ 86336",
                description = "Мост Дьявола - самая большая арка из природного песчаника в районе Седоны. Не позволяйте его названию вводить вас в заблуждение: это одна из самых райских достопримечательностей в районе, который славится ими. С высоты 4600 футов, во время этого умеренно сложного 1,8-мильного маршрута туда и обратно нужно всего лишь 400 футов набора высоты. Путешествие к вершине не заставит вас затаить дыхание - но мы никогда не скажем того же о видах, которые вы увидите, когда наконец доберетесь туда. Этот популярный поход привлекает как случайных туристов, которым не хватает желания или выносливости, чтобы уйти слишком далеко от цивилизации, так и любителей приключений на свежем воздухе. Начиная с парковки, следуйте по маркеру, указывающей путь к Дьявольскому мосту. Вы обнаружите, что ранний выход не требует усилий; Тропа, изначально построенная для путешествий на джипах, гладкая и чистая, и ведет через промоины, заполненные можжевельником и кактусом опунции.",
                webSite = "https://www.fs.usda.gov/recarea/coconino/recreation/ohv/recarea/?recid=55292&actid=50"
            };
            Landmark landmark23 = new Landmark
            {
                name = "Cathedral Rock",
                rating = 4.5M,
                mainPhoto = photo34,
                photos = new List<Photo> { photo35 },
                location = "Yavapai County, Седона, AZ 86351",
                phoneNumber = "+1 928-203-7500",
                description = "Кафедральный собор - это очаровательная скала, с которой открывается панорама во все стороны, как только вы доберетесь до вершины. Поход на Соборную скалу предлагает достаточно проблем, чтобы оставаться интересным, и вам понадобится много времени, чтобы полюбоваться марсианским пейзажем сверху. Этот поход в Седону не зря является одним из самых любимых маршрутов. Расстояние: 1,2 мили туда и обратно. Набор высоты 650 футов. Сложность: Поход на Соборную Скалу начинается красиво и легко, но быстро становится довольно крутым с коротким переходом из рук в руки к концу.Не позволяйте расстоянию вводить вас в заблуждение, вам нужно надеть прочную обувь и выбрать рюкзак, чтобы освободить руки для лазания. На тропе нет тени.",
                webSite = "https://www.fs.usda.gov/recarea/coconino/recarea/?recid=55264"
            };
            #endregion

            #region landmarkForDirection6
            Landmark landmark9 = new Landmark
            {
                name = "Mayan Museum of Cancun",
                rating = 4.2M,
                mainPhoto = photo12,
                location = "Hotelera Cancun Quintana Roo Blvd. Kukulcan Km 16. 5 Esq. Gucumatz, Канкун 77504 Мексика",
                phoneNumber = "+ 52 998 885 3842",
                description = "Канкун - это не только отели и прекрасные пляжи. Ривьера Майя простирается к югу от Канкуна и названа в честь цивилизации майя. Музей майя (Museo Maya) посвящен демонстрации того, что делало эту культуру такой особенной. Museo Maya - это хорошо оформленный музей, который должен быть в вашем списке вещей, которые стоит увидеть в Канкуне, если вам нравится изучать культуру. В музее есть большие выставочные залы и хорошо сохранившиеся артефакты из штата Кинтана-Роо и нескольких других руин за пределами этого района. Большинство дисплеев на английском и испанском языках.",
                webSite = "https://www.inah.gob.mx/red-de-museos/313-museo-maya-de-cancun"
            };
            Landmark landmark10 = new Landmark
            {
                name = "Руины Эль-Рей",
                rating = 4,
                mainPhoto = photo13,
                photos = new List<Photo> { photo14 },
                location = "Blvd Kukulcan Km 17 Zona Hotelera, Канкун 77500 Мексика",
                phoneNumber = "+52 983 837 2411",
                description = "Руины Эль-Рей расположены в центре отельной части Канкуна, почти на самом берегу лагуны, и примыкают к полю для гольфа отеля «Хилтон». Проще всего добираться сюда автобусом или на арендованном авто, чтобы запарковаться близ одного из отелей. Время работы: 8:00 — 17:00.",
                webSite = "https://www.inah.gob.mx/zonas/95-zona-arqueologica-el-rey"
            };
            Landmark landmark11 = new Landmark
            {
                name = "Пляж Playa Delfines",
                rating = 4.4M,
                mainPhoto = photo15,
                location = "Boulevard Kukulkan, Punta Nizuc - Cancun 335 Zona Hotelera, Канкун 77500 Мексика",
                description = "Пляж Дельфинов (Playa Delfines) - это долгожданная передышка от переполненных пляжей и шумных ночных клубов, которыми стал известен Канкун. Этот тихий песчаный пляж расположен недалеко от гостиничной зоны, на одной из самых высоких точек города. Отсюда открываются великолепные панорамные виды. Это идеальное место для неспешной прогулки, ловли волн или просто отдыха."
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
                },
                location = "20 West 34th Street, Нью-Йорк, NY 10001",
                phoneNumber = "+1 212-736-3100",
                description = "Небоскреб Эмпайр Стейт Билдинг — одно из самых известных зданий в мире. Его авторы — архитектурное агентство «Шрив, Лэмб и Хармон» — первыми в истории решились создать проект здания с более чем сотней этажей. Открытый на Махэттене в 1931 году, построенный меньше, чем за полтора года он справедливо считался «восьмым чудом света», что и было отражено в росписи его холла. Но в 70-х постройка Всемирного торгового центра лишила его пальмы первенства среди самых высоких зданий, а рост числа небоскребов не только в США, но и в других странах заставил потускнеть ореол уникальности.",
                webSite = "https://www.esbnyc.com/buy-tickets"
            };
            Landmark landmark13 = new Landmark
            {
                name = "Бруклинский мост",
                rating = 4.3M,
                mainPhoto = photo17,
                location = "Нью-Йорк, NY 10038",
                description = "Бруклинский мост — это не просто соединительная магистраль между Бруклином и Манхэттеном, это одна из главных достопримечательностей Нью-Йорка, можно сказать, визитная карточка города. Это мост-рекордсмен, сооружение со своей, местами трагичной, но, тем не менее, захватывающей историей. Идея построить мост необычной конструкции(подвесной) с применением опять - таки необычных строительных материалов(сталь, покрытую специальным сплавом, вместо тяжеловесного чугуна) пришла в голову Джону Реблингу.",
                webSite = "https://www1.nyc.gov/html/dot/html/infrastructure/bridges.shtml"
            };
            Landmark landmark14 = new Landmark
            {
                name = "Центральный парк",
                rating = 4.4M,
                mainPhoto = photo18,
                location = "59th to 110th Street Manhattan Borough, from Central Park West to 5th Avenue, Нью-Йорк, NY 10022",
                phoneNumber = "(212) 310-6600",
                description = "Центральный парк (Central Park) Нью-Йорка в районе Манхэттен — одно из самых любимых мест отдыха местных жителей и многочисленных туристов. Они приезжают сюда не только для того, чтобы полюбоваться природой (а Центральный парк очень красив) и покормить белок. На территории парка расположены фонтан Bethesda, музыкальные часы, скульптуры и памятники, театр под открытым небом Delacorte Theater, Театр марионеток (The Swedish Cottage Marionette Theatre), зоопарк, замок Belvedere, музей современного искусства «Метрополитен» (Metropolitan Museum) и многое другое.",
                webSite = "https://www.centralparknyc.org/"
            };
            #endregion

            #region landmarkForDirection8
            Landmark landmark15 = new Landmark
            {
                name = "The Strip",
                rating = 4.2M,
                mainPhoto = photo19,
                location = "S Las Vegas Blvd, Лас-Вегас, NV 89109",
                description = "Лас-Вегас-Стрип (англ. Las Vegas Strip) — примерно семикилометровый участок бульвара Лас-Вегас в округе Кларк в штате Невада, США. Здесь находится большинство крупнейших гостиниц и казино агломерации Лас-Вегаса, при этом Стрип лежит за пределами самого города[1] и административно относится к пригородам — Парадайсу и Уинчестеру. В южной части Лас-Вегас-Стрип находится легкоузнаваемый символ Лас-Вегаса — знак Добро пожаловать в сказочный Лас-Вегас."
            };
            Landmark landmark16 = new Landmark
            {
                name = "Bellagio Conservatory & Botanical Garden",
                rating = 4.3M,
                mainPhoto = photo20,
                photos = new List<Photo> { photo21 },
                location = "Bellagio Conservatory & Botanical Garden",
                phoneNumber = "+1 888-987-6667",
                description = "Просторная центральная оранжерея, открывающаяся прямо при входе в Белладжио, была вдохновлена ​​зелеными рамками парижских консерваторий в стиле модерн. Несмотря на то, что Лас-Вегас расположен прямо посреди пустыни Мохаве, вы можете увидеть смену времен года во всей красе, когда консерватория и ботанический сад Белладжио превращаются пять раз в год с новыми цветами; возвышающиеся аниматронные бабочки и птицы; журчащие фонтаны и покачивающиеся фонари. Каждое из его сезонных «театральных представлений» элементов совершенно новое. Вы никогда не увидите одно и то же дважды. И каждый более транспортный, чем предыдущий. Это бесплатно, не требует усилий для навигации (если только вы не пытаетесь протолкнуться через всех любителей селфи со смартфонами). Это настоящий праздник для глаз: местные жители любят его не меньше туристов, и это одна из лучших бесплатных достопримечательностей города.",
                webSite = "https://bellagio.mgmresorts.com/en/entertainment/conservatory-botanical-garden.html?icid=GMB_Entertainment_Conservatory"
            };
            Landmark landmark24 = new Landmark
            {
                name = "The Neon Museum",
                rating = 4.5M,
                mainPhoto = photo36,
                photos = new List<Photo> { photo37 },
                location = "770 Las Vegas Blvd N, Лас-Вегас, NV 89101-2010",
                phoneNumber = "+1 702-387-6366",
                description = "Неоновый музей - это некоммерческая организация, которая занимается исключительно сбором, сохранением, изучением и выставкой знаковых знаков Лас-Вегаса в образовательных, исторических, художественных и культурных целях. Подумайте обо всех тех казино, которые появлялись и уходили на протяжении многих лет, например, Сахара. Этот знак мог быть одним из самых знаковых знаков Лас-Вегаса, когда-либо украшавших Стрип, и его бросили бы в мусор, вырвали бы сборщиком из другого штата или каким-то другим образом нанесли бы ущерб истории Невады. Благодаря людям из Неонового музея эта нить истории Невады безукоризненно сохраняется и восстанавливается. И где лучше место для размещения впечатляюще визуального музея, чем бывшее лобби мотеля La Concha? Имущество было спасено от сноса, перенесено на территорию музея неоновых ламп и служит штаб-квартирой музея. Вы также найдете выставку под открытым небом или своего рода галерею, известную как Neon Boneyard, и сувенирный магазин.",
                webSite = "https://www.neonmuseum.org/"
            };
            #endregion

            #region landmarkForDirection9
            Landmark landmark17 = new Landmark
            {
                name = "Лондонский Тауэр",
                rating = 4.4M,
                mainPhoto = photo22,
                photos = new List<Photo> { photo23, photo1, photo10, photo11, photo13, photo14 },
                location = "St Katharine's & Wapping, Лондон EC3N 4AB Англия",
                phoneNumber = "+44 333 320 6000",
                description = "Лондонский Тауэр стал символом не только Лондона, но и всей Великобритании. Он занимает особое место в британской истории, поэтому сейчас Тауэр — одна из самых посещаемых архитектурных и исторических достопримечательностей мира. По сути своей Тауэр — это крепость. Она стоит на северном берегу Темзы, является одним из старейших сооружений Англии и историческим центром Лондона. История этой крепости пестрая: изначально ее строили как оборонительный замок, а затем она служила и зоопарком, и монетным двором, и арсеналом, и тюрьмой, и обсерваторией, и хранилищем королевских драгоценностей.",
                webSite = "https://www.hrp.org.uk/tower-of-london/#gs.imzFnKo/"
            };
            Landmark landmark18 = new Landmark
            {
                name = "Британский музей",
                rating = 4.5M,
                mainPhoto = photo24,
                location = "Great Russell Street, Лондон WC1B 3DG Англия",
                phoneNumber = "+44 20 7323 8000",
                description = "Британский музей — центральный историко-археологический музей Великобритании и один из крупнейших музеев мира. Он был основан в 1753 году с разрешения британского парламента. Его экспозиция занимает 94 галереи, общая протяжённость которых составляет 4 км. В основу вошли коллекции трёх известных людей — графа Роберта Харли, врача Хэнса Слоуна и антиквара Роберта Коттона. От последнего музей получил огромную коллекцию книг, которая положила начало созданию Британской библиотеки.",
                webSite = "https://www.britishmuseum.org/"
            };
            Landmark landmark25 = new Landmark
            {
                name = "Natural History Museum",
                rating = 4.5M,
                mainPhoto = photo38,
                photos = new List<Photo> { photo39 },
                location = "Cromwell Road South Kensington, Лондон SW7 5BD Англия",
                phoneNumber = "+44 20 7938 9123",
                description = "Посмотрите сотни увлекательных интерактивных экспонатов в одном из самых красивых зданий Лондона - Музее естественной истории. Достопримечательности включают в себя популярную галерею динозавров, «Млекопитающие» с ее незабываемой моделью голубого кита и впечатляющий Центральный зал, в котором находится знаменитый музейный скелет диплодока. Не пропустите ультрасовременный Кокон, где во время самостоятельной экскурсии вы можете увидеть сотни увлекательных образцов и заглянуть в лаборатории, где вы можете увидеть ученых за работой. Музей предлагает обширную программу временных выставок и мероприятий, включая возможность присоединиться к экспертам в высокотехнологичной студии Аттенборо Дарвиновского центра для обсуждения актуальных вопросов о науке и природе.",
                webSite = "https://www.nhm.ac.uk/"
            };
            #endregion

            dataBase.landmarks.AddRange(landmark1, landmark2, landmark3, landmark4, landmark5, landmark6, landmark7, landmark8, landmark9, landmark10, landmark11, landmark12, landmark13, landmark14, landmark15, landmark16, landmark17, landmark18, landmark19, landmark20, landmark21, landmark22, landmark23, landmark24, landmark25, landmark26, landmark27);
            dataBase.SaveChanges();
            #endregion
            #region Reviews
            // Привязка review к landmark
            dataBase.reviews.Where(review => review.header.Equals("Красивое место")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("Hana Highway - Road to Hana")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Лучше билет am/pm.")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("Empire state building")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("После Оаху и карибов дорога не впечатлила.")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("Лагуна Азул")).Select(landmark => landmark.id).Single();

            dataBase.reviews.Where(review => review.header.Equals("Ночная экскурсия по отелям Вегаса")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("Bellagio Conservatory & Botanical Garden")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Красота да и только")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("Bellagio Conservatory & Botanical Garden")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Впечатляет")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("The Strip")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Fun but expensive")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("The Strip")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Разочаровательно")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("The Neon Museum")).Select(landmark => landmark.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Очень атмосферно!")).Single().landmarkId =
                dataBase.landmarks.Where(landmark => landmark.name.Equals("The Neon Museum")).Select(landmark => landmark.id).Single();
            #endregion

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
            #region Directions
            Direction direction1 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Upper Geyser Basin")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Большой призматический источник")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Old Faithful")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Old Faithful Inn")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Roosevelt Lodge Cabins")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Madison Campground")).Single()
                },
                restaurants = new List<Restaurant>
                {
                dataBase.restaurants.Where(r => r.name.Equals("Roosevelt Lodge Dining Room")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Lake Yellowstone Hotel Dining Room")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Fishing Bridge General Store")).Single()
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
                    dataBase.landmarks.Where(l => l.name.Equals("Лагуна Азул")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Остров дельфинов")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Экологический парк Indigenous Eyes Reserva Ecológica Ojos Indígenas")).Single()
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
                },
                restaurants = new List<Restaurant>
                {
                dataBase.restaurants.Where(r => r.name.Equals("Chic Cabaret & Restaurant Punta Cana")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("La Yola Restaurant")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Pranama")).Single()
                }

            };
            Direction direction3 = new Direction {
                landmarks = new List<Landmark>
                {
                    dataBase.landmarks.Where(l => l.name.Equals("Hana Highway - Road to Hana")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Кратер Халеакала")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Rappel Maui Waterfalls and Rainforest Cliffs")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Hotel Wailea")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Hana-Maui Resort")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Andaz Maui At Wailea Resort")).Single()
                },
                restaurants = new List<Restaurant>
                {
                dataBase.restaurants.Where(r => r.name.Equals("Ululani's Hawaiian Shave Ice")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Maui Thai Bistro")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Mama's Fish House")).Single()
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
                    dataBase.landmarks.Where(l => l.name.Equals("Universal Studios Florida")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Legoland Florida Resort")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Disney's Animal Kingdom Lodge")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Hilton Orlando Bonnet Creek")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Alfond Inn")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Four Seasons Resort Orlando at Walt Disney World Resort")).Single()
                },
                restaurants = new List<Restaurant>
                {
                dataBase.restaurants.Where(r => r.name.Equals("Bosphorous Turkish Cuisine")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("La Luce")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("4 Rivers Smokehouse")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Keke's Breakfast Cafe")).Single()
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
                    dataBase.landmarks.Where(l => l.name.Equals("Devil's Bridge Trail")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Cathedral Rock")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("El Portal Sedona Hotel")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("L'Auberge de Sedona")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Enchantment Resort")).Single()                
                },
                restaurants = new List<Restaurant>
                {
                dataBase.restaurants.Where(r => r.name.Equals("Golden Goose American Grill")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Bella Vita Ristorante")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Elote Cafe")).Single()
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
                    dataBase.restaurants.Where(r => r.name.Equals("Lorenzillo's")).Single(),
                    dataBase.restaurants.Where(r => r.name.Equals("Porfirio's Cancún")).Single(),
                    dataBase.restaurants.Where(r => r.name.Equals("Taqueria Coapenitos")).Single(),
                    dataBase.restaurants.Where(r => r.name.Equals("Les Cepages Restaurant")).Single()
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
                restaurants = new List<Restaurant>
                {
                dataBase.restaurants.Where(r => r.name.Equals("5 Napkin Burger Hell's Kitchen")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Obao")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Bleecker Street Pizza")).Single()
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
                    dataBase.landmarks.Where(l => l.name.Equals("The Neon Museum")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Bellagio Conservatory & Botanical Garden")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("ARIA Resort & Casino")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("Bellagio Las Vegas")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Cosmopolitan of Las Vegas, Autograph Collection")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Venetian Resort")).Single()
                },
                restaurants = new List<Restaurant>
                {
                dataBase.restaurants.Where(r => r.name.Equals("Senor Frog's Las Vegas")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Le Cirque")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Triple George Grill")).Single()
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
                    dataBase.landmarks.Where(l => l.name.Equals("Natural History Museum")).Single(),
                    dataBase.landmarks.Where(l => l.name.Equals("Британский музей")).Single()
                },
                hotels = new List<Hotel>
                {
                    dataBase.hotels.Where(l => l.name.Equals("Vintry & Mercer")).Single(),
                    dataBase.hotels.Where(l => l.name.Equals("The Landmark London")).Single()
                },
                restaurants = new List<Restaurant>
                {
                dataBase.restaurants.Where(r => r.name.Equals("Figo Stratford")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("The Golden Chippy")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("BaoziInn Soho")).Single(),
                dataBase.restaurants.Where(r => r.name.Equals("Jhenn of the Vegan Ronin")).Single()
                },
                photos = new List<Photo> { photo19 },
                mainPhoto = photo9, 
                name = "Лондон, UK",
                shortDescription = "Царственный город в окружении суеты современной жизни",
                description = "Лондон полон истории: здесь Средневековье и Викторианская эпоха уживаются с роскошным и энергичным современным миром. Лондонский Тауэр и Вестминстер находятся по соседству с местными пабами и рынками, а устаревшие церемонии, например смена караула, происходят в то время, как пассажиры спешат в подземку. Это место, в котором путешественники могут перемещаться во времени, гуляя по городу, а устав, поступить так же, как лондонцы, то есть выпить чашечку чая."
            };
          
            dataBase.directions.AddRange(direction1, direction2, direction3, direction4, direction5, direction6, direction7, direction8, direction9);

            dataBase.SaveChanges();
            #endregion
        }

        public void createHotel()
        {
            #region photo
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

            Photo photo91 = new Photo { image = Util.getByteImage(@"wwwroot\img\for-bedroom.png"), name = @"img\for-bedroom.png" };
            Photo photo92 = new Photo { image = Util.getByteImage(@"wwwroot\img\cup-of-tea.png"), name = @"img\cup-of-tea.png" };
            Photo photo93 = new Photo { image = Util.getByteImage(@"wwwroot\img\kitchen.png"), name = @"img\kitchen.png" };
            Photo photo94 = new Photo { image = Util.getByteImage(@"wwwroot\img\bathroom.png"), name = @"img\bathroom.png" };
            Photo photo95 = new Photo { image = Util.getByteImage(@"wwwroot\img\snow.png"), name = @"img\snow.png" };
            Photo photo96 = new Photo { image = Util.getByteImage(@"wwwroot\img\call.png"), name = @"img\call.png" };
            Photo photo97 = new Photo { image = Util.getByteImage(@"wwwroot\img\play.png"), name = @"img\play.png" };
            Photo photo98 = new Photo { image = Util.getByteImage(@"wwwroot\img\parking.png"), name = @"img\parking.png" };
            Photo photo99 = new Photo { image = Util.getByteImage(@"wwwroot\img\swim.png"), name = @"img\swim.png" };
            Photo photo100 = new Photo { image = Util.getByteImage(@"wwwroot\img\cocktail.png"), name = @"img\cocktail.png" };
            Photo photo101 = new Photo { image = Util.getByteImage(@"wwwroot\img\ticket.png"), name = @"img\ticket.png" };
            Photo photo102 = new Photo { image = Util.getByteImage(@"wwwroot\img\wifi.png"), name = @"img\wifi.png" };
            Photo photo103 = new Photo { image = Util.getByteImage(@"wwwroot\img\family.png"), name = @"img\family.png" };
            Photo photo104 = new Photo { image = Util.getByteImage(@"wwwroot\img\bag.png"), name = @"img\bag.png" };
            Photo photo105 = new Photo { image = Util.getByteImage(@"wwwroot\img\no-smoking.png"), name = @"img\no-smoking.png" };
            Photo photo106 = new Photo { image = Util.getByteImage(@"wwwroot\img\hanger.png"), name = @"img\hanger.png" };
            Photo photo107 = new Photo { image = Util.getByteImage(@"wwwroot\img\sun.png"), name = @"img\sun.png" };
            Photo photo108 = new Photo { image = Util.getByteImage(@"wwwroot\img\taxi.png"), name = @"img\taxi.png" };
            Photo photo109 = new Photo { image = Util.getByteImage(@"wwwroot\img\river.png"), name = @"img\river.png" };
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12, photo13, photo14, photo15, photo16, photo17, photo18, photo19, photo20, photo21, photo22, photo23, photo24, photo25, photo26, photo27, photo28, photo29, photo30, photo31, photo32, photo33, photo34, photo35, photo36, photo37, photo38, photo39, photo40, photo41, photo42, photo43, photo44, photo45, photo46, photo47, photo48, photo49, photo50, photo51, photo52, photo53, photo54, photo55, photo56, photo57, photo58, photo59, photo60, photo61, photo62, photo63, photo64, photo65, photo66, photo67, photo68, photo69, photo70, photo71, photo72, photo73, photo74, photo75, photo76, photo77, photo78, photo79, photo80, photo81, photo82, photo83, photo84, photo85, photo86, photo87, photo88, photo89, photo90, photo91, photo92, photo93, photo94, photo95, photo96, photo97, photo98, photo99, photo100, photo101, photo102, photo103, photo104, photo105, photo106, photo107, photo108, photo109);
            #endregion
            #region RoomEquipment
            RoomEquipment roomEquipment1 = new RoomEquipment { name = "Шторы, блокирующие свет", photo = photo91 };
            RoomEquipment roomEquipment2 = new RoomEquipment { name = "Обеденная зона", photo = photo91 };
            RoomEquipment roomEquipment3 = new RoomEquipment { name = "Диван-кровать", photo = photo91 };
            RoomEquipment roomEquipment4 = new RoomEquipment { name = "Отдельный балкон", photo = photo91 };
            RoomEquipment roomEquipment5 = new RoomEquipment { name = "Сейф", photo = photo91 };
            RoomEquipment roomEquipment6 = new RoomEquipment { name = "Диван", photo = photo91 };
            RoomEquipment roomEquipment7 = new RoomEquipment { name = "VIP-номера", photo = photo91 };
            RoomEquipment roomEquipment8 = new RoomEquipment { name = "Кафельный/мраморный пол", photo = photo91 };
            RoomEquipment roomEquipment9 = new RoomEquipment { name = "Уборка номеров", photo = photo91 };
            RoomEquipment roomEquipment10 = new RoomEquipment { name = "Телефон", photo = photo91 };
            RoomEquipment roomEquipment11= new RoomEquipment { name = "Утюг", photo = photo91 };
            RoomEquipment roomEquipment12 = new RoomEquipment { name = "Мини-кухня", photo = photo92 };
            RoomEquipment roomEquipment13 = new RoomEquipment { name = "Микроволновая печь", photo = photo93 };
            RoomEquipment roomEquipment14 = new RoomEquipment { name = "Кухонная плита", photo = photo93 };
            RoomEquipment roomEquipment15 = new RoomEquipment { name = "Кухонная утварь", photo = photo93 };
            RoomEquipment roomEquipment16 = new RoomEquipment { name = "Холодильник", photo = photo93 };
            RoomEquipment roomEquipment17 = new RoomEquipment { name = "Электрический чайник", photo = photo93 };
            RoomEquipment roomEquipment18 = new RoomEquipment { name = "Бесплатные туалетные принадлежности", photo = photo94 };
            RoomEquipment roomEquipment19 = new RoomEquipment { name = "Душевая кабина без поддона на полу", photo = photo94 };
            RoomEquipment roomEquipment20 = new RoomEquipment { name = "Ванна/душ", photo = photo94 };
            RoomEquipment roomEquipment21 = new RoomEquipment { name = "Фен", photo = photo94 };
            RoomEquipment roomEquipment22 = new RoomEquipment { name = "Кондиционер", photo = photo95 };
            RoomEquipment roomEquipment23 = new RoomEquipment { name = "ТВ с плоским экраном", photo = photo97 };
            RoomEquipment roomEquipment24 = new RoomEquipment { name = "Обслуживание номеров", photo = photo96 };
            RoomEquipment roomEquipment25 = new RoomEquipment { name = "Мини-бар", photo = photo93 };
            dataBase.roomEquipment.AddRange(roomEquipment1, roomEquipment2, roomEquipment3, roomEquipment4, roomEquipment5, roomEquipment6, roomEquipment7, roomEquipment8, roomEquipment9, roomEquipment10, roomEquipment11, roomEquipment12, roomEquipment13, roomEquipment14, roomEquipment15, roomEquipment16, roomEquipment17, roomEquipment18, roomEquipment19, roomEquipment20, roomEquipment21, roomEquipment22, roomEquipment23, roomEquipment24);
            #endregion
            #region RoomType
            RoomType roomType1 = new RoomType { name = "С видом на океан", photo = photo109 };
            RoomType roomType2 = new RoomType { name = "Номера для некурящих", photo = photo105 };
            RoomType roomType3 = new RoomType { name = "Семейные номера", photo = photo91 };
            RoomType roomType4 = new RoomType { name = "С видом на город", photo = photo109 };
            RoomType roomType5 = new RoomType { name = "Номера-люксы", photo = photo91 };
            dataBase.roomTypes.AddRange(roomType1, roomType2, roomType3, roomType4, roomType5);
            #endregion
            #region Services
            Services services1 = new Services { name = "Бесплатная парковка", photo = photo98 };
            Services services2 = new Services { name = "Услуга парковки автомобиля сотрудником отеля", photo = photo98 };
            Services services3 = new Services { name = "Платная общественная парковка поблизости", photo = photo98 };
            Services services4 = new Services { name = "Бассейн", photo = photo99 };
            Services services5 = new Services { name = "Бассейн с подогревом", photo = photo99 };
            Services services6 = new Services { name = "Фитнес-центр", photo = photo99 };
            Services services7 = new Services { name = "Джакузи", photo = photo99 };
            Services services8 = new Services { name = "Бар/лаунж", photo = photo100 };
            Services services9 = new Services { name = "Игровая комната", photo = photo101 };
            Services services10 = new Services { name = "Теннисный корт", photo = photo101 };
            Services services11 = new Services { name = "Прокат снаряжения для водных видов спорта", photo = photo101 };
            Services services12 = new Services { name = "Боулинг", photo = photo101 };
            Services services13 = new Services { name = "Настольный теннис", photo = photo101 };
            Services services14 = new Services { name = "Wi-Fi", photo = photo102 };
            Services services15 = new Services { name = "Бесплатный WiFi", photo = photo102 };
            Services services16 = new Services { name = "Возможен завтрак", photo = photo92 };
            Services services17 = new Services { name = "Буфет", photo = photo93 };
            Services services18 = new Services { name = "Торговый автомат", photo = photo93 };
            Services services19 = new Services { name = "Подходит для детей / семьи", photo = photo103 };
            Services services20 = new Services { name = "Бесплатное размещение для детей", photo = photo103 };
            Services services21 = new Services { name = "Бизнес-центр с Wi-Fi", photo = photo104 };
            Services services22 = new Services { name = "Конференц-залы", photo = photo104 };
            Services services23 = new Services { name = "Помещения для проведения конференций", photo = photo104 };
            Services services24 = new Services { name = "Отель для некурящих", photo = photo105 };
            Services services25 = new Services { name = "Услуги прачечной", photo = photo106 };
            Services services26 = new Services { name = "Прачечная с самообслуживанием", photo = photo91 };
            Services services27 = new Services { name = "Пляж", photo = photo107 };
            Services services28 = new Services { name = "Услуги такси", photo = photo108 };
            dataBase.services.AddRange(services1, services2, services3, services4, services5, services6, services7, services8, services9, services10, services11, services12, services13, services14, services15, services16, services17, services18, services19, services20, services21, services22, services23, services24, services25, services26, services27, services28);
            #endregion
            #region Hotels
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
                photos = new List<Photo> { photo2, photo3 },
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment1,
                    roomEquipment4,
                    roomEquipment22,
                    roomEquipment24,
                    roomEquipment23,
                    roomEquipment7,
                    roomEquipment11,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                { 
                    roomType1,
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services8,
                    services10,
                    services2,
                    services7,
                    services6,
                    services21,
                    services25,
                    services15,
                    services27
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment16,
                    roomEquipment24,
                    roomEquipment23,
                    roomEquipment7,
                    roomEquipment22,
                    roomEquipment25,
                    roomEquipment9
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services2,
                    services7,
                    services6,
                    services8,
                    services22,
                    services23,
                    services14,
                    services28,
                    services27,
                    services25
                }
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
                    roomEquipment4,
                    roomEquipment16,
                    roomEquipment24,
                    roomEquipment23,
                    roomEquipment7,
                    roomEquipment22,
                    roomEquipment25,
                    roomEquipment9,
                    roomEquipment11
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services11,
                    services2,
                    services7,
                    services8,
                    services6,
                    services15,
                    services14,
                    services28,
                    services27,
                    services25
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services7,
                    services8,
                    services14,
                    services15,
                    services25,
                    services27,
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment3,
                    roomEquipment6,
                    roomEquipment9,
                    roomEquipment10,
                    roomEquipment17,
                    roomEquipment20,
                    roomEquipment21
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3
                },

                services = new List<Services>
                {
                    services1,
                    services8,
                    services24
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment6,
                    roomEquipment10,
                    roomEquipment17,
                    roomEquipment20
                },

                roomType = new List<RoomType>
                {
                    roomType2
                },

                services = new List<Services>
                {
                    services1,
                    services8,
                    services24,
                    services25
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment6,
                    roomEquipment13
                },

                roomType = new List<RoomType>
                {
                    roomType2
                },

                services = new List<Services>
                {
                    services1,
                    services18
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment1,
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment11,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services7,
                    services8,
                    services14,
                    services18,
                    services19,
                    services25,
                    services27,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services7,
                    services8,
                    services14,
                    services16,
                    services17,
                    services19,
                    services25,
                    services27,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment24
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services7,
                    services8,
                    services14,
                    services19,
                    services22,
                    services25,
                    services27,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services7,
                    services8,
                    services9,
                    services10,
                    services14,
                    services16,
                    services19,
                    services22,
                    services25,
                    services27,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment6,
                    roomEquipment8,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment12,
                    roomEquipment16,
                    roomEquipment18,
                    roomEquipment20,
                    roomEquipment21,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services2,
                    services4,
                    services6,
                    services7,
                    services8,
                    services11,
                    services14,
                    services25,
                    services27
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment6,
                    roomEquipment8,
                    roomEquipment9,
                    roomEquipment10,
                    roomEquipment16,
                    roomEquipment18,
                    roomEquipment19,
                    roomEquipment20,
                    roomEquipment21,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services7,
                    services8,
                    services10,
                    services11,
                    services15,
                    services16,
                    services19,
                    services25,
                    services27
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment1,
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment8,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment16,
                    roomEquipment17,
                    roomEquipment18,
                    roomEquipment19,
                    roomEquipment21,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType1,
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services2,
                    services4,
                    services6,
                    services7,
                    services8,
                    services13,
                    services15,
                    services16,
                    services19,
                    services25,
                    services27
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment9,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services8,
                    services9,
                    services13,
                    services15,
                    services16,
                    services17,
                    services19,
                    services22,
                    services24,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services2,
                    services4,
                    services5,
                    services6,
                    services7,
                    services8,
                    services9,
                    services14,
                    services17,
                    services18,
                    services19,
                    services23,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment3,
                    roomEquipment5,
                    roomEquipment6,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment17,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services2,
                    services4,
                    services7,
                    services14,
                    services16,
                    services17,
                    services18,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment18,
                    roomEquipment19,
                    roomEquipment21,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services15,
                    services16,
                    services18,
                    services21,
                    services22,
                    services25
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment3,
                    roomEquipment5,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment18,
                    roomEquipment20,
                    roomEquipment21,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services14,
                    services17
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment18,
                    roomEquipment21,
                    roomEquipment23,
                    roomEquipment24
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services2,
                    services4,
                    services6,
                    services14,
                    services16,
                    services17,
                    services21,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment10,
                    roomEquipment11,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services2,
                    services4,
                    services6,
                    services15,
                    services17,
                    services22,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment22,
                    roomEquipment23
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType4,
                    roomType5
                },

                services = new List<Services>
                {
                    services3,
                    services6,
                    services15,
                    services21,
                    services22,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment10,
                    roomEquipment19,
                    roomEquipment21,
                    roomEquipment22,
                    roomEquipment23
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType4
                },

                services = new List<Services>
                {
                    services3,
                    services6,
                    services14,
                    services16,
                    services19,
                    services23,
                    services24,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment10,
                    roomEquipment21,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services3,
                    services14,
                    services17,
                    services21,
                    services22,
                    services24,
                    services25,
                    services28
                }
            };
            //8
            Hotel hotel25 = new Hotel
            {
                //1
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment1,
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment10,
                    roomEquipment11,
                    roomEquipment18,
                    roomEquipment19,
                    roomEquipment21,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType4,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services8,
                    services14,
                    services17,
                    services21,
                    services23,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment1,
                    roomEquipment5,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment18,
                    roomEquipment19,
                    roomEquipment20,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType4,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services7,
                    services8,
                    services14,
                    services16,
                    services22,
                    services23,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment4,
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment13,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services2,
                    services4,
                    services6,
                    services8,
                    services14,
                    services17,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment11,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services1,
                    services4,
                    services6,
                    services7,
                    services8,
                    services14,
                    services16,
                    services21,
                    services25,
                    services28
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType5
                },

                services = new List<Services>
                {
                    services6,
                    services8,
                    services14,
                    services15,
                    services16,
                    services21,
                    services22,
                    services24,
                    services25
                }
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
                roomEquipment = new List<RoomEquipment>
                {
                    roomEquipment5,
                    roomEquipment7,
                    roomEquipment9,
                    roomEquipment16,
                    roomEquipment22,
                    roomEquipment23,
                    roomEquipment24,
                    roomEquipment25
                },

                roomType = new List<RoomType>
                {
                    roomType2,
                    roomType3,
                    roomType5
                },

                services = new List<Services>
                {
                    services2,
                    services4,
                    services6,
                    services7,
                    services15,
                    services17,
                    services21,
                    services24,
                    services25,
                    services28
                }
            };
            
            dataBase.hotels.AddRange(hotel1, hotel2, hotel3, hotel4, hotel5, hotel6, hotel7, hotel8, hotel9, hotel10, hotel11, hotel12, hotel13, hotel14, hotel15, hotel16, hotel17, hotel18, hotel19, hotel20, hotel21, hotel22, hotel23, hotel24, hotel25, hotel26, hotel27, hotel28, hotel29, hotel30);
            dataBase.SaveChanges();
            #endregion
            #region Reviews
            dataBase.reviews.Where(review => review.header.Equals("Отличный отель")).Single().hotelId =
                dataBase.hotels.Where(hotel => hotel.name.Equals("ARIA Resort & Casino")).Select(hotel => hotel.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Превосходный отель")).Single().hotelId =
                dataBase.hotels.Where(hotel => hotel.name.Equals("ARIA Resort & Casino")).Select(hotel => hotel.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Bellagio - вегасовская классика")).Single().hotelId =
                dataBase.hotels.Where(hotel => hotel.name.Equals("Bellagio Las Vegas")).Select(hotel => hotel.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Крепкая 4-ка")).Single().hotelId =
                dataBase.hotels.Where(hotel => hotel.name.Equals("The Cosmopolitan of Las Vegas, Autograph Collection")).Select(hotel => hotel.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Неплохо")).Single().hotelId =
                dataBase.hotels.Where(hotel => hotel.name.Equals("The Cosmopolitan of Las Vegas, Autograph Collection")).Select(hotel => hotel.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Отличный пафосный отель")).Single().hotelId =
                dataBase.hotels.Where(hotel => hotel.name.Equals("The Venetian Resort")).Select(hotel => hotel.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Manuel worse manager in USA")).Single().hotelId =
                dataBase.hotels.Where(hotel => hotel.name.Equals("The Venetian Resort")).Select(hotel => hotel.id).Single();
            #endregion
        }

        public void createRestaurant()
        {
            #region Photo
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
            Photo photo13 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge.jpg"), name = @"img\Roosevelt-Lodge.jpg" };
            Photo photo14 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge1.jpg"), name = @"img\Roosevelt-Lodge1.jpg" };
            Photo photo15 = new Photo {image = Util.getByteImage(@"wwwroot\img\Roosevelt-Lodge2.jpg"), name = @"img\Roosevelt-Lodge2.jpg" };
            Photo photo16 = new Photo {image = Util.getByteImage(@"wwwroot\img\Lake-Yellowstone-dining.jpg"), name = @"img\Lake-Yellowstone-dining.jpg" };
            Photo photo17 = new Photo {image = Util.getByteImage(@"wwwroot\img\Lake-Yellowstone-dining1.jpg"), name = @"img\Lake-Yellowstone-dining1.jpg" };
            Photo photo18 = new Photo {image = Util.getByteImage(@"wwwroot\img\Lake-Yellowstone-dining2.jpg"), name = @"img\Lake-Yellowstone-dining2.jpg" };
            Photo photo19 = new Photo {image = Util.getByteImage(@"wwwroot\img\fishing-bridge-general.jpg"), name = @"img\fishing-bridge-general.jpg" };
            Photo photo20 = new Photo {image = Util.getByteImage(@"wwwroot\img\fishing-bridge-general1.jpg"), name = @"img\fishing-bridge-general1.jpg" };
            Photo photo21 = new Photo {image = Util.getByteImage(@"wwwroot\img\fishing-bridge-general2.jpg"), name = @"img\fishing-bridge-general2.jpg" };
            Photo photo22 = new Photo {image = Util.getByteImage(@"wwwroot\img\Chic-Cabaret.jpg"), name = @"img\Chic-Cabaret.jpg" };
            Photo photo23 = new Photo {image = Util.getByteImage(@"wwwroot\img\Chic-Cabaret1.jpg"), name = @"img\Chic-Cabaret1.jpg" };
            Photo photo24 = new Photo {image = Util.getByteImage(@"wwwroot\img\Chic-Cabaret2.jpg"), name = @"img\Chic-Cabaret2.jpg" };
            Photo photo25 = new Photo {image = Util.getByteImage(@"wwwroot\img\La-Yola-Restaurant.jpg"), name = @"img\La-Yola-Restaurant.jpg" };
            Photo photo26 = new Photo {image = Util.getByteImage(@"wwwroot\img\La-Yola-Restaurant1.jpg"), name = @"img\La-Yola-Restaurant1.jpg" };
            Photo photo27 = new Photo {image = Util.getByteImage(@"wwwroot\img\La-Yola-Restaurant2.jpg"), name = @"img\La-Yola-Restaurant2.jpg" };
            Photo photo28 = new Photo {image = Util.getByteImage(@"wwwroot\img\Pranama.jpg"), name = @"img\Pranama.jpg" };
            Photo photo29 = new Photo {image = Util.getByteImage(@"wwwroot\img\Pranama1.jpg"), name = @"img\Pranama1.jpg" };
            Photo photo30 = new Photo {image = Util.getByteImage(@"wwwroot\img\Pranama2.jpg"), name = @"img\Pranama2.jpg" };
            Photo photo31 = new Photo { image = Util.getByteImage(@"wwwroot\img\Shave-Ice.jpg"), name = @"img\Shave-Ice.jpg" };
            Photo photo32 = new Photo { image = Util.getByteImage(@"wwwroot\img\Shave-Ice1.jpg"), name = @"img\Shave-Ice1.jpg" };
            Photo photo33 = new Photo { image = Util.getByteImage(@"wwwroot\img\Shave-Ice2.jpg"), name = @"img\Shave-Ice2.jpg" };
            Photo photo34 = new Photo { image = Util.getByteImage(@"wwwroot\img\Maui-Thai-Bistro.jpg"), name = @"img\Maui-Thai-Bistro.jpg" };
            Photo photo35 = new Photo { image = Util.getByteImage(@"wwwroot\img\Maui-Thai-Bistro1.jpg"), name = @"img\Maui-Thai-Bistro1.jpg" };
            Photo photo36 = new Photo { image = Util.getByteImage(@"wwwroot\img\Maui-Thai-Bistro2.jpg"), name = @"img\Maui-Thai-Bistro2.jpg" };
            Photo photo37 = new Photo { image = Util.getByteImage(@"wwwroot\img\mamas-fish-house.jpg"), name = @"img\mamas-fish-house.jpg" };
            Photo photo38 = new Photo { image = Util.getByteImage(@"wwwroot\img\mamas-fish-house1.jpg"), name = @"img\mamas-fish-house1.jpg" };
            Photo photo39 = new Photo { image = Util.getByteImage(@"wwwroot\img\mamas-fish-house2.jpg"), name = @"img\mamas-fish-house2.jpg" };
            Photo photo40 = new Photo { image = Util.getByteImage(@"wwwroot\img\Bosphorous.jpg"), name = @"img\Bosphorous.jpg" };
            Photo photo41 = new Photo { image = Util.getByteImage(@"wwwroot\img\Bosphorous1.jpg"), name = @"img\Bosphorous1.jpg" };
            Photo photo42 = new Photo { image = Util.getByteImage(@"wwwroot\img\Bosphorous2.jpg"), name = @"img\Bosphorous2.jpg" };
            Photo photo43 = new Photo { image = Util.getByteImage(@"wwwroot\img\La-Luce.jpg"), name = @"img\La-Luce.jpg" };
            Photo photo44 = new Photo { image = Util.getByteImage(@"wwwroot\img\La-Luce1.jpg"), name = @"img\La-Luce1.jpg" };
            Photo photo45 = new Photo { image = Util.getByteImage(@"wwwroot\img\La-Luce2.jpg"), name = @"img\La-Luce2.jpg" };
            Photo photo46 = new Photo { image = Util.getByteImage(@"wwwroot\img\4-Smokehouse.jpg"), name = @"img\4-Smokehouse.jpg" };
            Photo photo47 = new Photo { image = Util.getByteImage(@"wwwroot\img\4-Smokehouse1.jpg"), name = @"img\4-Smokehouse1.jpg" };
            Photo photo48 = new Photo { image = Util.getByteImage(@"wwwroot\img\4-Smokehouse2.jpg"), name = @"img\4-Smokehouse2.jpg" };
            Photo photo49 = new Photo { image = Util.getByteImage(@"wwwroot\img\kekes.jpg"), name = @"img\kekes.jpg" };
            Photo photo50 = new Photo { image = Util.getByteImage(@"wwwroot\img\kekes1.jpg"), name = @"img\kekes1.jpg" };
            Photo photo51 = new Photo { image = Util.getByteImage(@"wwwroot\img\kekes2.jpg"), name = @"img\kekes2.jpg" };
            Photo photo52 = new Photo { image = Util.getByteImage(@"wwwroot\img\Golden-Goose.jpg"), name = @"img\Golden-Goose.jpg" };
            Photo photo53 = new Photo { image = Util.getByteImage(@"wwwroot\img\Golden-Goose1.jpg"), name = @"img\Golden-Goose1.jpg" };
            Photo photo54 = new Photo { image = Util.getByteImage(@"wwwroot\img\Golden-Goose2.jpg"), name = @"img\Golden-Goose2.jpg" };
            Photo photo55 = new Photo { image = Util.getByteImage(@"wwwroot\img\bella-vita-ristorante.jpg"), name = @"img\bella-vita-ristorante.jpg" };
            Photo photo56 = new Photo { image = Util.getByteImage(@"wwwroot\img\bella-vita-ristorante1.jpg"), name = @"img\bella-vita-ristorante1.jpg" };
            Photo photo57 = new Photo { image = Util.getByteImage(@"wwwroot\img\bella-vita-ristorante2.jpg"), name = @"img\bella-vita-ristorante2.jpg" };
            Photo photo58 = new Photo { image = Util.getByteImage(@"wwwroot\img\Elote-Cafe.jpg"), name = @"img\Elote-Cafe.jpg" };
            Photo photo59 = new Photo { image = Util.getByteImage(@"wwwroot\img\Elote-Cafe1.jpg"), name = @"img\Elote-Cafe1.jpg" };
            Photo photo60 = new Photo { image = Util.getByteImage(@"wwwroot\img\Elote-Cafe2.jpg"), name = @"img\Elote-Cafe2.jpg" };
            Photo photo61 = new Photo { image = Util.getByteImage(@"wwwroot\img\5-Napkin-Burger.jpg"), name = @"img\5-Napkin-Burger.jpg" };
            Photo photo62 = new Photo { image = Util.getByteImage(@"wwwroot\img\5-Napkin-Burger1.jpg"), name = @"img\5-Napkin-Burger1.jpg" };
            Photo photo63 = new Photo { image = Util.getByteImage(@"wwwroot\img\5-Napkin-Burger2.jpg"), name = @"img\5-Napkin-Burger2.jpg" };
            Photo photo64 = new Photo { image = Util.getByteImage(@"wwwroot\img\Obao.jpg"), name = @"img\Obao.jpg" };
            Photo photo65 = new Photo { image = Util.getByteImage(@"wwwroot\img\Obao1.jpg"), name = @"img\Obao1.jpg" };
            Photo photo66 = new Photo { image = Util.getByteImage(@"wwwroot\img\Obao2.jpg"), name = @"img\Obao2.jpg" };
            Photo photo67 = new Photo { image = Util.getByteImage(@"wwwroot\img\Bleecker-Street-Pizza.jpg"), name = @"img\Bleecker-Street-Pizza.jpg" };
            Photo photo68 = new Photo { image = Util.getByteImage(@"wwwroot\img\Bleecker-Street-Pizza1.jpg"), name = @"img\Bleecker-Street-Pizza1.jpg" };
            Photo photo69 = new Photo { image = Util.getByteImage(@"wwwroot\img\Bleecker-Street-Pizza2.jpg"), name = @"img\Bleecker-Street-Pizza2.jpg" };
            Photo photo70 = new Photo { image = Util.getByteImage(@"wwwroot\img\hello-froggies.jpg"), name = @"img\hello-froggies.jpg" };
            Photo photo71 = new Photo { image = Util.getByteImage(@"wwwroot\img\hello-froggies1.jpg"), name = @"img\hello-froggies1.jpg" };
            Photo photo72 = new Photo { image = Util.getByteImage(@"wwwroot\img\hello-froggies2.jpg"), name = @"img\hello-froggies2.jpg" };
            Photo photo73 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cirque.jpg"), name = @"img\Cirque.jpg" };
            Photo photo74 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cirque1.jpg"), name = @"img\Cirque1.jpg" };
            Photo photo75 = new Photo { image = Util.getByteImage(@"wwwroot\img\Cirque2.jpg"), name = @"img\Cirque2.jpg" };
            Photo photo76 = new Photo { image = Util.getByteImage(@"wwwroot\img\Triple-George-Grill.jpg"), name = @"img\Triple-George-Grill.jpg" };
            Photo photo77 = new Photo { image = Util.getByteImage(@"wwwroot\img\Triple-George-Grill1.jpg"), name = @"img\Triple-George-Grill1.jpg" };
            Photo photo78 = new Photo { image = Util.getByteImage(@"wwwroot\img\Triple-George-Grill2.jpg"), name = @"img\Triple-George-Grill2.jpg" };
            Photo photo79 = new Photo { image = Util.getByteImage(@"wwwroot\img\figo.jpg"), name = @"img\figo.jpg" };
            Photo photo80 = new Photo { image = Util.getByteImage(@"wwwroot\img\figo1.jpg"), name = @"img\figo1.jpg" };
            Photo photo81 = new Photo { image = Util.getByteImage(@"wwwroot\img\figo2.jpg"), name = @"img\figo2.jpg" };
            Photo photo82 = new Photo { image = Util.getByteImage(@"wwwroot\img\thegoldenchippy.jpg"), name = @"img\thegoldenchippy.jpg" };
            Photo photo83 = new Photo { image = Util.getByteImage(@"wwwroot\img\thegoldenchippy1.jpg"), name = @"img\thegoldenchippy1.jpg" };
            Photo photo84 = new Photo { image = Util.getByteImage(@"wwwroot\img\thegoldenchippy2.jpg"), name = @"img\thegoldenchippy2.jpg" };
            Photo photo85 = new Photo { image = Util.getByteImage(@"wwwroot\img\BaoziInn-Soho.jpg"), name = @"img\BaoziInn-Soho.jpg" };
            Photo photo86 = new Photo { image = Util.getByteImage(@"wwwroot\img\BaoziInn-Soho1.jpg"), name = @"img\BaoziInn-Soho1.jpg" };
            Photo photo87 = new Photo { image = Util.getByteImage(@"wwwroot\img\BaoziInn-Soho2.jpg"), name = @"img\BaoziInn-Soho2.jpg" };
            Photo photo88 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vegan-Ronin.jpg"), name = @"img\Vegan-Ronin.jpg" };
            Photo photo89 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vegan-Ronin1.jpg"), name = @"img\Vegan-Ronin1.jpg" };
            Photo photo90 = new Photo { image = Util.getByteImage(@"wwwroot\img\Vegan-Ronin2.jpg"), name = @"img\Vegan-Ronin2.jpg" };
            
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12, photo13, photo14, photo15, photo16, photo17, photo18, photo19, photo20, photo21, photo22, photo23, photo24, photo25, photo26, photo27, photo28, photo29, photo30, photo31, photo32, photo33, photo34, photo35, photo36, photo37, photo38, photo39, photo40, photo41, photo42, photo43, photo44, photo45, photo46, photo47, photo48, photo49, photo50, photo51, photo52, photo53, photo54, photo55, photo56, photo57, photo58, photo59, photo60, photo61, photo62, photo63, photo64, photo65, photo66, photo67, photo68, photo69, photo70, photo71, photo72, photo73, photo74, photo75, photo76, photo77, photo78, photo79, photo80, photo81, photo82, photo83, photo84, photo85, photo86, photo87, photo88, photo89, photo90);
            #endregion
            #region Restaurants
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
                timeEating = "Обед, Ужин, Открыто допоздна",
                services = "Бронирование, Столики на открытом воздухе, Банкет, Места для сидения, Имеется парковка, Утвержденная парковка, Услуги парковщика, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Бесплатный Wi-Fi, Принимаются кредитные карты, Обслуживание посетителей за столиками, На воде",
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
                timeEating = "Обед, Ужин, Открыто допоздна, Напитки",
                services = "Еда на вынос, Столики на открытом воздухе, Места для сидения, Парковка на улице, Телевизор, Подают алкоголь, Бар, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются только наличные, Бесплатный Wi-Fi, Принимаются кредитные карты, Обслуживание посетителей за столиками",
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
                timeEating = "Обед, Ужин",
                services = "Места для сидения, Имеется парковка, Парковка на улице, Подают алкоголь, Вино и пиво, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Бесплатный Wi-Fi, Бронирование, Столики на открытом воздухе, Доступ для кресел-каталок, Бар, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo10,
                photos = new List<Photo> {photo11, photo12},
            };
            //1 Йеллоустонский национальный парк, Вайоминг
            Restaurant restaurant5 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60999-d517927-Reviews-Roosevelt_Lodge_Dining_Room-Yellowstone_National_Park_Wyoming.html
                name = "Roosevelt Lodge Dining Room",
                location = "Tower-Roosevelt, Йеллоустонский национальный парк, WY 82190",
                phone = "+1 307-344-7311",
                webSite = "https://www.yellowstonenationalparklodges.com/restaurants/roosevelt-lodge-dining-room/",
                typeCuisine = "Американская",
                specialMenu = "Безглютеновые блюда",
                timeEating = "Завтрак, Обед, Ужин",
                services = "Места для сидения, Имеется парковка, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo13,
                photos = new List<Photo> {photo14, photo15},
            };
            Restaurant restaurant6 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60999-d519501-Reviews-Lake_Yellowstone_Hotel_Dining_Room-Yellowstone_National_Park_Wyoming.html
                name = "Lake Yellowstone Hotel Dining Room",
                location = "235 Yellowstone Lake Rd, Йеллоустонский национальный парк, WY 82190",
                phone = "+1 307-344-7311",
                webSite = "https://www.yellowstonenationalparklodges.com/restaurant/lake-hotel-dining-room/",
                typeCuisine = "Американская",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Завтрак, Обед, Ужин, Бранч, Открыто допоздна",
                services = "Бронирование, Места для сидения, Имеется парковка, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются кредитные карты, Обслуживание посетителей за столиками, Живая музыка, На воде",
                mainPhoto = photo16,
                photos = new List<Photo> { photo17, photo18 },
            };
            Restaurant restaurant7 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60999-d6979718-Reviews-Fishing_Bridge_General_Store-Yellowstone_National_Park_Wyoming.html
                name = "Fishing Bridge General Store",
                location = "1 East Entrance Road, Йеллоустонский национальный парк, WY",
                phone = "+1 406-586-7593",
                webSite = "https://www.yellowstonevacations.com/dining-shopping/in-park-dining",
                typeCuisine = "Американская, Закусочная",
                timeEating = "Ужин",
                services = "Места для сидения, Имеется парковка, Доступ для кресел-каталок, Еда на выно",
                mainPhoto = photo19,
                photos = new List<Photo> { photo20, photo21 },
            };
            //2 Пунта-Кана, Доминикана
            Restaurant restaurant8 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g147293-d19590095-Reviews-Chic_Cabaret_Restaurant_Punta_Cana-Punta_Cana_La_Altagracia_Province_Dominican_R.html
                name = "Chic Cabaret & Restaurant Punta Cana",
                location = "Avenida. Francia TRS Turquesa Hotel, Пунта-Кана Доминикана",
                phone = "+1 809-221-8149",
                webSite = "https://www.palladiumhotelgroup.com/es/chic-cabaret/trs-turquesa-hotel",
                typeCuisine = "Международная, Фьюжн",
                timeEating = "Ужин",
                services = "Бронирование, Подают алкоголь, Места для сидения, Обслуживание посетителей за столиками",
                mainPhoto = photo22,
                photos = new List<Photo> { photo23, photo24 },
            };
            Restaurant restaurant9 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g147293-d1050063-Reviews-La_Yola_Restaurant-Punta_Cana_La_Altagracia_Province_Dominican_Republic.html
                name = "La Yola Restaurant",
                location = "Punta Cana Marina Puntacana Resort & Club, Пунта-Кана 23000 Доминикана",
                phone = "+1 809-959-2262",
                webSite = "https://www.puntacana.com/",
                typeCuisine = "Карибская, Латиноамериканская, Морепродукты",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Открыто допоздна",
                services = "Бронирование, Столики на открытом воздухе, Места для сидения, Имеется парковка, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Бесплатный Wi-Fi, Принимаются кредитные карты, Обслуживание посетителей за столиками, Живая музыка, На воде",
                mainPhoto = photo25,
                photos = new List<Photo> { photo26, photo27 },
            };
            Restaurant restaurant10 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g147293-d8374536-Reviews-Pranama-Punta_Cana_La_Altagracia_Province_Dominican_Republic.html
                name = "Pranama",
                location = "Plaza El Dorado Local 103 a Bavaro., Пунта-Кана 23000 Доминикана",
                phone = "+1 829-768-6262",
                typeCuisine = "Индийская",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Ужин, Напитки, Открыто допоздна",
                services = "Еда на вынос, Бронирование, Столики на открытом воздухе, Места для сидения, Имеется парковка, Парковка на улице, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Вино и пиво, Принимаются карты Mastercard, Принимаются карты Visa, Бесплатная внеуличная стоянка, Принимаются карты American Express, Принимаются карты Discover, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo28,
                photos = new List<Photo> { photo29, photo30 },
            };
            //3 Остров Мауи, Гавайи
            Restaurant restaurant11 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60634-d1309100-Reviews-Ululani_s_Hawaiian_Shave_Ice-Lahaina_Maui_Hawaii.html
                name = "Ululani's Hawaiian Shave Ice",
                location = "790 Front St, Лахайна, Остров Мауи, HI 96761-2358",
                phone = "+1 808-877-3700",
                webSite = "https://www.ululanishawaiianshaveice.com/",
                typeCuisine = "Фастфуд, Гавайская",
                specialMenu = "Подходит для вегетарианцев, Безглютеновые блюда",
                timeEating = "Напитки",
                services = "Доступ для кресел-каталок, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются карты Discover, Еда на вынос, Столики на открытом воздухе, Принимаются кредитные карты",
                mainPhoto = photo31,
                photos = new List<Photo> { photo32, photo33 },
            };
            Restaurant restaurant12 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60632-d404430-Reviews-Maui_Thai_Bistro-Kihei_Maui_Hawaii.html
                name = "Maui Thai Bistro",
                location = "2439 S Kihei Rd #103b, Кихеи, Остров Мауи, HI 96753-7283",
                phone = "+1 808-874-5605",
                webSite = "https://www.mauithaibistro.com/",
                typeCuisine = "Современная, Азиатская, Тайская, Фьюжн",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Напитки, Обед, Ужин",
                services = "Места для сидения, Имеется парковка, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются карты Discover, Доставка, Еда на вынос, Бронирование, Бар, Принимаются кредитные карты, Обслуживание посетителей за столиками, Алкоголь приносить с собой",
                mainPhoto = photo34,
                photos = new List<Photo> { photo35, photo36 },
            };
            Restaurant restaurant13 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60636-d479164-Reviews-Mama_s_Fish_House-Paia_Maui_Hawaii.html
                name = "Mama's Fish House",
                location = "799 Poho Pl, Пайя, Остров Мауи, HI 96779-9708",
                phone = "+1 808-579-8488",
                webSite = "https://www.mamasfishhouse.com/",
                typeCuisine = "Американская, Гавайская",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин",
                services = "Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются карты Discover, Бронирование, Места для сидения, Имеется парковка, Услуги парковщика, Принимаются кредитные карты, Обслуживание посетителей за столиками, Живая музыка, На воде, Пляж",
                mainPhoto = photo37,
                photos = new List<Photo> { photo38, photo39 },
            };
            //4 Орландо, Флорида
            Restaurant restaurant14 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g34515-d12268188-Reviews-Bosphorous_Turkish_Cuisine-Orlando_Florida.html
                name = "Bosphorous Turkish Cuisine",
                location = "6900 Tavistock Lakes Blvd Suite 100, Орландо, FL 32827-7589",
                phone = "+1 407-313-2506",
                webSite = "https://www.bosphorousrestaurant.com/",
                typeCuisine = "Средиземноморская, Турецкая, Ближневосточная",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Халяль, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Открыто допоздна, Напитки",
                services = "Еда на вынос, Бронирование, Столики на открытом воздухе, Банкет, Места для сидения, Имеется парковка, Бесплатная внеуличная стоянка, Телевизор, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Бесплатный Wi-Fi, Принимаются карты Discover, Обслуживание посетителей за столиками, Подарочные карты",
                mainPhoto = photo40,
                photos = new List<Photo> { photo41, photo42 },
            };
            Restaurant restaurant15 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g34515-d1594156-Reviews-La_Luce-Orlando_Florida.html
                name = "La Luce",
                location = "14100 Bonnet Creek Resort Lane at Hilton Orlando Bonnet Creek, Орландо, FL 32821",
                phone = "+1 407-597-3676",
                webSite = "https://www.laluceorlando.com/?y_source=1_MTU0MDUzOTAtNzY5LWxvY2F0aW9uLndlYnNpdGU%3D",
                typeCuisine = "Итальянская, Пицца, Тосканская, Центрально-итальянская",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Ужин",
                services = "Столики на открытом воздухе, Места для сидения, Имеется парковка, Утвержденная парковка, Услуги парковщика, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Бесплатный Wi-Fi, Принимаются карты Discover, Бронирование, Банкет, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo43,
                photos = new List<Photo> { photo44, photo45 },
            };
            Restaurant restaurant16 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g34515-d6534372-Reviews-4_Rivers_Smokehouse-Orlando_Florida.html
                name = "4 Rivers Smokehouse",
                location = "11764 University Blvd, Орландо, FL 32817-2123",
                phone = "+1 844-474-8377",
                webSite = "https://www.4rsmokehouse.com/ucf-east-orlando/",
                typeCuisine = "Американская, Барбекю",
                timeEating = "Обед, Ужин",
                services = "Еда на вынос, Столики на открытом воздухе, Места для сидения, Имеется парковка, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Принимаются кредитные карты",
                mainPhoto = photo46,
                photos = new List<Photo> { photo47, photo48 },
            };
            Restaurant restaurant17 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g34515-d1507583-Reviews-Keke_s_Breakfast_Cafe-Orlando_Florida.html
                name = "Keke's Breakfast Cafe",
                location = "4192 Conroy Rd, Орландо, FL 32839-6416",
                phone = "+1 407-226-1400",
                webSite = "https://www.kekes.com/",
                typeCuisine = "Американская, Кафе",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Завтрак, Обед, Бранч",
                services = "Еда на вынос, Места для сидения, Имеется парковка, Детские стульчики для кормления, Доступ для кресел-каталок, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo49,
                photos = new List<Photo> { photo50, photo51 },
            };
            //5 Седона, Аризона
            Restaurant restaurant18 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g31352-d1918647-Reviews-Golden_Goose_American_Grill-Sedona_Arizona.html
                name = "Golden Goose American Grill",
                location = "2545 W State Route 89a, Седона, AZ 86336-5255",
                phone = "+1 928-282-1447",
                webSite = "http://goldengoosegrill.com/",
                typeCuisine = "Стейк-хаус, Морепродукты, Американская, Бар, Гриль",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Бранч",
                services = "Столики на открытом воздухе, Места для сидения, Имеется парковка, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются карты Discover, Еда на вынос, Бронирование, Принимаются карты American Express, Принимаются кредитные карты, Обслуживание посетителей за столиками, Подарочные карты",
                mainPhoto = photo52,
                photos = new List<Photo> { photo53, photo54 },
            };
            Restaurant restaurant19 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g31352-d7891345-Reviews-Bella_Vita_Ristorante-Sedona_Arizona.html
                name = "Bella Vita Ristorante",
                location = "6701 W State Route 89a Sedona Pines Resort, Седона, AZ 86336-9757",
                phone = "+1 928-282-4540",
                webSite = "http://www.bellavitasedona.com/",
                typeCuisine = "Итальянская",
                specialMenu = "Для веганов, Безглютеновые блюда",
                timeEating = "Ужин",
                services = "Еда на вынос, Бронирование, Места для сидения, Имеется парковка, Бесплатная внеуличная стоянка, Доступ для кресел-каталок, Подают алкоголь, Бар, Вино и пиво, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются карты Discover, Детские стульчики для кормления, Принимаются кредитные карты, Обслуживание посетителей за столиками, Живая музыка",
                mainPhoto = photo55,
                photos = new List<Photo> { photo56, photo57 },
            };
            Restaurant restaurant20 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g31352-d670560-Reviews-Elote_Cafe-Sedona_Arizona.html
                name = "Elote Cafe",
                location = "350 Jordan Road Sedona, Седона, AZ 86336-4830",
                phone = "+1 928-203-0105",
                webSite = "https://www.elotecafe.com/home",
                typeCuisine = "Мексиканская, Юговосточная",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Ужин",
                services = "Имеется парковка, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются карты Discover, Еда на вынос, Столики на открытом воздухе, Места для сидения, Бар, Принимаются кредитные карты, Обслуживание посетителей за столиками, Подарочные карты",
                mainPhoto = photo58,
                photos = new List<Photo> { photo59, photo60 },
            };
            //7 Нью-Йорк, Нью-Йорк
            Restaurant restaurant21 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60763-d4737024-Reviews-5_Napkin_Burger_Hell_s_Kitchen-New_York_City_New_York.html
                name = "5 Napkin Burger Hell's Kitchen",
                location = "630 9th Ave, Нью-Йорк, NY 10036",
                phone = "+1 212-757-2277",
                webSite = "https://5napkinburger.com/",
                typeCuisine = "Американская",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Бранч, Открыто допоздна",
                services = "Еда на вынос, Бронирование, Места для сидения, Телевизор, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo61,
                photos = new List<Photo> { photo62, photo63 },
            };
            Restaurant restaurant22 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60763-d5937621-Reviews-Obao-New_York_City_New_York.html
                name = "Obao",
                location = "647 9th Ave, Нью-Йорк, NY 10036-3661",
                phone = "+1 212-245-8880",
                webSite = "https://www.obaony.com/",
                typeCuisine = "Азиатская, Тайская, Вьетнамская, Здоровая",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Открыто допоздна",
                services = "Доставка, Еда на вынос, Бронирование, Места для сидения, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются кредитные карты, Обслуживание посетителей за столиками, Подарочные карты",
                mainPhoto = photo64,
                photos = new List<Photo> { photo65, photo66 },
            };
            Restaurant restaurant23 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g60763-d479337-Reviews-Bleecker_Street_Pizza-New_York_City_New_York.html
                name = "Bleecker Street Pizza",
                location = "69 7th Ave S at Bleecker Street Pizza, Нью-Йорк, NY 10014-4043",
                phone = "+1 212-924-4466",
                webSite = "https://www.bleeckerstreetpizza.com/",
                typeCuisine = "Итальянская, Пицца, Фастфуд",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Открыто допоздна",
                services = "Столики на открытом воздухе, Доставка, Еда на вынос, Места для сидения, Подают алкоголь, Вино и пиво, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются карты Discover, Принимаются кредитные карты",
                mainPhoto = photo67,
                photos = new List<Photo> { photo68, photo69 },
            };
            //8 Лас-Вегас, Невада
            Restaurant restaurant24 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g45963-d3293526-Reviews-Senor_Frog_s_Las_Vegas-Las_Vegas_Nevada.html
                name = "Senor Frog's Las Vegas",
                location = "3300 Las Vegas Blvd S, Лас-Вегас, NV 89109-8916",
                phone = "+1 702-912-9525",
                webSite = "https://senorfrogs.com/lasvegas",
                typeCuisine = "Мексиканская",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Открыто допоздна, Напитки",
                services = "Еда на вынос, Бронирование, Столики на открытом воздухе, Места для сидения, Телевизор, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются кредитные карты, Обслуживание посетителей за столиками, Живая музыка",
                mainPhoto = photo70,
                photos = new List<Photo> { photo71, photo72 },
            };
            Restaurant restaurant25 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g45963-d422749-Reviews-Le_Cirque-Las_Vegas_Nevada.html
                name = "Le Cirque",
                location = "3600 Las Vegas Blvd S, Лас-Вегас, NV 89109-4303",
                phone = "+1 702-693-8100",
                webSite = "https://bellagio.mgmresorts.com/en/restaurants/le-cirque.html",
                typeCuisine = "Французская",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Ужин",
                services = "Бесплатный Wi-Fi, Бронирование, Места для сидения, Имеется парковка, Услуги парковщика, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Принимаются карты Discover, Принимаются кредитные карты, Обслуживание посетителей за столиками, На воде",
                mainPhoto = photo73,
                photos = new List<Photo> { photo74, photo75 },
            };
            Restaurant restaurant26 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g45963-d618871-Reviews-Triple_George_Grill-Las_Vegas_Nevada.html
                name = "Triple George Grill",
                location = "201 N 3rd St, Лас-Вегас, NV 89101-2901",
                phone = "+1 702-384-2761",
                webSite = "https://www.triplegeorgegrill.com/",
                typeCuisine = "Американская, Бар",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Открыто допоздна, Напитки",
                services = "Еда на вынос, Столики на открытом воздухе, Места для сидения, Парковка на улице, Утвержденная парковка, Бесплатная внеуличная стоянка, Телевизор, Детские стульчики для кормления, Доступ для кресел-каталок, Подают алкоголь, Бар, Принимаются карты American Express, Принимаются карты Mastercard, Принимаются карты Visa, Бесплатный Wi-Fi, Принимаются карты Discover, Бронирование, Банкет, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo76,
                photos = new List<Photo> { photo77, photo78 },
            };
            //9 Лондон, UK
            Restaurant restaurant27 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g186338-d19727306-Reviews-Figo_Stratford-London_England.html
                name = "Figo Stratford",
                location = "Stratford 17 Endeavour Square, Лондон E20 1JN Англия",
                phone = "+44 20 8075 9899",
                webSite = "http://figorestaurant.co.uk/",
                typeCuisine = "Итальянская, Пицца, Средиземноморская, Неаполитанская, Кухня Кампании, Тосканская, Сицилийская, Центрально-итальянская, Южно-итальянская",
                specialMenu = "Подходит для вегетарианцев, Для веганов, Безглютеновые блюда",
                timeEating = "Обед, Ужин, Напитки",
                services = "Бронирование, Места для сидения, Детские стульчики для кормления, Подают алкоголь, Бар, Обслуживание посетителей за столиками",
                mainPhoto = photo79,
                photos = new List<Photo> { photo80, photo81 },
            };
            Restaurant restaurant28 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g186338-d5244301-Reviews-The_Golden_Chippy-London_England.html
                name = "The Golden Chippy",
                location = "62 Greenwich High Road, Лондон SE10 8LF Англия",
                phone = "+44 20 8692 4333",
                webSite = "https://www.thegoldenchippy.co.uk/",
                typeCuisine = "Морепродукты, Британская",
                timeEating = "Обед, Ужин",
                services = "Еда на вынос, Столики на открытом воздухе, Места для сидения, Доступ для кресел-каталок, Подают алкоголь, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo82,
                photos = new List<Photo> { photo83, photo84 },
            };
            Restaurant restaurant29 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g186338-d13597755-Reviews-BaoziInn_Soho-London_England.html
                name = "BaoziInn Soho",
                location = "24 Romilly Street, Лондон W1D 5AH Англия",
                phone = "+44 20 7287 3266",
                webSite = "https://baoziinn.com/",
                typeCuisine = "Китайская, Азиатская, Гриль, Уличная еда",
                specialMenu = "Подходит для вегетарианцев",
                timeEating = "Обед, Ужин, Открыто допоздна, Напитки",
                services = "Бронирование, Места для сидения, Подают алкоголь, Бесплатный Wi-Fi, Принимаются кредитные карты, Обслуживание посетителей за столиками",
                mainPhoto = photo85,
                photos = new List<Photo> { photo86, photo87 },
            };
            Restaurant restaurant30 = new Restaurant
            {
                //https://www.tripadvisor.ru/Restaurant_Review-g186338-d11752084-Reviews-Jhenn_of_the_Vegan_Ronin-London_England.html
                name = "Jhenn of the Vegan Ronin",
                location = "Лондон Англия",
                webSite = "https://www.eatwith.com/events/52551?affid=en-tripadvisor-partnership-london-h-445272&utm_campaign=en-tripadvisor-partnership-london-h-445272&utm_medium=partnership&utm_source=tripadvisor",
                typeCuisine = "Японская, Американская, Фьюжн",
                timeEating = "Обед, Ужин",
                services = "Бронирование, Банкет, Имеется парковка, Парковка на улице, Бесплатный Wi-Fi",
                mainPhoto = photo88,
                photos = new List<Photo> { photo89, photo90 },
            };
            dataBase.restaurants.AddRange(restaurant1, restaurant2, restaurant3, restaurant4, restaurant5, restaurant6, restaurant7, restaurant8, restaurant9, restaurant10, restaurant11, restaurant12, restaurant13, restaurant14, restaurant15, restaurant16, restaurant17, restaurant18, restaurant19, restaurant20, restaurant21, restaurant22, restaurant23, restaurant24, restaurant25, restaurant26, restaurant27, restaurant28, restaurant29, restaurant30);
            dataBase.SaveChanges();
            #endregion
            #region Reviews
            dataBase.reviews.Where(review => review.header.Equals("Вкусно!")).Single().restaurantId =
                dataBase.restaurants.Where(restaurant => restaurant.name.Equals("Senor Frog's Las Vegas")).Select(restaurant => restaurant.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Странный диско-барчик )")).Single().restaurantId =
                dataBase.restaurants.Where(restaurant => restaurant.name.Equals("Senor Frog's Las Vegas")).Select(restaurant => restaurant.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Незабываемый вечер")).Single().restaurantId =
                dataBase.restaurants.Where(restaurant => restaurant.name.Equals("Le Cirque")).Select(restaurant => restaurant.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("спокойно! цирк не уехал")).Single().restaurantId =
                dataBase.restaurants.Where(restaurant => restaurant.name.Equals("Le Cirque")).Select(restaurant => restaurant.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Неистово рекомендую!")).Single().restaurantId =
                dataBase.restaurants.Where(restaurant => restaurant.name.Equals("Triple George Grill")).Select(restaurant => restaurant.id).Single();
            dataBase.reviews.Where(review => review.header.Equals("Превосходные стейки")).Single().restaurantId =
                dataBase.restaurants.Where(restaurant => restaurant.name.Equals("Triple George Grill")).Select(restaurant => restaurant.id).Single();
            #endregion
        }
    }
}