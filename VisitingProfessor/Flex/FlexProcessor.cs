using Clio.Demo.VisitingProfessor.Interface;
using Clio.Demo.VisitingProfessor.Util;

namespace Clio.Demo.VisitingProfessor.Flex
{
    internal class FlexProcessor<T> : IProcessor<T> where T : class, IEntity, new()
    {
        private readonly T _entity = null;

        #region c-tor

        public FlexProcessor()
        {
            _entity = new T();
        }
        public FlexProcessor(T entity)
        {
            _entity = entity ?? throw new Exception("Injected entity cannot be empty");
        }

        #endregion c-tor

        #region IProcessor

        public void GenerateDetails()
        {
            Log.Info(this, $"-> Entty point {Log.Caller}");
            try
            {
                preProc();
                
                _entity.ActionBefore();

                details();

                _entity.ActionAfter();

                postProc();
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
            }
            finally { Log.Line(); }
        }

        public void GenerateSchedule(DateTime? start = null)
        {
            Log.Info(this, $"-> Entty point {Log.Caller}");
            try
            {
                _entity.ActionBefore();

                schedule(start);

                _entity.ActionAfter();
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
            }
            finally { Log.Line(); }
        }

        public void Notify()
        {
            Log.Info(this, $"-> Entty point {Log.Caller}");
            try
            {
                preProc();

                _entity.ActionBefore();

                notify();

                _entity.ActionAfter();
            }
            catch (Exception ex)
            {
                Log.Error(this, ex);
            }
            finally { Log.Line(); }
        }

        #endregion IProcessor

        #region implementation

        private void preProc()
        {
            Log.Info(this, $"{Log.Caller}");
        }
        private void postProc()
        {
            Log.Info(this, $"{Log.Caller}");
        }

        #endregion implementation

        #region Visiting Professor

        protected virtual void details()
        {
            Log.Info(this, $"Default {Log.Caller}");
        }
        protected virtual void schedule(DateTime? start = null)
        {
            Log.Info(this, $"Default {Log.Caller}");
        }
        protected virtual void notify()
        {
            Log.Info(this, $"Default {Log.Caller}");
        }

        #endregion Visiting Professor
    }
}
