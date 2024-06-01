namespace Clio.Demo.VisitingProfessor.Interface
{
    internal interface IProcessor<T> where T : class, IEntity, new()
    {
        void GenerateDetails();
        void GenerateSchedule(DateTime? start = null);
        void Notify();
    }
}
