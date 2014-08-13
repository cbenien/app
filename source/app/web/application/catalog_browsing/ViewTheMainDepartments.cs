using app.web.core;

namespace app.web.application.catalog_browsing
{
	public class ViewTheMainDepartments : ISupportAUserStory
	{
		private IFindDepartments department_finder;

		public ViewTheMainDepartments(IFindDepartments departmentFinder)
		{
			department_finder = departmentFinder;
		}

		public void process(IProvideRequestDetails request)
		{
			department_finder.get_the_main_departments();
		}
	}
}