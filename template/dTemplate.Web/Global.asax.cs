namespace dTemplate.Web
{
	using Hangerd;
	using Hangerd.Components;
	using Hangerd.Repository;
	using System;
	using System.Web.Mvc;
	using System.Web.Routing;


    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

			HangerdFramework.Start();
        }

		protected void Application_End()
		{
			HangerdFramework.End();
		}

		protected void Application_EndRequest(object sender, EventArgs e)
		{
			var unitOfWork = LocalServiceLocator.GetService<IRepositoryContext>();

			if (unitOfWork != null)
			{
				unitOfWork.Dispose();
			}
		}
    }
}
