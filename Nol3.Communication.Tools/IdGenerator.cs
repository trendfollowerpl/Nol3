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
		private static IdGenerator _idGenerator = null;
		private IdGenerator()
		{
			_id = Nol3ConfigurationManager.GetConfiguration().ID;
		}

		public static IdGenerator GetIDGenerator()
		{
			_idGenerator = _idGenerator == null ? new IdGenerator() : _idGenerator;
			return _idGenerator;
		}

		public string ID
		{
			get
			{
				return Convert.ToString(++_id);
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
			_idGenerator = null;
		}

		public void Dispose()
		{
			Close();
		}
	}
}
