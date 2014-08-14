using app.web.application.catalog_browsing.stubs;
using app.web.aspnet;
using app.web.core;

namespace app.web.application.catalog_browsing
{
  public class ViewTheProductsInADepartment : ISupportAUserStory
  {
    IFindProductsInADepartment product_finder;
    IDisplayInformation display_engine;

    public ViewTheProductsInADepartment()
      : this(new StubProductFinder(),
        new WebFormDisplayEngine())
    {
    }

    public ViewTheProductsInADepartment(IFindProductsInADepartment product_finder, IDisplayInformation display_engine)
    {
      this.product_finder = product_finder;
      this.display_engine = display_engine;
    }

    public void process(IProvideRequestDetails request)
    {
      display_engine.display(product_finder.get_products_of_department(request.map<ProductsInDepartmentInput>()));
    }
  }




}