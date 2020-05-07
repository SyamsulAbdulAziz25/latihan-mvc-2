using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using Sport.Core;
using SportEvent.Controllers;
using SportEvent.Core;
using SportEvent.Core.Output;
using SportEvent.DataAccesLayer.Implements;

namespace EventSportAplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Event, SportEventOutput>();
                cfg.CreateMap<SportEventOutput, Event>();

            });


            // only during development, validate your mappings; remove it before release

            //this yesterday make error
            //configuration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            var mapper = configuration.CreateMapper();

            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // Register your types, for instance:
            container.Register<ISportEventRepository, SportEventRepository>(Lifestyle.Scoped);
            container.Register<ISportEventBussinesLayer, SportEventBussinesLayer>(Lifestyle.Scoped);
            container.Register<IRepository<Event>, Repository<Event>>(Lifestyle.Scoped);
            container.RegisterSingleton(() => GetMapper(container));


            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }

        private AutoMapper.IMapper GetMapper(Container container)
        {
            var mp = container.GetInstance<MapperProvider>();
            return mp.GetMapper();
        }

    }
    public class MapperProvider
    {
        private readonly Container _container;

        public MapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(_container.GetInstance);

            mce.AddProfile(new SomeProfile());

            var mc = new MapperConfiguration(mce);
            //mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => _container.GetInstance(t));

            return m;
        }
    }

    public class SomeProfile : Profile
    {
        public SomeProfile()
        {

            CreateMap<Event, SportEventOutput>();
            CreateMap<SportEventOutput, Event>();
        }
    }


}
