using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WP.Business.Business;
using WP.Business.Business.Event;
using WP.Business.Business.Master;
using WP.Business.IBusiness;
using WP.Business.IBusiness.IEvent;
using WP.Business.IBusiness.IMaster;
using WP.Repository.IRepository;
using WP.Repository.IRepository.IEvent;
using WP.Repository.IRepository.IMaster;
using WP.Repository.Repository;
using WP.Repository.Repository.Event;
using WP.Repository.Repository.Master;

namespace WP.Business
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
        
            container.RegisterType<IUserLoginRepository, UserLoginRepository>();
            container.RegisterType<IUserLoginBusiness, UserLoginBusiness>();

            container.RegisterType<IRegisterUserRepository, RegisterUserRepository>();
            container.RegisterType<IUserRegistrationBusiness, UserRegistrationBusiness>();

            container.RegisterType<IMembershipBusiness, MembershipBusiness>();
            container.RegisterType<IMembershipRepository, MembershipRepository>();
            container.RegisterType<ICheckUserSubscriptionRepository, CheckUserSubscriptionRepository>();
            container.RegisterType<ICheckUserSubscriptionBusiness, CheckUserSubscriptionBusiness>();

            container.RegisterType<IEventBookingRepository, EventBookingRepository>();
            container.RegisterType<IEventBookingBusiness, EventBookingBusiness>();

            container.RegisterType<IEventBusiness, EventBusiness>();
            container.RegisterType<IEventRepository, EventRepository>();

            container.RegisterType<ICheckEventRepository, CheckEventRepository>();
            container.RegisterType<ICheckEventBusiness, CheckEventBusiness>();

            container.RegisterType<IHomePageBusiness, HomePageBusiness>();
            container.RegisterType<IHomePageRepository, HomePageRepository>();

            container.RegisterType<IProductBusiness, ProductBusiness>();
            container.RegisterType<IProductRepository, ProductRepository>();




            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}