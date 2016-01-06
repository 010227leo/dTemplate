using System;
using Hangerd;
using Hangerd.Components;
using Hangerd.Domain.Repository;
using Hangerd.Uow;

namespace dTemplate.Infrastructure
{
	public class dTemplateServiceBase
	{
		protected static IRepositoryUow BeginContext()
		{
			return UnitOfWorkManager.Begin<IRepositoryUow>();
		}

		protected static HangerdResult<TResult> TryReturn<TResult>(Func<TResult> operate, Action final = null,
			string successMessage = null)
		{
			try
			{
				return new HangerdResult<TResult>(operate(), successMessage ?? "操作成功");
			}
			catch (HangerdException ex)
			{
				return new HangerdResult<TResult>(default(TResult), ex.Message);
			}
			catch (Exception ex)
			{
				LocalLoggingService.Exception(ex);

				return new HangerdResult<TResult>(default(TResult), "系统异常,请在日志中查看详情");
			}
			finally
			{
				if (final != null)
					final();
			}
		}

		protected static HangerdResult<bool> TryOperate(Action operate, Action final = null, string successMessage = null)
		{
			return TryReturn(() =>
			{
				operate();

				return true;
			}, final, successMessage);
		}
	}
}
