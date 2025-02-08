using Character;

namespace Facade
{
    public abstract class AbstractFacade : IDestroy
    {
        private bool _isInit;

        public void GameUpdate()
        {
            OnUpdate();
        }

        public virtual void Destroy()
        {
        }

        protected virtual void OnInit()
        {
        }

        protected virtual void OnUpdate()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }
        }
    }
}