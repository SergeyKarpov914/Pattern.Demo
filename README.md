# Pattern.Demo
Demo solutions illustrating pattern implementation

## Solution building and running

The demo solution is a console application built for .NET 7.0 target framework. Visual Studio 2022 was used to create.
The solution should build without warnings. It runs with no command line arguments.

The log is written into Console and log file, which can be found in:

\PatternDemo\VisitingProfessor\bin\Debug\net7.0\Logs


# Visiting Professor pattern

This implementation pattern was developed for C++ and C# and used for some time. 
The pattern can be seen as an incarnation of well known Template Method pattern, with the main difference being the use of protected virtuals in place of abstract methods.

## Flex class hierarhy

This particular demo was designed to illustrate basic implementation of the pattern and to make emphasis on the flexibility of code usage, which is one of the main aspect here.
Project structure consists of following group of modules:

- [ ] Interfaces
- [ ] Flex base classes for Entities and Processors
- [ ] Implementation classes for Entities and Processors
- [ ] Logging utilities

In the middle of the pattern there is a FlexProcessor generic type and FlexEntity type (with correspondent interfaces). 

The FlexProcessor is at the top of a Processor conceptual hierarchy and provides default implementation of a Processor. An Entity is used as a parameter for the FlexProcessor generic class and is used to customize behavior of a Processor. 
An Entity itself is implemented as a class hierarchy, with FlexEntity base class providing default implementation of IEntity interface, with an ability to by customized by way creating derived classes.

Here is an abbreviated view of the FlexProcessor code, presented to help understanding of Visinting Processor pattern and flexibility it provides:

```cs
    internal class FlexProcessor<T> : IProcessor<T> where T : class, IEntity, new()
    {
        private readonly T _entity = null;
    
        public FlexProcessor()
        {
            _entity = new T();
        }
    
        public void GenerateDetails()     // entry point
        {
            try
            {
                _entity.ActionBefore();   // implementation conrtibution by an entity
    
                details();                // implementaion by processor
            }
            catch (Exception ex)
            {
            }
        }
    
        protected virtual void details()  // default implementation, or conrtibuted by a derived processor
        {
        }
    }
```

## Two sources of flexibility

The protected virtuals of the FlexProcessor generic base class and IEntity interface generic constraint present two sources of implementation flexibility.

The FlexProcessor class implements a public entry point and a protected virtual implementation method. 
An implementation method may or may not be overridden by a derived class, providing a way of: 

- [ ] engaging **default** entry point implementation
- [ ] providing **custom** entry point implementation
- [ ] **suppressing** entire or partial entry point implementation

A derived Processor class, created for a specific Entity type, adds the first level of flexibility by way of selectively overriding protected virtuals of the FlexProcessor generic base class.

In addition to that, IEntity interface members can be accessed by the FlexProcessor generic base class due to interface generic constraint. The FlexProcessor base class can put calls to IEntity members into the entry point member execution path, allowing an entity itself to contribute implementation flexibility.

## Code reuse and avoiding code repetittion

A derived Processor class code comes much smaller compared to the code of the FlexProcessor generic base class.
All the code flow logic, the data members, helper methods, and common implementation logic are implemented at the base class level.
All exception handling, instrumentation and possibly multiple other useful functionality is implemented at the base class level as wel.

Visiting Professor pattern typically yields very minimalistic implementation classes. 

```cs
    internal sealed class BenzProcessor : FlexProcessor<Benz>
    {
        protected override void details()                          // implementation by a derived processor
        {
            base.details();                                        // optional default implementation can be used as a part of custom implementation
        }
        protected override void schedule(DateTime? start = null)   // implementation by a derived processor
        {
        }
    }
```
A designer of a derived class has wide range of decision making possibilities.
Not only the selected protected virtuals can be overridden, but default implementation by base class can be mixed in with the derived implementation as well.

A library based on Visiting Professor pattern can live for a substantial time with base classes remaining intact and only small derived classes being added and/or maintained by developers.


## Flexibility by the way of cyclomatic complexity

One other level of flexibility could be achieved by delegating control flow decision making to implementation, and even entity code.
This approach is not without drawbacks, though. It increases the cyclomatic complexity of a solution and reduces it's testability.

```cs
        public void GenerateDetails()                // entry point
        {
            try
            {
                if(CanComplete(Log.Caller))          // a processor makes decision if entry point can be completed
                {
                    details();                       // implementaion by processor
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void GenerateDetails()                // entry point
        {
            try
            {
                if(_entity.CanComplete(Log.Caller))  // an entity makes decision if entry point can be completed
                {
                    details();                       // implementaion by processor
                }
            }
            catch (Exception ex)
            {
            }
        }
```

If additional flexibility is deemed necessary, this technique can be implemented.

## Exception handling

A class which implements interface must handle exceptions at every public entry point level. My take on it is simple:

**Private (protected) throw, public catch**

This means that no matter what is happening within public entry point, an effort needs to be made to handle exceptions at the exit of that public entry point. I don’t agree with the maxim that exceptions should be let bubble up the stack to a process entry point and let that process die.

Having said that, a class designer may choose to re-throw an exception at the exit of a public entry point, after it is handled. There can be valid design considerations for letting a caller class handle exceptions produced by certain interface implementations.
