namespace dTemplate.Web
{
	using dTemplate.Web.Models;
	using Hangerd.Mvc.Attributes;
	using System.Web;
	using System.Web.Mvc;

	public class AccountLoginAuthAttribute : LoginAuthAttribute
	{
		public AccountLoginAuthAttribute()
			: base("Login", "Account")
		{
			this.DefaultAjaxResult = "{\"Success\":false,\"Message\":\"操作失败，请重新登录\"}";
		}

		protected override bool LoginAuthorizeCore(HttpContextBase httpContext)
		{
			if (base.LoginAuthorizeCore(httpContext))
			{
				if (LoginAccountModel.Current != null)
				{
					return true;
				}
			}

			return false;
		}

		protected override void OnRolePrivilegeCheck(AuthorizationContext filterContext)
		{
			return;
		}
	}
}
