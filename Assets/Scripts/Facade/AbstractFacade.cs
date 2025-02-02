namespace Facade
{
    public abstract class AbstractFacade
    {
        private bool _isInit;
        public void GameUpdate()
        {
            OnUpdate();
        }

        protected virtual void OnInit()
        {
            
        }

        protected virtual void OnUpdate()
        {
            if (_isInit) return;
            _isInit = true;
            OnInit();
        }
    }
}