using System;
using System.Collections.Generic;

namespace app.startup
{
	public class StartTheApp
	{
		public static IStartupBuilder by<StartupStep>() where StartupStep : IRunAStartupStep
		{
			var list = new List<IRunAStartupStep>();
			IConstructAStartupStep constructor = (Type type) => Activator.CreateInstance(type);
			var builder = new StartupBuilder(list, constructor);
			builder.followed_by<StartupStep>();
			return builder;
		}
	}
}