using app.startup;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
	[Subject(typeof(StartTheApp))]
	public class StartTheAppSpecs
	{
		public abstract class concern : Observes
		{
		}

		public class when_calling_by : concern
		{
			private Because b = () =>
			{
				result = StartTheApp.by<TestStartupStep>();
			};

			private It should_return_a_startup_builder = () =>
			{
				result.ShouldNotBeNull();
			};

			private static IStartupBuilder result;
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