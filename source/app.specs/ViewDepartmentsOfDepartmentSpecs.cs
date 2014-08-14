using System.Collections.Generic;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
	[Subject(typeof(GetAndDisplaySomeInformation<DeparmentsInDepartmentInput, IEnumerable<MainDepartmentLineItem>>))]
	public class ViewDepartmentsOfDepartmentSpecs
	{
		public abstract class concern : Observes<ISupportAUserStory,
		  GetAndDisplaySomeInformation<DeparmentsInDepartmentInput, IEnumerable<MainDepartmentLineItem>>>
		{
		}

		public class when_run : concern
		{
			Establish c = () =>
			{
				i_get_the_model = depends.@on<IGetTheModel<DeparmentsInDepartmentInput, IEnumerable<MainDepartmentLineItem>>>(
					inputModel => departments);
				display_engine = depends.on<IDisplayInformation>();

				request = fake.an<IProvideRequestDetails>();
				request.setup(x => x.map<DeparmentsInDepartmentInput>()).Return(input);
			};

			Because b = () =>
			  sut.process(request);

			It displays_the_departments_of_the_chosen_department = () =>
			  display_engine.received(x => x.display(departments));

			private static IGetTheModel<DeparmentsInDepartmentInput, IEnumerable<MainDepartmentLineItem>> i_get_the_model; 
			static IProvideRequestDetails request;
			static IDisplayInformation display_engine;
			static IEnumerable<MainDepartmentLineItem> departments;
			static DeparmentsInDepartmentInput input;
		}
	}
}