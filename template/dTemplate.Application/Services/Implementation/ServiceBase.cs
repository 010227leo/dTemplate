using System;
using Hangerd;
using Hangerd.Components;
using Hangerd.Repository;

namespace dTemplate.Application.Services.Implementation
{
	public class ServiceBase
	{
		#region Unit of work

		private readonly IRepositoryContext _unitOfWork;

		protected IRepositoryContext UnitOfWork
		{
			get 
			{
				if (_unitOfWork == null)
					throw new HangerdException("UnitOfWork未初始化");

				return _unitOfWork; 
			}
		}

		#endregion

		#region Constructors

		protected ServiceBase(IRepositoryContext unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#endregion

		/// <summary>
		/// Try doing something, catch HangerException or Exception
		/// </summary>
		protected static HangerdResult<TResult> TryOperate<TResult>(Func<TResult> operate,
			string successMessage = "操作成功", string failureMessage = "操作失败")
		{
			try
			{
				return new HangerdResult<TResult>(operate(), successMessage);
			}
			catch (HangerdException ex)
			{
				return new HangerdResult<TResult>(default(TResult), string.Format("{0}({1})", failureMessage, ex.Message));
			}
			catch (Exception ex)
			{
				LocalLoggingService.Exception(ex);

				return new HangerdResult<TResult>(default(TResult), string.Format("{0}({1})", failureMessage, "系统异常"));
			}
		}
	}
}
