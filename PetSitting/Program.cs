
using System;
using System.Collections.Generic;
using System.Reflection;
using DALPetSitting;
using DALPetSitting.Services;
using DALPetSitting.Entities;

namespace PetSitting
{
    public class Program
    {
        /// <summary>
        /// Le programme console permet d'effectuer de tester la connection à la 
        /// base de données ainsi que les méthodes implémentées dans la DAL
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Test - Owner
            //Owner Alexandre = new Owner("Gavriilidis","Alexandre","test@gmail.com",new DateTime(1995,11,21),"Test1234=");
            //PetSitter Donald = new PetSitter("Trump", "Donald", "fake@news.com", new DateTime(1961, 5, 26), "AmericaFirst*16");

            //Advertissement add = new Advertissement("Test", "Beautiful description", Alexandre, new DateTime(2022,11,21)
            //    , new DateTime(2022,11,23));

            //foreach (PropertyInfo info in typeof(Advertissement).GetProperties())
            //{
            //    Console.WriteLine(info.GetValue(add));
            //}

            // TEST - DAL
            // Test - Owner
            //OwnerService ownerService = new OwnerService(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetSitting;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            // Test GetAll()
            //IEnumerable<Owner> owners = ownerService.GetAll();
            //foreach (Owner owner in owners)
            //{
            //    Console.WriteLine(owner.LastName);
            //}

            // Test - GetById()
            //string ownerLastName= ownerService.GetById(1);
            //Console.WriteLine(ownerLastName);

            // Test - Create()
            //int rows = ownerService.Create(new Owner{ LastName = "Trump",FirstName = "Donald", BirthDate = new DateTime (1957,06,20),Email="fakenews@gmail.com",Passwd="Test1234=*",Score=1 });

            // Test - Update()            
            //int row = ownerService.Update(new Owner { ID=4, LastName = "Depp", FirstName = "Johny", BirthDate = new DateTime(1975, 06, 20), Email = "pirates@gmail.com", Passwd = "Test1234=*", Score = 5 });

            // Test - Pet            
            //PetService petService = new PetService(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PetSitting; Integrated Security = True; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            // Test - GetAll()
            //IEnumerable<Pet> pets = petService.GetAll();
            //Console.WriteLine("ID | ID_Owner | NickName | Type");
            //foreach (Pet pet in pets)
            //{                
            //    Console.WriteLine(pet.ID +" "+pet.ID_Owner + " "+ pet.NickName+" "+pet.Type);
            //}

            // Test - GetById()
            //Console.WriteLine(petService.GetById(1));

            // test - GetByOwner()
            //IEnumerable<Pet> pets = petService.GetByOwner(1);
            //foreach (Pet pet in pets)
            //{
            //    Console.WriteLine(pet.ID + " " + pet.ID_Owner + " " + pet.NickName + " " + pet.Type);
            //}

            // Test - Create()
            //int row = petService.Create(new Pet() { ID_Owner = 4, NickName = "Filou", Type = "Chat", Breed = "Bleu Russe", BirthDate = new DateTime(2020,06,13)});

            // Test - Update()
            //int row = petService.Update(new Pet()
            //{
            //    ID = 3,
            //    ID_Owner = 1,
            //    NickName = "Padme",
            //    Type = "Chat",
            //    Breed = "British Shorthair",
            //    BirthDate = new DateTime(2020, 06, 13)
            //});

            // Test - PetSitter
            //PetSitterService petSitterService = new PetSitterService(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PetSitting; Integrated Security = True; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            // Test - GetAll()
            //IEnumerable<PetSitter> petSitters = petSitterService.GetAll();

            //foreach (PetSitter petSitter in petSitters)
            //{
            //    Console.WriteLine($"{petSitter.LastName}, {petSitter.PetPreference}");
            //}

            // Test - GetById()
            //string petSitterLastName = petSitterService.GetById(1);
            //Console.WriteLine(petSitterLastName);

            // Test - GetByPreference()
            //IEnumerable<PetSitter> petSitters = petSitterService.GetByPreference("chien");

            //foreach (PetSitter petSitter in petSitters)
            //{
            //    Console.WriteLine($"{petSitter.LastName}, {petSitter.PetPreference}");
            //}

            // Test - Update()
            //int rowAffected = petSitterService.Update(new PetSitter { ID = 1, LastName = "Van Haver", FirstName = "Paul", BirthDate = new DateTime(1985,03,12), Email = "alorson@danse.com",Passwd = "Stromae12*!", Score = 5, PetPreference="chien"});

            // Test - Add()
            //int rowAffected = petSitterService.Create(new PetSitter{ LastName = "Marley", FirstName = "Bob", BirthDate = new DateTime(1945,02,06), Email = "onelove@yahoo.com",Passwd = "OneLove1234=*",Score=4,PetPreference = "lapin" });

            // Test - Delete()
            //int rowAffected = petSitterService.Delete(3);

            // Test - Prestation
            //PrestationService prestationService = new PrestationService(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PetSitting; Integrated Security = True; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            // Test - GetAll()
            //IEnumerable<Prestation> prestations = prestationService.GetAll();
            //foreach (Prestation prestation in prestations)
            //{
            //    Console.WriteLine(prestation.DateStart);
            //}

            // Test - GetPrestationInfo()
            //IEnumerable<Prestation> prestations = prestationService.GetPrestationInfo(2);
            //foreach (Prestation prestation in prestations)
            //{
            //    Console.WriteLine(prestation.ID_PetSitter + " "+prestation.DateStart);
            //}

            //Test - Delete()
            //prestationService.Delete(10);

            // Test - Create()
            //prestationService.Create(new Prestation { ID_PetSitter = 1, DateStart = new DateTime(2022, 06, 13), DateEnd = new DateTime(2022, 06, 17) });

            // Test - Update()
            //prestationService.Update(new Prestation { ID = 12,ID_PetSitter = 2, DateStart = new DateTime(2022,06,08),DateEnd = new DateTime(2022,06,14) });

            // Test - Advertisement
            // Test - GetAll()
            //AdvertisementService advertisementService = new AdvertisementService(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PetSitting; Integrated Security = True; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            //IEnumerable<Advertisement> advertisements = advertisementService.GetAll();

            //foreach (Advertisement advertisement in advertisements)
            //{
            //    Console.WriteLine(advertisement.ID + " "+ advertisement.ID_Owner + " "+advertisement.ID_Prestation + " "+ advertisement.Title + " "+ advertisement.Description + " "+ advertisement.CreatedAt + " "+ advertisement.Region + " "+ advertisement.City + " "+ advertisement.DateStart + " " + advertisement.DateEnd);
            //}

            // test - GetByRegion()
            //IEnumerable<Advertisement> advertisements = advertisementService.GetByCity("Ixelles");

            //foreach (Advertisement advertisement in advertisements)
            //{
            //    Console.WriteLine(advertisement.ID + " " + advertisement.ID_Owner + " " + advertisement.ID_Prestation + " " + advertisement.Title + " " + advertisement.Description + " " + advertisement.CreatedAt + " " + advertisement.Region + " " + advertisement.City + " " + advertisement.DateStart + " " + advertisement.DateEnd);
            //}

            // Test - GetById()
            //IEnumerable<Advertisement> advertisements = advertisementService.GetById(7);
            //foreach (Advertisement advertisement in advertisements)
            //{
            //    Console.WriteLine(advertisement.ID + " " + advertisement.ID_Owner + " " + advertisement.ID_Prestation + " " + advertisement.Title + " " + advertisement.Description + " " + advertisement.CreatedAt + " " + advertisement.Region + " " + advertisement.City + " " + advertisement.DateStart + " " + advertisement.DateEnd);
            //}
            // Test - GetByOwner()
            //IEnumerable<Advertisement> advertisements = advertisementService.GetByOwner(1);
            //foreach (Advertisement advertisement in advertisements)
            //{
            //    Console.WriteLine(advertisement.ID + " " + advertisement.ID_Owner + " " + advertisement.ID_Prestation + " " + advertisement.Title + " " + advertisement.Description + " " + advertisement.CreatedAt + " " + advertisement.Region + " " + advertisement.City + " " + advertisement.DateStart + " " + advertisement.DateEnd);
            //}

            // Test - GetByRegion()
            //IEnumerable<Advertisement> advertisements = advertisementService.GetByRegion("Bruxelles");
            //foreach (Advertisement advertisement in advertisements)
            //{
            //    Console.WriteLine(advertisement.ID + " " + advertisement.ID_Owner + " " + advertisement.ID_Prestation + " " + advertisement.Title + " " + advertisement.Description + " " + advertisement.CreatedAt + " " + advertisement.Region + " " + advertisement.City + " " + advertisement.DateStart + " " + advertisement.DateEnd);
            //}

            //int rowAffected = advertisementService.Create(new Advertisement { ID_Owner = 3, ID_Prestation = 11, Title = "Deuxième annonce", Description = "Deuxième annonce ajoutée dans la base de donnée !" ,CreatedAt = new DateTime(2022,05,12),Region = "Wallonie", City = "Namur", DateStart = new DateTime(2022,05,16), DateEnd = new DateTime(2022,05,21) });

            // Test - Comment
            //CommentService commentService = new CommentService(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = PetSitting; Integrated Security = True; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");

            // Test - GetAll()
            //IEnumerable<Comment> comments = commentService.GetAll();

            //foreach (Comment comment in comments)
            //{
            //    Console.WriteLine(comment.ID_Prestation + " " + comment.ID_Owner + " " + comment.ID_PetSitter + " " + comment.Title + " " + comment.Description + " " + comment.CreatedAt + " " + comment.Score);
            //}
            // Test - GetAll(int id)
            //IEnumerable<Comment> comments = commentService.GetAll(9);

            //foreach (Comment comment in comments)
            //{
            //    Console.WriteLine(comment.ID_Prestation + " " + comment.ID_Owner + " " + comment.ID_PetSitter + " " + comment.Title + " " + comment.Description + " " + comment.CreatedAt + " " + comment.Score);
            //}

            // Test - GetById(int id)
            //string title = commentService.GetById(9);
            //Console.WriteLine(title);

            // Test - Update(Comment type)
            //int rowAffected = commentService.Update(new Comment { ID_Prestation = 2, ID_Owner = 1, ID_PetSitter = 1, Title = "Titre modifié via Update", Description = "La description a changé aussi hehe", CreatedAt = DateTime.Now, Score = 5 });

            // Test - Create(Comment type)
            //int rowAffected = commentService.Create(new Comment { ID_Prestation = 11, ID_Owner = 3, ID_PetSitter = 2, Title = "Génial !", Description = "Description d'un commentaire test", CreatedAt = DateTime.Now, Score = 4 });

            // test
            // Test - Owner
            //OwnerService ownerService = new OwnerService(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetSitting;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //Test GetAll() - Ok

            //IEnumerable<BLL.Owner> owners = ownerService.GetAll();
            //foreach (BLL.Owner owner in owners)
            //{
            //    Console.WriteLine(owner.LastName);
            //}

            // Test - Create() - Moyen
            // Demander Comment est ce qu'on peut ajouter un proprio sans fournir l'id, sans indiquer null
            //BLL.Owner ownerToAdd = new BLL.Owner(null,"Sale", "Ami", "saleami@tftic.com", new DateTime(1975, 06, 20), "Test1234=", 4);

            //BLL.Owner ownerToModify = new BLL.Owner(1002, "Bon", "Jam", "jambon@tftic.com", new DateTime(1975, 06, 20), "Test1234=", 4);

            //int rows = ownerService.Create(ownerToAdd);

            //Test - Update() - Ok
            //int row = ownerService.Update(ownerToModify);

            // Test pour Advertisement - Ok
            //BLL.Owner saleAmi = new BLL.Owner(null, "Sale", "Ami", "saleami@tftic.com", new DateTime(1975, 06, 20), "Test1234=", 4);

            //BLL.Advertisement advertisement = new BLL.Advertisement(null, "Recherche prestataire","En plein coeur de WSP, je cherche un pet-sitter pour mon chien","Bruxelles","Woluwe-Saint-Pierre", saleAmi,new DateTime(2022,05,26), new DateTime(2022,05,29),DateTime.Now);

            // Test PetSitterMapper - Ok
            //BLL.PetSitter petSitter = new BLL.PetSitter(null, "Trump", "Donald", "fake@news.com", new DateTime(1961, 5, 26), "AmericaFirst*16", 4);

            ////petSitter.ValidateName(petSitter.LastName, petSitter.FirstName);

            //petSitter.PetPreference = "Chien";

            //PetSitter petSitterEntity = petSitter.ToEntity();
            ////petSitterEntity.ValidateName(petSitterEntity.LastName, petSitterEntity.FirstName); pas accès Ok
            //Console.WriteLine(petSitterEntity.PetPreference);

            //Test PetSitter

            //PetSitterService petSitterService = new PetSitterService(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetSitting;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //IEnumerable<BLL.PetSitter> petSitters = petSitterService.GetAll();

            //foreach (BLL.PetSitter petSitter in petSitters)
            //{
            //    Console.WriteLine($"{ petSitter.Id} {petSitter.LastName} {petSitter.PetPreference}");
            //}

            //string petSitterLastName = petSitterService.GetById(1);

            //Console.WriteLine(petSitterLastName);

            // Test Advertisement
            //AdvertisementService advertisementService = new AdvertisementService(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetSitting;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //IEnumerable<BLL.Advertisement> advertisements = advertisementService.GetAll();

            //foreach (BLL.Advertisement advertisement in advertisements)
            //{
            //    Console.WriteLine($"{advertisement.Id} {advertisement.Id_Owner} {advertisement.City}");
            //}

            //BLL.Advertisement advertisement1 = new BLL.Advertisement(8,"Deuxième annonce modifiée","Modification","Bruxelles","Woluwe-Saint-Lambert", DateTime.Now, new DateTime(2022,05,28),DateTime.Now);

            //advertisement1.Id_Owner = 3;
            //advertisement1.Id_Prestation = 11;

            //advertisementService.Update(advertisement1);
            // test Pet

            //PetService petService = new PetService(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PetSitting;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //BLL.Pet pet = new BLL.Pet();
            //IEnumerable<BLL.Pet> pets = petService.GetAll();

            //foreach (BLL.Pet pet in pets)
            //{
            //    Console.WriteLine($"{pet.Id} {pet.NickName} {pet.Breed}");
            //}

            
        }
    }
}
