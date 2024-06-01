using Clio.Demo.VisitingProfessor.Entity;
using Clio.Demo.VisitingProfessor.Flex;
using Clio.Demo.VisitingProfessor.Interface;
using Clio.Demo.VisitingProfessor.Util;

namespace Clio.Demo.VisitingProfessor.Processor
{
    internal interface IMiniProcessor : IProcessor<Mini>  // non-generic intercface to be used by dependency injection 
    { 
    }

    internal sealed class MiniProcessor : FlexProcessor<Mini>, IMiniProcessor
    {
        protected override void schedule(DateTime? start = null)
        {
            Log.Info(this, $"+custom {Log.Caller}");
        }

        protected override void details()
        {
            base.details();

            Log.Info(this, $"+custom {Log.Caller}");
        }
    }
}
