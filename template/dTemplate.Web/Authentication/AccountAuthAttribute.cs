using System.Web;
using System.Web.Mvc;
using Hangerd.Mvc.Attributes;

namespace dTemplate.Web.Authentication
{
	public class AccountAuthAttribute : FormsAuthAttribute
	{
		public AccountAuthAttribute()
			: base("Login", "Account")
		{
			DefaultAjaxResult = "{\"Success\":false,\"Message\":\"操作失败，请重新登录\"}";
		}

		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			if (!base.AuthorizeCore(httpContext))
				return false;

			return AccountAuthContext.Current != null;
		}

		protected override void OnRolePrivilegeCheck(AuthorizationContext filterContext)
		{
		}
	}
}
