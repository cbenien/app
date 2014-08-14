using System.Collections;
using System.Collections.Generic;
using app.web.application.catalog_browsing.stubs;
using app.web.aspnet;
using app.web.core;

namespace app.web.application.catalog_browsing
{
	public class ViewTheProductsInADepartment : ISupportAUserStory
	{
		IFindProducts product_finder;
		IDisplayInformation display;

		public ViewTheProductsInADepartment(IFindProducts product_finder, IDisplayInformation display)
		{
			this.product_finder = product_finder;
			this.display = display;
		}

		public void process(IProvideRequestDetails request)
		{
			var input = request.map<ProductsInDepartmentInput>();
			var results = product_finder.get_products_using(input);

			display.display(results);
		}
	}

	public class ProductsInDepartmentInput
	{
	}

	public interface IFindProducts
	{
		IEnumerable<ProductLineItem> get_products_using(ProductsInDepartmentInput input);
	}

	public class ProductLineItem
	{
		
	}

}