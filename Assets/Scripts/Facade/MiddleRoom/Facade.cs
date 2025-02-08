using Controller.MiddleRoom;
using GameLoop;

namespace Facade.MiddleRoom
{
    public class Facade : AbstractFacade
    {
        private PlayerController _playerController;
        private InputController _inputController;

        protected override void OnInit()
        {
            base.OnInit();
            
            _inputController = new InputController();
            _playerController = new PlayerController();
            
            GameMediator.Instance.RegisterController(_inputController);
            GameMediator.Instance.RegisterController(_playerController);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _inputController.GameUpdate();
            _playerController.GameUpdate();
        }
    }
}