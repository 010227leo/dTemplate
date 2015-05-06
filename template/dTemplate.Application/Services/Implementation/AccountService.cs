using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dTemplate.Application.DataObjects;
using dTemplate.Domain.Models;
using dTemplate.Domain.Repositories;
using dTemplate.Domain.Services;
using dTemplate.Domain.Specifications;
using Hangerd;
using Hangerd.Extensions;
using Hangerd.Repository;

namespace dTemplate.Application.Services.Implementation
{
	public class AccountService : ServiceBase, IAccountService
	{
		#region Repository

		private readonly IAccountRepository _accountRepository;

		#endregion

		#region Services

		private readonly IAccountDomainService _accountDomainService;

		#endregion

		#region Constructors

		public AccountService(
			IRepositoryContext unitOfWork,
			IAccountRepository accountRepository,
			IAccountDomainService accountDomainService)
			: base(unitOfWork)
		{
			_accountRepository = accountRepository;
			_accountDomainService = accountDomainService;
		}

		#endregion

		public AccountDto GetAccount(string id)
		{
			return Mapper.Map<Account, AccountDto>(_accountRepository.Get(id, false));
		}

		public HangerdResult<AccountDto> GetAccountForLogin(string loginName, string password)
		{
			return TryOperate(() =>
			{
				if (string.IsNullOrWhiteSpace(loginName) || string.IsNullOrWhiteSpace(password))
					throw new HangerdException("用户名或密码为空");

				var spec = DeletableSpecifications<Account>.NotDeleted() & AccountSpecifications.LoginNameEquals(loginName);
				var account = _accountRepository.Get(spec, false);

				if (account == null)
					throw new HangerdException("用户名不存在");

				if (!account.ValidatePassword(password))
					throw new HangerdException("密码错误");

				return Mapper.Map<Account, AccountDto>(account);
			}, successMessage: "登录成功", failureMessage: "登录失败");
		}

		public IEnumerable<AccountDto> GetAccounts(int pageIndex, int pageSize, out int totalCount)
		{
			var accounts = _accountRepository.GetAll(DeletableSpecifications<Account>.NotDeleted(), false)
				.OrderByDescending(a => a.CreateTime)
				.Paging(pageIndex, pageSize, out totalCount);

			return Mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(accounts);
		}

		public HangerdResult<bool> RegisterAccount(AccountDto accountDto)
		{
			return TryOperate(() =>
			{
				var newAccount = _accountDomainService.RegisterNewAccount(accountDto.LoginName, accountDto.Password, accountDto.Name);

				_accountRepository.Add(newAccount);

				UnitOfWork.Commit();

				return true;
			}, successMessage: "注册成功", failureMessage: "注册失败");
		}

		public HangerdResult<bool> UpdateAccount(string accountId, AccountDto accountDto)
		{
			return TryOperate(() =>
			{
				var account = _accountRepository.Get(accountId, true);

				if (account == null)
					throw new HangerdException("账号信息不存在");

				account.Name = accountDto.Name;

				_accountRepository.Update(account);

				UnitOfWork.Commit();

				return true;
			});
		}

		public HangerdResult<bool> ChangeAccountPassword(string accountId, string oldPassword, string newPassword)
		{
			return TryOperate(() =>
			{
				var account = _accountRepository.Get(accountId, true);

				if (account == null)
					throw new HangerdException("账号信息不存在");

				if (!account.ValidatePassword(oldPassword))
					throw new HangerdException("原密码错误");

				account.ChangePassword(newPassword);

				_accountRepository.Update(account);

				UnitOfWork.Commit();

				return true;
			});
		}

		public HangerdResult<bool> RemoveAccount(string accountId)
		{
			return TryOperate(() =>
			{
				var account = _accountRepository.Get(accountId, true);

				if (account == null)
					throw new HangerdException("账号信息不存在");

				_accountRepository.Delete(account);

				UnitOfWork.Commit();

				return true;
			});
		}
	}
}
