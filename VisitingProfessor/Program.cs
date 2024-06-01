using Clio.Demo.VisitingProfessor.Entity;
using Clio.Demo.VisitingProfessor.Flex;
using Clio.Demo.VisitingProfessor.Interface;
using Clio.Demo.VisitingProfessor.Processor;
using Clio.Demo.VisitingProfessor.Util;

namespace Clio.Demo.VisitingProfessor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Log.Info("Main", "Derived processor class invocation");
            Log.Line();

            BenzProcessor benz = new BenzProcessor();
            FiatProcessor fiat = new FiatProcessor();
            AlfaProcessor alfa = new AlfaProcessor();

            benz.GenerateDetails();
            fiat.GenerateSchedule();
            fiat.Notify();

            alfa.Notify();
            alfa.GenerateSchedule(DateTime.Now);

            Log.Info("Main", "Interface processor invocation");
            Log.Line();

            IMiniProcessor mini = new MiniProcessor();       // non-generic interface (for dependency injection) 
            IProcessor<Mini> miniG = new FlexProcessor<Mini>(); // generic interface

            mini.GenerateDetails();
            mini.GenerateSchedule();

            Log.Info("Main", "Generic processor invocation");
            Log.Line();

            miniG.GenerateDetails();
            miniG.GenerateSchedule();

            Console.Read();
        }
    }
}
