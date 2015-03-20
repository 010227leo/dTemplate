using dTemplate.Web.Models;
using Hangerd.Mvc.Attributes;
using System.Web;
using System.Web.Mvc;

namespace dTemplate.Web
{
	public class AccountLoginAuthAttribute : LoginAuthAttribute
	{
		public AccountLoginAuthAttribute()
			: base("Login", "Account", string.Empty)
		{
			DefaultAjaxResult = "{\"Success\":false,\"Message\":\"操作失败，请重新登录\"}";
		}

		protected override bool LoginAuthorizeCore(HttpContextBase httpContext)
		{
			if (!base.LoginAuthorizeCore(httpContext))
				return false;

			return LoginAccountModel.Current != null;
		}

		protected override void OnRolePrivilegeCheck(AuthorizationContext filterContext)
		{
		}
	}
}
