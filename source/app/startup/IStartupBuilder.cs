using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.startup
{
	public interface IStartupBuilder
	{
		IStartupBuilder followed_by<Step>() where Step : IRunAStartupStep;
		void finish_by<Step>() where Step : IRunAStartupStep;
	}
}
