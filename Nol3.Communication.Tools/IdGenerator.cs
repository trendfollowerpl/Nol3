using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Nol3.Communication.Tools
{
	public class IdGenerator:IDisposable
	{
		private int _id;
		public IdGenerator()
		{
			_id = Nol3ConfigurationManager.GetConfiguration().ID;
		}
		public string ID
		{
			get
			{
				_id = Math.Max(_id, Nol3ConfigurationManager.GetConfiguration().ID);
				_id++;
				return Convert.ToString(_id);
			}
		}
		public string CurrentID
		{
			get
			{
				return 
					Convert.ToString(_id);
			}
		}
		public void Close()
		{
			var config = Nol3ConfigurationManager.GetConfiguration();
			config.ID = _id;
			Nol3ConfigurationManager.SaveConfiguration(config);
		}

		public void Dispose()
		{
			Close();
		}
	}
}
