using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;
using WP.Business.Business;
using WP.Business.IBusiness;
using WP.Repository.IRepository;
using WP.Repository.Repository;

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
            //GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}