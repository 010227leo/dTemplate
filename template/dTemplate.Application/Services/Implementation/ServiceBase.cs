namespace dTemplate.Application.Services.Implementation
{
	using Hangerd;
	using Hangerd.Components;
	using Hangerd.Event.Bus;
	using Hangerd.Repository;
	using System;

	public class ServiceBase
	{
		#region Unit of work

		private readonly IRepositoryContext _unitOfWork;

		protected IRepositoryContext UnitOfWork
		{
			get 
			{
				if (_unitOfWork == null)
				{
					throw new HangerdException("UnitOfWork未初始化");
				}

				return _unitOfWork; 
			}
		}

		private readonly IEventBus _eventBus;

		protected IEventBus EventBus
		{
			get
			{
				if (_eventBus == null)
				{
					throw new HangerdException("EventBus未初始化");
				}

				return _eventBus;
			}
		}

		#endregion

		#region Constructors

		public ServiceBase(IRepositoryContext unitOfWork = null, IEventBus eventBus = null)
		{
			_unitOfWork = unitOfWork;
			_eventBus = eventBus;
		}

		#endregion

		/// <summary>
		/// Try doing something, catch HangerException or Exception
		/// </summary>
		/// <typeparam name="TResult">return value</typeparam>
		/// <param name="operate">something to do</param>
		/// <param name="successMessage">success message</param>
		/// <param name="exceptionMessageFormat">exception message format: {0}-exceptionMessage; {1}-ex.Message</param>
		/// <param name="failureMessage">exception message</param>
		/// <returns></returns>
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
