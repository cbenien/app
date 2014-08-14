using System;
using System.Collections.Generic;

namespace app.startup
{
	public class StartupBuilder : IStartupBuilder
	{
		private ICollection<IRunAStartupStep> startup_steps;
		private IConstructAStartupStep constructor;
		private IProvideStartupServices startup_services;

		public StartupBuilder(ICollection<IRunAStartupStep> startup_steps, IConstructAStartupStep constructor, IProvideStartupServices startup_services)
		{
			this.startup_steps = startup_steps;
			this.constructor = constructor;
			this.startup_services = startup_services;
		}

		public IStartupBuilder followed_by<Step>() where Step : IRunAStartupStep
		{
			var step = (IRunAStartupStep) constructor(typeof(Step), startup_services);
			startup_steps.Add(step);
			return this;
		}

		public void finish_by<Step>() where Step : IRunAStartupStep
		{
			throw new NotImplementedException();
		}
	}
}