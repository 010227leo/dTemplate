namespace dTemplate.Application.DataObjects
{
	using System;

	public class AccountDto : DtoBase
	{
		/// <summary>
		/// 登录账号
		/// </summary>
		public string LoginName { get; set; }

		/// <summary>
		/// 密码
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		/// 姓名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime { get; set; }
	}
}
