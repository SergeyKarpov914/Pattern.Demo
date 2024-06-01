using Clio.Demo.VisitingProfessor.Entity;
using Clio.Demo.VisitingProfessor.Flex;
using Clio.Demo.VisitingProfessor.Util;

namespace Clio.Demo.VisitingProfessor.Processor
{
    internal sealed class BenzProcessor : FlexProcessor<Benz>
    {
        protected override void details()
        {
            Log.Info(this, $"+custom {Log.Caller}");
        }
        protected override void schedule(DateTime? start = null)
        {
            Log.Info(this, $"+custom {Log.Caller}");
        }
    }
}
