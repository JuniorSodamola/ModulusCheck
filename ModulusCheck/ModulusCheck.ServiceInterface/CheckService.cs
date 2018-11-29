using ServiceStack;
using ModulusCheck.ServiceModel;
using ModulusCheck.ServiceModel.Request;
using ModulusCheck.ServiceModel.Response;
using ModulusCheck.ServiceInterface.CheckLogic;
using ModulusCheck.ServiceInterface.Interface;
using Ninject;
namespace ModulusCheck.ServiceInterface
{
    public class CheckService : Service
    {
        private readonly IKernel kernel;
        private readonly IModulusCheckLogic modulusCheckLogic;
        private string InValidRequestMsg = "Invalid request.";

        public CheckService()
        {
            this.kernel = new StandardKernel();
            this.kernel.Bind<IModulusCheckLogic>().To<ModulusCheckLogic>();
            this.modulusCheckLogic = this.kernel.Get<ModulusCheckLogic>();
        }

        public object Any(CheckRequest request)
        {
            if (!string.IsNullOrEmpty(request?.AccountNumber) && !string.IsNullOrEmpty(request.SortCode))
            {
                return new CheckResponse();
            }
            return new CheckResponse
            {
                IsValid = false, 
                Message = this.InValidRequestMsg
            };
        }
    }
}