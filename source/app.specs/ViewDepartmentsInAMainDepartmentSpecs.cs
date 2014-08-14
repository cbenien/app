using System.Collections.Generic;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;

namespace app.specs
{
  [Subject(typeof(ViewTheMainDepartments))]
  public class ViewDepartmentsInAMainDeparmentSpec
  {
    public abstract class concern : Observes<ISupportAUserStory,
	  ViewDepartmentsInAMainDeparment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        display_engine = depends.on<IDisplayInformation>();
        department_finder = depends.on<IFindDepartmentsInAMainDepartment>();
        request = fake.an<IProvideRequestDetails>();
        sub_departments = new List<DepartmentLineItem>();
	      main_department_name = "main department 123";

        department_finder.setup(x => x.get_the_departments_in(main_department_name)).Return(sub_departments);
      };

      Because b = () =>
        sut.process(request);

      It displays_the_sub_departments = () =>
        display_engine.received(x => x.display(sub_departments));

	  static string main_department_name;
      static IFindDepartmentsInAMainDepartment department_finder;
      static IProvideRequestDetails request;
      static IDisplayInformation display_engine;
      static IEnumerable<DepartmentLineItem> sub_departments;
    }
  }
}