namespace dTemplate.Domain.Models
{
	using Hangerd;
	using Hangerd.Entity;
	using Hangerd.Utility;
	using System;

	public class Account : EntityBase, IDeletable, IValidatable
	{
		#region Public Properties

		/// <summary>
		/// 登录账号
		/// </summary>
		public string LoginName { get; private set; }

		/// <summary>
		/// 登录密码（加密后）
		/// </summary>
		public string EncryptedPassword { get; private set; }

		/// <summary>
		/// 姓名
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime { get; private set; }

		/// <summary>
		/// IDeletable
		/// </summary>
		public bool IsDeleted { get; set; }

		#endregion

		#region Constructors

		protected Account() { }

		public Account(string loginName, string unencryptedPassword, string name)
		{
			if (string.IsNullOrWhiteSpace(loginName))
			{
				throw new HangerdException("登录账号不可为空");
			}

			if (!ValidationHelper.IsEmailAddress(loginName))
			{
				throw new HangerdException("登录账号须为邮箱地址");
			}

			this.LoginName = loginName;
			this.EncryptedPassword = this.GetEncryptedPassword(unencryptedPassword);
			this.Name = name;
			this.CreateTime = DateTime.Now;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// IValidatable
		/// </summary>
		public void Validate()
		{
			if (string.IsNullOrWhiteSpace(this.Name))
			{
				throw new HangerdException("姓名不可为空");
			}
		}

		/// <summary>
		/// 验证密码
		/// </summary>
		public bool ValidatePassword(string unencryptedPassword)
		{
			var encryptedPassword = this.GetEncryptedPassword(unencryptedPassword);

			return encryptedPassword.Equals(this.EncryptedPassword);
		}

		/// <summary>
		/// 修改密码
		/// </summary>
		public void ChangePassword(string unencryptedPassword)
		{
			this.EncryptedPassword = this.GetEncryptedPassword(unencryptedPassword);
		}

		#endregion

		#region Private Methods

		/// <summary>
		/// 密码加密
		/// </summary>
		private string GetEncryptedPassword(string unencryptedPassword)
		{
			if (string.IsNullOrWhiteSpace(unencryptedPassword))
			{
				throw new HangerdException("密码不可为空");
			}

			return CryptoHelper.GetMd5(unencryptedPassword);
		}

		#endregion
	}
}
