using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIT.BAL.Utility
{
    public class Dependency
    {
        public static void AddToDependency(IServiceCollection services)
        {
            services.AddTransient<BAL.Interfaces.IAuth, BAL.Services.Auth>();
            services.AddScoped<BAL.Interfaces.IMenu, BAL.Services.MenuService>();
            services.AddScoped<BAL.Interfaces.IRole, BAL.Services.RoleService>();
            services.AddScoped<BAL.Interfaces.IMenuTask, BAL.Services.MenuTaskService>();
            services.AddScoped<BAL.Interfaces.IUser, BAL.Services.UserService>();

            #region "Dictonary"
            services.AddScoped<BAL.Interfaces.Dictonary.ILanguage, BAL.Services.Dictonary.LanguageService>();
            services.AddScoped<BAL.Interfaces.Dictonary.ISource, BAL.Services.Dictonary.SourceService>();
            services.AddScoped<BAL.Interfaces.Dictonary.IDictonary, BAL.Services.Dictonary.DictonaryService>();
            #endregion

            #region Gurudwara
            // services.AddScoped<BAL.Interfaces.IAboutUs, BAL.Services.AboutUsService>();
            // services.AddScoped<BAL.Interfaces.IContactUs, BAL.Services.ContactUsService>();
            services.AddScoped<BAL.Interfaces.IActivity, BAL.Services.ActivityService>();
            services.AddScoped<BAL.Interfaces.ISubscriber, BAL.Services.Gurudwara.SubscriberService>();
            services.AddScoped<BAL.Interfaces.ISchedule, BAL.Services.ScheduleService>();
             services.AddScoped<BAL.Interfaces.IGurudwaraServices, BAL.Services.GurudwaraService>();
            #endregion



            services.AddScoped<BAL.Interfaces.IUnitMaster, BAL.Services.UnitMasterService>();
            services.AddScoped<BAL.Interfaces.IPlans, BAL.Services.PlansService>();
            services.AddScoped<BAL.Interfaces.IStoreFloor, BAL.Services.StoreFloorService>();
            services.AddScoped<BAL.Interfaces.IStoreGadder, BAL.Services.StoreGadderService>();
            services.AddScoped<BAL.Interfaces.IStoreRoom, BAL.Services.StoreRoomService>();


            services.AddScoped<BAL.Interfaces.ICommunication, BAL.Services.CommunicationService>();
            services.AddScoped<BAL.Interfaces.IProduct, BAL.Services.ProductService>();
            services.AddScoped<BAL.Interfaces.ICompany, BAL.Services.CompanyService>();

        }
    }
}