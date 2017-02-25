using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nol3.Communication.Tools
{
	public static class Disposable
	{
		public static TResult Using<TDisposable, TResult>(
			Func<TDisposable> disposableFactory,
			Func<TDisposable, TResult> map)
			where TDisposable : IDisposable
		{
			using (var disposable= disposableFactory())
			{
				return map(disposable);
			}
		}
	}
}
