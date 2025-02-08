using System;
using Controller;
using Controller.MiddleRoom;
using GameLoop;

namespace Facade.MiddleRoom
{
    public class Facade : AbstractFacade
    {
        private PlayerController _playerController;
        private InputController _inputController;
        private UIController _uiController;
        private CameraSystem _cameraSystem;

        protected override void OnInit()
        {
            base.OnInit();
            
            _inputController = new InputController();
            _playerController = new PlayerController();
            _uiController = new UIController();
            _cameraSystem = new CameraSystem();
            
            GameMediator.Instance.RegisterController(_inputController);
            GameMediator.Instance.RegisterController(_playerController);
            GameMediator.Instance.RegisterController(_uiController);
            GameMediator.Instance.RegisterSystem(_cameraSystem);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _inputController.GameUpdate();
            _playerController.GameUpdate();
            _uiController.GameUpdate();
        }
    }
}