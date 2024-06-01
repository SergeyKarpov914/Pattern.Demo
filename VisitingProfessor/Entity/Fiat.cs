using Clio.Demo.VisitingProfessor.Flex;
using Clio.Demo.VisitingProfessor.Util;

namespace Clio.Demo.VisitingProfessor.Entity
{
    internal class Fiat : FlexEntity
    {
        public override void ActionAfter()
        {
            Log.Info(this, $"+       {Log.Caller}");
        }
    }

    internal sealed class Alfa : Fiat
    {
        public override void ActionBefore()
        {
            Log.Info(this, $"+       {Log.Caller}");
        }

        public override void ActionAfter()
        {
            Log.Info(this, $"+       {Log.Caller}");
        }
    }
}
