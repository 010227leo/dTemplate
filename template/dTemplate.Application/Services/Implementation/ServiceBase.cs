using Hangerd;
using Hangerd.Components;
using Hangerd.Event.Bus;
using Hangerd.Repository;
using System;
using Hangerd.Entity;

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

		private readonly IEventBus _eventBus;

		protected IEventBus EventBus
		{
			get
			{
				if (_eventBus == null)
					throw new HangerdException("EventBus未初始化");

				return _eventBus;
			}
		}

		#endregion

		#region Constructors

		protected ServiceBase(IRepositoryContext unitOfWork, IEventBus eventBus)
		{
			_unitOfWork = unitOfWork;
			_eventBus = eventBus;
		}

		#endregion

		/// <summary>
		/// 从UnityContainer获取仓储实例，非泛型尽量使用构造函数注入
		/// </summary>
		/// <exception cref="System.NullReferenceException">repository is null</exception>
		protected static TRepository GetRepository<TRepository, TAccount>()
			where TRepository : IRepository<TAccount>
			where TAccount : EntityBase
		{
			var repository = LocalServiceLocator.GetService<TRepository>();

			if (repository == null)
				throw new NullReferenceException(
					string.Format("{0}, type:{1}", "仓储实例为null", typeof(TRepository).FullName));

			return repository;
		}

		/// <summary>
		/// Try doing something, catch HangerException or Exception
		/// </summary>
		protected static MessagedResult<TResult> TryOperate<TResult>(Func<TResult> operate,
			string successMessage = "操作成功", string failureMessage = "操作失败")
		{
			try
			{
				return new MessagedResult<TResult>(operate(), successMessage);
			}
			catch (HangerdException ex)
			{
				return new MessagedResult<TResult>(default(TResult), string.Format("{0}({1})", failureMessage, ex.Message));
			}
			catch (Exception ex)
			{
				LocalLoggingService.Exception(ex);

				return new MessagedResult<TResult>(default(TResult), string.Format("{0}({1})", failureMessage, "系统异常"));
			}
		}
	}
}
