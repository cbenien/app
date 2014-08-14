using System;
using System.Linq;
using System.Text;

namespace app.startup
{
	public delegate IRunAStartupStep IConstructAStartupStep(Type type, IProvideStartupServices startup_servioes);
}
