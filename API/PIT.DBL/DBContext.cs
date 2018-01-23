using System;
using System.Collections.Generic;
using System.Text;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using PIT.DBL.Schema;

namespace PIT.DBL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        #region "Common Schema"

        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuTask> MenuTask { get; set; }
        public DbSet<SubTask> SubTask { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleTask> RoleTask { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<alertype> AlertType { get; set; }
        public DbSet<communicationstatus> CommunicationStatus { get; set; }
        public DbSet<communication> Communication { get; set; }


        #endregion

        #region "Store"
        public DbSet<Product> Product { get; set; }
        #endregion "End Region"

        #region "Gurudwara Project"
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Schedule> Schedule { get; set; }

        public DbSet<subscriber> Subscriber { get; set; }
        public DbSet<subscribergurudwara> SubscriberGurudwara { get; set; }




        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<GurudwaraServices> GurudwaraServices { get; set; }
        public DbSet<gallery> Gallery { get; set; }



        public DbSet<GalleryImage> GalleryImage { get; set; }
        public DbSet<gallery> gallery { get; set; }
        public DbSet<GalleryImage> GalleryImages { get; set; }

#endregion

        #region "Dictonary Project"
        public DbSet<Language> Language { get; set; }
        public DbSet<Source> Source { get; set; }

        public DbSet<Dictonarytb> Dictonarytb { get; set; }


        public DbSet<DictonaryLanguage> DictonaryLanguage { get; set; }
        public DbSet<DictonarySource> DictonarySource { get; set; }
        #endregion 


        #region "ColdStore Project"
        public DbSet<UnitMaster> UnitMaster { get; set; }
        public DbSet<Plans> Plans { get; set; }
        public DbSet<StoreFloor> StoreFloor { get; set; }
        public DbSet<StoreGadder> StoreGadder { get; set; }
        public DbSet<StoreRoom> StoreRoom { get; set; }
        #endregion 

    }
}