using System.Collections.Generic;
using System.Linq;
using app.web.application.catalog_browsing;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using Rhino.Mocks.Constraints;

namespace app.specs
{
	[Subject(typeof(ViewTheProductsInADepartment))]
	public class ViewTheProductsInADepartmentSpecs
	{
		public abstract class concern : Observes<ISupportAUserStory,
		  ViewTheProductsInADepartment>
		{
		}

		public class when_run : concern
		{
			Establish c = () =>
			{
				display_engine = depends.on<IDisplayInformation>();
				product_finder = depends.on<IFindProducts>();
				request = fake.an<IProvideRequestDetails>();
				input = new ProductsInDepartmentInput();
				request.setup(x => x.map<ProductsInDepartmentInput>()).Return(input);

				products = Enumerable.Range(1, 100).Select(x => new ProductLineItem());
				product_finder.setup(x => x.get_products_using(input)).Return(products);
			};

			Because b = () =>
			  sut.process(request);

			It displays_the_departments = () =>
			  display_engine.received(x => x.display(products));

			private static ProductsInDepartmentInput input;
			static IFindProducts product_finder;
			static IProvideRequestDetails request;
			static IDisplayInformation display_engine;
			private static IEnumerable<ProductLineItem> products;
		}
	}
}