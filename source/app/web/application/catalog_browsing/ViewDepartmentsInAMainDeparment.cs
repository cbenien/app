using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.core;

namespace app.web.application.catalog_browsing
{
	public class ViewDepartmentsInAMainDeparment : ISupportAUserStory
	{
		IFindDepartmentsInAMainDepartment department_finder;
		IDisplayInformation display_engine;

		public ViewDepartmentsInAMainDeparment(IFindDepartmentsInAMainDepartment department_finder, IDisplayInformation display_engine)
		{
			this.department_finder = department_finder;
			this.display_engine = display_engine;
		}

		public void process(IProvideRequestDetails request)
		{
			throw new NotImplementedException();
		}
	}
}
