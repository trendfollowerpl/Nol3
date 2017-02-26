using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Nol3.Communication.Tools
{
	public class IdGenerator : IDisposable
	{
		private int _id;
		private static IdGenerator _isnstance = null;
		private IdGenerator()
		{
			_id = Nol3ConfigurationManager.GetConfiguration().ID;
		}

		public static IdGenerator GetIDGenerator => _isnstance ?? (_isnstance = new IdGenerator());
		public string ID => Convert.ToString(++_id);
		public string CurrentID => Convert.ToString(_id);

		public void Close()
		{
			var config = Nol3ConfigurationManager.GetConfiguration();
			config.ID = _id;
			Nol3ConfigurationManager.SaveConfiguration(config);
			_isnstance = null;
		}

		public void Dispose()
		{
			Close();
		}
	}
}
