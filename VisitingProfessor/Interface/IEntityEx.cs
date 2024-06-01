namespace Clio.Demo.VisitingProfessor.Interface
{
    internal interface IEntityEx : IEntity
    {
        void ExtendedBefore();
        void ExtendedAfter();
    }
}
