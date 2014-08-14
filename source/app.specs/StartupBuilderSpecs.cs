using System.Collections;
using System.Collections.Generic;
using app.startup;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
	[Subject(typeof(StartupBuilder))]
	public class StartupBuilderSpecs
	{
		public abstract class concern : Observes<IStartupBuilder, StartupBuilder>
		{
		}

		public class when_calling_followed_by : concern
		{
			private Establish e = () =>
			{
				the_step = new TestStartupStep();
				startup_step_storage = depends.@on<ICollection<IRunAStartupStep>>();

				startup_step_constructor = depends.on<IConstructAStartupStep>(type => the_step);
			};

			private Because b = () =>
			{
				sut.followed_by<TestStartupStep>();
			};

			private It add_the_step_to_the_storage = () =>
			{
				startup_step_storage.received(x => x.Add(the_step));
			};

			private static IStartupBuilder result;
			private static IConstructAStartupStep startup_step_constructor;
			private static IRunAStartupStep the_step;
			private static ICollection<IRunAStartupStep> startup_step_storage;
		}

		class TestStartupStep : IRunAStartupStep
		{
			public void run()
			{
				throw new System.NotImplementedException();
			}
		}
	}
}