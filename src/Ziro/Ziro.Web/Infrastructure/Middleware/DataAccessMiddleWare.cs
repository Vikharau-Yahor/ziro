using Microsoft.AspNetCore.Http;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ziro.Core.Business.Services;

namespace Ziro.Web.Infrastructure.Middleware
{
	public class DataAccessMiddleware
	{
		private readonly RequestDelegate _next;

		public DataAccessMiddleware(RequestDelegate next)
		{
			this._next = next;
		}

		public async Task InvokeAsync(HttpContext context, NHibernate.ISession session)
		{
			var transaction = session.BeginTransaction();
			try
			{
				await _next.Invoke(context);
			}
			catch(Exception)
			{
				if (transaction.IsActive)
					transaction.Rollback();
				throw;
			}
			finally
			{
				if (transaction.IsActive)
					transaction.Commit();
				session.Close();
			}
		}
	}
}
