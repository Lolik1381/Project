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
            createLandMarks();
            createDirection();
        }

        public void createUser()
        {
            Models.Photo photo1 = new Models.Photo { image = getByteImage(@"wwwroot\img\vail.jpg"), name = @"img\vail.jpg" };
            dataBase.photos.AddRange(photo1);

            Models.UserInfo userInfo1 = new Models.UserInfo { city = "Москва", country = "Россия", create = DateTime.Today };
            dataBase.userInfos.AddRange(userInfo1);

            Models.Profile profileForUser1 = new Models.Profile
            {
                name = "Юлия",
                lastName = "Раджабова",
                countPublications = 2,
                mainPhoto = photo1,
                userInfo = userInfo1,
                backgroundPhoto = photo1
            };
            dataBase.profiles.AddRange(profileForUser1);

            dataBase.SaveChanges();

            Models.User user1 = new Models.User
            {
                login = "admin",
                password = "admin",
                profile = profileForUser1
            };
            dataBase.users.AddRange(user1);

            dataBase.SaveChanges();
        }

        public void createLandmark()
        {
            Models.Photo photo1 = new Models.Photo { image = getByteImage(@"wwwroot\img\Upper_Geyser_Basin.jpg"), name = @"img\Upper_Geyser_Basin.jpg" };
            Models.Photo photo2 = new Models.Photo { image = getByteImage(@"wwwroot\img\Upper_Geyser_Basin_1.jpg"), name = @"img\Upper_Geyser_Basin_1.jpg" };
            Models.Photo photo3 = new Models.Photo { image = getByteImage(@"wwwroot\img\big_prisma.jpg"), name = @"img\big_prisma.jpg" };
            Models.Photo photo4 = new Models.Photo { image = getByteImage(@"wwwroot\img\azul.jpg"), name = @"img\azul.jpg" };
            Models.Photo photo5 = new Models.Photo { image = getByteImage(@"wwwroot\img\azul_1.jpg"), name = @"img\azul_1.jpg" };
            Models.Photo photo6 = new Models.Photo { image = getByteImage(@"wwwroot\img\hana.jpg"), name = @"img\hana.jpg" };
            Models.Photo photo7 = new Models.Photo { image = getByteImage(@"wwwroot\img\magic-kingdom.jpg"), name = @"img\magic-kingdom.jpg" };
            Models.Photo photo8 = new Models.Photo { image = getByteImage(@"wwwroot\img\universal.jpg"), name = @"img\universal.jpg" };
            Models.Photo photo9 = new Models.Photo { image = getByteImage(@"wwwroot\img\universal_1.jpg"), name = @"img\universal_1.jpg" };
            Models.Photo photo10 = new Models.Photo { image = getByteImage(@"wwwroot\img\soldiers-pass.jpg"), name = @"img\soldiers-pass.jpg" };
            Models.Photo photo11 = new Models.Photo { image = getByteImage(@"wwwroot\img\bridge-trail.jpg"), name = @"img\punta-kana.jpg" };
            Models.Photo photo12 = new Models.Photo { image = getByteImage(@"wwwroot\img\maya-museum.jpg"), name = @"img\maya-museum.jpg" };
            Models.Photo photo13 = new Models.Photo { image = getByteImage(@"wwwroot\img\El-Rey.jpg"), name = @"img\El-Rey.jpg" };
            Models.Photo photo14 = new Models.Photo { image = getByteImage(@"wwwroot\img\El-Rey_1.jpg"), name = @"img\El-Rey_1.jpg" };
            Models.Photo photo15 = new Models.Photo { image = getByteImage(@"wwwroot\img\playa-delfines.jpg"), name = @"img\playa-delfines.jpg" };
            Models.Photo photo16 = new Models.Photo { image = getByteImage(@"wwwroot\img\empire-state-building.jpg"), name = @"img\empire-state-building.jpg" };
            Models.Photo photo17 = new Models.Photo { image = getByteImage(@"wwwroot\img\Brooklyn-bridge.jpg"), name = @"img\Brooklyn-bridge.jpg" };
            Models.Photo photo18 = new Models.Photo { image = getByteImage(@"wwwroot\img\central-park.jpg"), name = @"img\central-park.jpg" };
            Models.Photo photo19 = new Models.Photo { image = getByteImage(@"wwwroot\img\Strip.jpg"), name = @"img\Strip.jpg" };
            Models.Photo photo20 = new Models.Photo { image = getByteImage(@"wwwroot\img\Nevada_garden.jpg"), name = @"img\Nevada_garden.jpg" };
            Models.Photo photo21 = new Models.Photo { image = getByteImage(@"wwwroot\img\Nevada_garden_1.jpg"), name = @"img\Nevada_garden_1.jpg" };
            Models.Photo photo22 = new Models.Photo { image = getByteImage(@"wwwroot\img\tower-of-London.jpg"), name = @"img\tower-of-London.jpg" };
            Models.Photo photo23 = new Models.Photo { image = getByteImage(@"wwwroot\img\tower-of-London_1.jpg"), name = @"img\tower-of-London_1.jpg" };
            Models.Photo photo24 = new Models.Photo { image = getByteImage(@"wwwroot\img\British-museum.jpg"), name = @"img\British-museum.jpg" };
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9, photo10, photo11, photo12, photo13, photo14, photo15, photo16, photo17, photo18, photo19, photo20, photo21, photo22, photo23, photo24);

            //direction1 - "Йеллоустонский национальный парк, Вайоминг"
            Models.Landmark landmark1 = new Models.Landmark 
            {
                name = "Upper Geyser Basin",
                rating = 5,
                photos = new List<Models.Photo> { photo1, photo2 },
             };
            Models.Landmark landmark2 = new Models.Landmark
            {
                name = "Большой призматический источник",
                rating = 4.9M,
                photos = new List<Models.Photo> { photo3 },
            };
            //direction2 - Пунта-Кана, Доминикана
            Models.Landmark landmark3 = new Models.Landmark
            {
                name = "Лагуна Азул",
                rating = 4.7M,
                photos = new List<Models.Photo> { photo5, photo4 },
            };
            //direction3 Остров Мауи, Гавайи
            Models.Landmark landmark4 = new Models.Landmark
            {
                name = "Hana Highway - Road to Hana",
                rating = 4.5M,
                photos = new List<Models.Photo> { photo6 },
            };
            //direction 4 Орландо, Флорида
            Models.Landmark landmark5 = new Models.Landmark
            {
                name = "Magic Kingdom",
                rating = 4.3M,
                photos = new List<Models.Photo> { photo7 },
            };
            Models.Landmark landmark6 = new Models.Landmark
            {
                name = "Universal Studios Florida",
                rating = 4.4M,
                photos = new List<Models.Photo> { photo8, photo9 },
            };
            //direction5 Седона, Аризона
            Models.Landmark landmark7 = new Models.Landmark
            {
                name = "Soldier Pass",
                rating = 4.4M,
                photos = new List<Models.Photo> { photo10},
            };
            Models.Landmark landmark8 = new Models.Landmark
            {
                name = "Devil's Bridge Trail",
                rating = 4,
                photos = new List<Models.Photo> { photo11 },
            };
            //direction 6 Канкун, Мексика
            Models.Landmark landmark9 = new Models.Landmark
            {
                name = "Mayan Museum of Cancun",
                rating = 4.2M,
                photos = new List<Models.Photo> { photo12 },
            };
            Models.Landmark landmark10 = new Models.Landmark
            {
                name = "Руины Эль-Рей",
                rating = 4,
                photos = new List<Models.Photo> { photo13, photo14},
            };
            Models.Landmark landmark11 = new Models.Landmark
            {
                name = "Пляж Playa Delfines",
                rating = 4.4M,
                photos = new List<Models.Photo> { photo15 },
            };
            //direction 7 Нью-Йорк, Нью-Йорк
            Models.Landmark landmark12 = new Models.Landmark
            {
                name = "Empire state building",
                rating = 3.9M,
                photos = new List<Models.Photo> { photo16},
            };
                Models.Landmark landmark13 = new Models.Landmark
                {
                    name = "Бруклинский мост",
                    rating = 4.3M,
                    photos = new List<Models.Photo> { photo17 },
                };
            Models.Landmark landmark14 = new Models.Landmark
            {
                name = "Центральный парк",
                rating = 4.4M,
                photos = new List<Models.Photo> { photo18 },
            };
            //direction 8 Лас-Вегас, Невада
            Models.Landmark landmark15 = new Models.Landmark
            {
                name = "The Strip",
                rating = 4.2M,
                photos = new List<Models.Photo> { photo19 },
            };
            Models.Landmark landmark16 = new Models.Landmark
            {
                name = "Bellagio Conservatory & Botanical Garden",
                rating = 4.3M,
                photos = new List<Models.Photo> { photo20, photo21 },
            };
            //direction 9 Лондон, UK
            Models.Landmark landmark17 = new Models.Landmark
            {
                name = "Лондонский Тауэр",
                rating = 4.4M,
                photos = new List<Models.Photo> { photo22, photo23 },
            };
            Models.Landmark landmark18 = new Models.Landmark
            {
                name = "Британский музей",
                rating = 4.5M,
                photos = new List<Models.Photo> { photo24 },
            };

            dataBase.landmarks.AddRange(landmark1, landmark2, landmark3, landmark4, landmark5, landmark6, landmark7, landmark8, landmark9, landmark10, landmark11, landmark12, landmark13, landmark14, landmark15, landmark16, landmark17, landmark18);
             
            dataBase.SaveChanges();
        }

        public void createDirection()
        {
            Models.Photo photo1 = new Models.Photo { image = getByteImage(@"wwwroot\img\yellowstone-national.jpg"), name = @"img\yellowstone-national.jpg" };
            Models.Photo photo2 = new Models.Photo { image = getByteImage(@"wwwroot\img\punta-kana.jpg"), name = @"img\punta-kana.jpg" };
            Models.Photo photo3 = new Models.Photo { image = getByteImage(@"wwwroot\img\mauyi.jpg"), name = @"img\mauyi.jpg" };
            Models.Photo photo4 = new Models.Photo { image = getByteImage(@"wwwroot\img\orlando.jpg"), name = @"img\orlando.jpg" };
            Models.Photo photo5 = new Models.Photo { image = getByteImage(@"wwwroot\img\sedona.jpg"), name = @"img\sedona.jpg" };
            Models.Photo photo6 = new Models.Photo { image = getByteImage(@"wwwroot\img\kankun.jpg"), name = @"img\kankun.jpg" };
            Models.Photo photo7 = new Models.Photo { image = getByteImage(@"wwwroot\img\new-york.jpg"), name = @"img\new-york.jpg" };
            Models.Photo photo8 = new Models.Photo { image = getByteImage(@"wwwroot\img\las-vegas.jpg"), name = @"img\las-vegas.jpg" };
            Models.Photo photo9 = new Models.Photo { image = getByteImage(@"wwwroot\img\london.jpg"), name = @"img\london.jpg" };
            dataBase.photos.AddRange(photo1, photo2, photo3, photo4, photo5, photo6, photo7, photo8, photo9);
            
            Models.Direction direction1 = new Models.Direction { 
                mainPhoto = photo1, 
                name = "Йеллоустонский национальный парк, Вайоминг",
                shortDescription = "Йеллоустонский национальный парк: обзор", 
                description = "Йеллоустоунский национальный парк, созданный в 1872 году, является подлинным национальным достоянием. Основная част парка расположена в Вайоминге, но частично парк также расположен в штатах Монтана и Айдахо. В Йеллоустоуне велика геотермальная активность; по всему парку можно найти гейзеры и бурлящие грязевые бассейны. Самым известным гейзером является Верный старик (Old Faithful): уже много лет его извержения происходят строго по часам. Путешественникам следует знать, что июль в Йеллоустоуне – месяц максимальной туристической активности. В этот период парк посещает около миллиона туристов. В парке существует система туристических автобусов, девять гостевых центров и 2 000 лагерей."
            };
            Models.Direction direction2 = new Models.Direction {
                mainPhoto = photo2, 
                name = "Пунта-Кана, Доминикана",
                shortDescription = "Прекрасные пляжи и расслабляющий отдых со всеми удобствами лишь часть очарования Пунта-Каны.", 
                description = "Пунта-Кана — это потрясающее место и настоящий источник самых разных удовольствий. Вы можете начать свой день на будто сошедшем с открыток пляже Макао, а закончить в ночном клубе в пещере. А когда Вы не нежитесь на солнце и не танцуете всю ночь напролет, каждую минуту Вас ждут другие развлечения, которые предлагают безупречные курорты Пунта-Каны, работающие по системе все включено, от потрясающего Hard Rock Punta Cana до безмятежного и уединенного Le Sivory Punta Cana. Насладившись теплым солнцем и белоснежным песком, попробуйте один из местных маршрутов канатного спуска, отправьтесь на остров Саона, познакомьтесь с историей Доминиканы в Альтос-де-Чавоне и посетите волшебные лагуны экологического парка Indigenous Eyes."
            };
            Models.Direction direction3 = new Models.Direction { 
                mainPhoto = photo3,
                name = "Остров Мауи, Гавайи", 
                shortDescription = "Радушный оазис для любителей природы, пляжи которого — воплощенная мечта",
                description = "Суровые вулканические пейзажи, изумрудные долины и пляжи с черным песком — Мауи воистину привносит драматический эффект. Конечно, здесь хватает курортов и отелей, однако Мауи не теряет своей самобытности в угоду туризму. Напротив, он остается верен живописной природе, гавайской культуре и духу Алоха. А вид на восход солнца с вершины вулкана Халеакала или поездка по шоссе Хана даже самого искушенного путешественника заставят подумать, что он попал в рай."
                
            };
            Models.Direction direction4 = new Models.Direction {
                mainPhoto = photo4, 
                name = "Орландо, Флорида",
                shortDescription = "Мечтаете побывать в волшебном мире Диснея? Вы найдете его в Орландо. Но возможности для семейного отдыха и развлечений на этом не заканчиваются.",
                description = "Орландо — город, полный чудес. Все они начинаются в Волшебном королевстве Диснея, но здесь есть и другие места, полные магического очарования. Те, кто молод, и те, кто молод душой, могут творить заклинания в Волшебном мире Гарри Поттера от Universal Studios или воплотить свои мечты о сафари в Царстве животных Диснея. И это только для начала. Насытившись острыми ощущениями, отправляйтесь насладиться потрясающей живой музыкой в таких заведениях, как B.B. King’s House of Blues, или изысканной кухней в одном из местных ресторанов, количество которых постоянно растет. А если захотите отдохнуть от переполняющих эмоций, здесь есть такие идиллические места, как ландшафтно-парковый комплекс Harry P. Leu Gardens, полный столь необходимыми Вам тишиной и покоем."
            };
            Models.Direction direction5 = new Models.Direction { 
                mainPhoto = photo5, 
                name = "Седона, Аризона",
                shortDescription = "Страна красных скал",
                description = "Седона — настоящий оазис посреди Аризонской пустыни, отрада глаз для отдыхающих. Здесь есть все, что только можно пожелать: курорты, спа, каньоны, красные скалы. Скала Белл-Рок и каньон Оак Крик — отличные места для хайкинга, а архитектура церкви Святого Креста сама по себе достойна восхищения. После заката начинается самое ценное представление, которое может предложить Седона: открывается вид на ночное небо."
            };
            Models.Direction direction6 = new Models.Direction {
                mainPhoto = photo6, 
                name = "Канкун, Мексика",
                shortDescription = "Конечно, море, солнце и глоток текилы по-прежнему воплощают душу Канкуна, но у него есть и более мягкая сторона.",
                description = "Когда-то изречение Вечная весна было неофициальным девизом Канкуна, но самый знаменитый город-праздник в Мексике — это не только идеальные пляжи и бесшабашные ночные клубы. Шикарные курортные отели, такие как Nizuc и Atelier Playa Mujeres, представляют высочайший уровень роскоши, а парк развлечений Xohimilco by Xcaret и впечатляющие пирамиды Чичен-Ицы прекрасно подходят для семейного времяпрепровождения. Если же Вы предпочитаете вечеринки, не волнуйтесь: в Канкуне есть все, что Вам нужно. В таких клубах, как Coco Bongo, The City и Hard Rock Cafe, Вы будете веселиться допоздна. А когда захотите сменить обстановку, белый песок и неоново-голубые воды Карибского моря будут Вас ждать всего в нескольких шагах от отеля." 
            };
            Models.Direction direction7 = new Models.Direction {
                mainPhoto = photo7, 
                name = "Нью-Йорк, Нью-Йорк",
                shortDescription = "Приезжайте сюда за своими заветными мечтами и ярким солнцем и оставайтесь ради местных красот и лучшей в мире пиццы.",
                description = "Самые высокие здания, самые большие музеи и лучшая пицца. Нью-Йорк — это город-гипербола, и обо всем здесь можно говорить в превосходной степени. От ошеломляющего Бродвея до галерей мирового класса MoMA, бутиков Сохо и множества ресторанов, предлагающих блюда из кухонь всех уголков мира. Каждый раз, когда Вы оказываетесь в Нью-Йорке, он открывается с новой стороны. Однако, помимо всех этих знаковых достопримечательностей, Вы можете обнаружить и более скрытую сторону Нью-Йорка. Возможно, даже во время короткой прогулки Вы наткнетесь на винтажные магазинчики инди и места, где местные жители любят проводить время за бранчем. А когда оживленные шумные улицы утомят Вас, просто посмотрите вверх: эти очертания на фоне неба напомнят, почему Вы здесь."
            };
            Models.Direction direction8 = new Models.Direction {
                mainPhoto = photo8, 
                name = "Лас-Вегас, Невада",
                shortDescription = "Азартные игроки или просто любопытствующие — в Лас-Вегасе найдутся развлечения на любой вкус.",
                description = "Отправьтесь в кулинарное путешествие по мишленовским ресторанам, попытайте удачу в знаменитых казино или сходите на великолепное представление. Простая прогулка по Лас-Вегас-Стрип заставит Ваши эндорфины вырабатываться с невероятной скоростью. А когда Вы устанете от этой суматохи, отправляйтесь в городские парки и природные заповедники или посетите Неоновый музей, где старые неоновые вывески обретают новую жизнь."
            };
            Models.Direction direction9 = new Models.Direction { 
                mainPhoto = photo9, 
                name = "Лондон, UK",
                shortDescription = "Царственный город в окружении суеты современной жизни",
                description = "Лондон полон истории: здесь Средневековье и Викторианская эпоха уживаются с роскошным и энергичным современным миром. Лондонский Тауэр и Вестминстер находятся по соседству с местными пабами и рынками, а устаревшие церемонии, например смена караула, происходят в то время, как пассажиры спешат в подземку. Это место, в котором путешественники могут перемещаться во времени, гуляя по городу, а устав, поступить так же, как лондонцы, то есть выпить чашечку чая."
            };
          
            dataBase.directions.AddRange(direction1, direction2, direction3, direction4, direction5, direction6, direction7, direction8, direction9);

            dataBase.SaveChanges();
        }

        public void createLandMarks()
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

            Models.Landmark landmark1 = new Models.Landmark {
                photos = new List<Models.Photo> { photo1, photo2 },
                name = "name",
                rating = 2
            };

            Models.Landmark landmark2 = new Models.Landmark
            {
                photos = new List<Models.Photo> { photo1, photo2 },
                name = "name",
                rating = 2
            };
            dataBase.landmarks.AddRange(landmark1, landmark2);

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