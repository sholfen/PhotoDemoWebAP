using AwesomeProxy;
using AwesomeProxy.FilterAttribute;
using NLog;

namespace PhotoDemoWebAP.Utilities.AOP
{
    public class ExceptionLoggingAttribute : AopBaseAttribute
    {
        public ExceptionLoggingAttribute() 
        {
        }

        public override void OnException(ExceptionContext exceptionContext)
        {
            var logger = LogManager.Setup().GetLogger("GroupBuyDemo");
            logger.Error(exceptionContext.Exception);
            base.OnException(exceptionContext);
        }
    }
}
