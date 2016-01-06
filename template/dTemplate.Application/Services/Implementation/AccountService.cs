﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using dTemplate.Application.Dtos;
using dTemplate.Domain.Models;
using dTemplate.Domain.Repositories;
using dTemplate.Domain.Services;
using dTemplate.Domain.Specifications;
using dTemplate.Infrastructure;
using Hangerd;
using Hangerd.Extensions;
using Hangerd.Validation;

namespace dTemplate.Application.Services.Implementation
{
	public class AccountService : dTemplateServiceBase, IAccountService
	{
		#region Repository & Services

		private readonly IAccountRepository _accountRepository;
		private readonly IAccountDomainService _accountDomainService;

		#endregion

		public AccountService(
			IAccountRepository accountRepository,
			IAccountDomainService accountDomainService)
		{
			_accountRepository = accountRepository;
			_accountDomainService = accountDomainService;
		}

		public AccountDto GetAccount(string id)
		{
			using (BeginContext())
			{
				return Mapper.Map<Account, AccountDto>(_accountRepository.Get(id, false));
			}
		}

		public HangerdResult<AccountDto> GetAccountForLogin(string loginName, string password)
		{
			return TryReturn(() =>
			{
				using (BeginContext())
				{
					if (string.IsNullOrWhiteSpace(loginName) || string.IsNullOrWhiteSpace(password))
						throw new HangerdException("用户名或密码为空");

					var spec = DeletableSpecifications<Account>.NotDeleted() & AccountSpecifications.LoginNameEquals(loginName);
					var account = _accountRepository.Get(spec, false);

					Requires.NotNull(account, "用户名不存在");

					if (!account.ValidatePassword(password))
						throw new HangerdException("密码错误");

					return Mapper.Map<Account, AccountDto>(account);
				}
			}, successMessage: "登录成功");
		}

		public IEnumerable<AccountDto> GetAccounts(int pageIndex, int pageSize, out int totalCount)
		{
			using (BeginContext())
			{
				var accounts = _accountRepository.GetAll(DeletableSpecifications<Account>.NotDeleted(), false)
					.OrderByDescending(a => a.CreateTime)
					.Paging(pageIndex, pageSize, out totalCount);

				return Mapper.Map<IEnumerable<Account>, IEnumerable<AccountDto>>(accounts);
			}
		}

		public HangerdResult<bool> RegisterAccount(AccountDto accountDto)
		{
			return TryOperate(() =>
			{
				using (var context = BeginContext())
				{
					var newAccount = _accountDomainService.RegisterNewAccount(
						_accountRepository, accountDto.LoginName, accountDto.Password, accountDto.Name);

					_accountRepository.Add(newAccount);

					context.Commit();
				}
			}, successMessage: "注册成功");
		}

		public HangerdResult<bool> UpdateAccount(string accountId, AccountDto accountDto)
		{
			return TryOperate(() =>
			{
				using (var context = BeginContext())
				{
					var account = _accountRepository.Get(accountId, true);

					Requires.NotNull(account, "账号信息不存在");

					account.Name = accountDto.Name;

					context.Commit();
				}
			});
		}

		public HangerdResult<bool> ChangeAccountPassword(string accountId, string oldPassword, string newPassword)
		{
			return TryOperate(() =>
			{
				using (var context = BeginContext())
				{
					var account = _accountRepository.Get(accountId, true);

					Requires.NotNull(account, "账号信息不存在");
				
					if (!account.ValidatePassword(oldPassword))
						throw new HangerdException("原密码错误");

					account.ChangePassword(newPassword);

					context.Commit();
				}
			});
		}

		public HangerdResult<bool> RemoveAccount(string accountId)
		{
			return TryOperate(() =>
			{
				using (var context = BeginContext())
				{
					var account = _accountRepository.Get(accountId, true);

					Requires.NotNull(account, "账号信息不存在");

					_accountRepository.Delete(account);

					context.Commit();
				}
			});
		}
	}
}
