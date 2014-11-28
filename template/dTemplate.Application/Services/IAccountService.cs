namespace dTemplate.Application.Services
{
	using dTemplate.Application.DataObjects;
	using System.Collections.Generic;

	public interface IAccountService
	{
		/// <summary>
		/// 根据ID获取Account
		/// </summary>
		AccountDto GetAccount(string id);

		/// <summary>
		/// 根据登录账号、密码获取Account
		/// </summary>
		MessagedResult<AccountDto> GetAccountForLogin(string loginName, string password);

		/// <summary>
		/// 获取Account列表
		/// </summary>
		IEnumerable<AccountDto> GetAccounts(int pageIndex, int pageSize, out int totalCount);

		/// <summary>
		/// 注册Account
		/// </summary>
		MessagedResult<bool> RegisterAccount(AccountDto accountDto);

		/// <summary>
		/// 更新Account
		/// </summary>
		MessagedResult<bool> UpdateAccount(string accountId, AccountDto accountDto);

		/// <summary>
		/// 修改Account密码
		/// </summary>
		MessagedResult<bool> ChangeAccountPassword(string accountId, string oldPassword, string newPassword);

		/// <summary>
		/// 删除Account
		/// </summary>
		MessagedResult<bool> RemoveAccount(string accountId);
	}
}
