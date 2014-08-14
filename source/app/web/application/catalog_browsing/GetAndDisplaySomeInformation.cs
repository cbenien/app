using app.web.core;

namespace app.web.application.catalog_browsing
{

	public interface IGetAndDisplaySomeInformation<InputModel> : ISupportAUserStory
	{
		void process(IProvideRequestDetails request);
	}

	public delegate ResultModel IGetTheModel<InputModel, ResultModel>(InputModel input_model);

	public class GetAndDisplaySomeInformation<InputModel, ResultModel> : IGetAndDisplaySomeInformation<InputModel>
	{
		private IDisplayInformation display_engine;
		private IGetTheModel<InputModel, ResultModel> get_the_model; 

		public GetAndDisplaySomeInformation(IDisplayInformation display_engine, 
			IGetTheModel<InputModel, ResultModel> get_the_model)
		{
			this.display_engine = display_engine;
			this.get_the_model = get_the_model;
		}

		public void process(IProvideRequestDetails request)
		{
			InputModel inputModel = request.map<InputModel>();
			ResultModel result = get_the_model(inputModel);
			display_engine.display(result);
		}
	}
}