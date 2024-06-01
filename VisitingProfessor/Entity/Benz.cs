using Clio.Demo.VisitingProfessor.Flex;
using Clio.Demo.VisitingProfessor.Util;

namespace Clio.Demo.VisitingProfessor.Entity
{
    internal sealed class Benz : FlexEntity
    {
        public override void ActionAfter()
        {
            throw new Exception($"{this.Stamp()} throws in ActionAfter()");
        }

        public override void ActionBefore()
        {
            Log.Info(this, $"+       {Log.Caller}");
        }
    }
}
