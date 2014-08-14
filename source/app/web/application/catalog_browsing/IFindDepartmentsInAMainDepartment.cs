using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.application.catalog_browsing
{
	public interface IFindDepartmentsInAMainDepartment
	{
		IEnumerable<DepartmentLineItem> get_the_departments_in(string mainDepartmentName);
	}
}
