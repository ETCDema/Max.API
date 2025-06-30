using System;

using Max.API.Models;

namespace Max.API
{
	public partial class Client(string accessToken): IDisposable
	{
		public Bot Me()
		{
			return null!;
		}

		void IDisposable.Dispose()
		{
		}
	}
}
