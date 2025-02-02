namespace Controller
{
    public abstract class AbstractController
    {
        private bool _isRun;
        private bool _isInit;
        private bool _isBeforeRunStart;
        private bool _isAfterRunStart;

        public void GameUpdate()
        {
            if (!_isInit)
            {
                _isInit = true;
                OnInit();
            }

            if (_isRun)
            {
                OnAfterRunUpdate();
            }
            else
            {
                OnBeforeRunUpdate();
            }
            AlwaysUpdate();
        }
        
        protected virtual void OnInit(){}

        protected virtual void OnBeforeRunStart()
        {
           
        }

        protected virtual void OnBeforeRunUpdate()
        {
            if (!_isBeforeRunStart)
            {
                _isBeforeRunStart = true;
                OnBeforeRunStart();
            }
        }
        protected virtual void OnAfterRunStart(){}

        protected virtual void OnAfterRunUpdate()
        {
            
        }
        protected virtual void AlwaysUpdate(){}

        public void TurnOnController()
        {
            _isRun = true;
        }

        public void TurnOffController()
        {
            _isRun = false;
        }
    }
}