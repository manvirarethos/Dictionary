using AutoMapper;
using PIT.BAL.Model;
using PIT.DBL.Schema;

namespace PIT.BAL.Utility {
    public class AutomapperProfile : Profile 
    {

        public AutomapperProfile () {
            CreateMap<ApplicationUserModel, ApplicationUser> ().ReverseMap ();
            CreateMap<RoleModel, Role> ().ReverseMap ();
            CreateMap<RoleTaskModel, RoleTask> ().ReverseMap ();
            CreateMap<MenuModel, Menu> ().ReverseMap ();
            CreateMap<MenuTaskModel, MenuTask> ().ReverseMap ();
            CreateMap<UserRoleModel, UserRole> ().ReverseMap ();
            CreateMap<CompanyModel, Company> ().ReverseMap ();


      
            CreateMap<ApplicationUserModel, ApplicationUser>().ReverseMap();
            CreateMap<RoleModel, Role>().ReverseMap();
            CreateMap<RoleTaskModel, RoleTask>().ReverseMap();
            CreateMap<MenuModel, Menu>().ReverseMap();
            CreateMap<MenuTaskModel, MenuTask>().ReverseMap();
            CreateMap<UserRoleModel, UserRole>().ReverseMap();
            CreateMap<CompanyModel, Company>().ReverseMap();
            CreateMap<UserModel, User>().ReverseMap();
            

            #region "Store"
            CreateMap<ProductModel, Product> ().ReverseMap ();
            #endregion

            #region "Dictonary"
            CreateMap<LanguageModel, Language> ().ReverseMap ();
            CreateMap<SourceModel, Source> ().ReverseMap ();
            CreateMap<DictonarySourceModel, DictonarySource> ().ReverseMap ();
            CreateMap<DictonaryLanguageModel, DictonaryLanguage> ().ReverseMap ();
            CreateMap<DictonaryModel, Dictonarytb> ().ReverseMap ();
            #endregion

            #region "Gurudwara"
            CreateMap<ActivityModel, Activity> ().ReverseMap ();
            CreateMap<ScheduleModel, Schedule> ().ReverseMap ();
            CreateMap<subscriberModel, subscriber> ().ReverseMap ();
            CreateMap<AboutUsModel, AboutUs> ().ReverseMap ();
            CreateMap<ContactUsModel, ContactUs> ().ReverseMap ();
            CreateMap<GurudwaraServicesModel, GurudwaraServices> ().ReverseMap ();
            #endregion

            #region "ColdStore"
            CreateMap<UnitMasterModel, UnitMaster>().ReverseMap();
            CreateMap<PlansModel, Plans>().ReverseMap();
            CreateMap<StoreRoomModel, StoreRoom>().ReverseMap();
            CreateMap<StoreFloorModel, StoreFloor>().ReverseMap();
            CreateMap<StoreGadderModel, StoreGadder>().ReverseMap();
            #endregion

        
    }
}
}