using CodingQuestion.GeometricCalculator;
using CodingQuestion.GeometricInterface;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CodingQuestion.GeometricAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here            
            container.RegisterType<ITriangleService, TriangleService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}