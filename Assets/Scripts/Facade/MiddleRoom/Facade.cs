using System;
using Controller;
using Controller.MiddleRoom;
using Factory;
using GameLoop;
using Mediator;
using Utility;

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
            
            EventCenter.Instance.RegisterObserver(EventType.SelectPlayerFinish, OnSelectPlayerFinish);
            EventCenter.Instance.RegisterObserver<PlayerType>(EventType.SelectPlayerBegin, OnSelectPlayerBegin);
            EventCenter.Instance.RegisterObserver(EventType.SelectPlayerCancel, OnSelectPlayerCancel);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _inputController.GameUpdate();
            _playerController.GameUpdate();
            _uiController?.GameUpdate();
        }

        public override void Destroy()
        {
            base.Destroy();
            EventCenter.Instance.RemoveObserver(EventType.SelectPlayerFinish, OnSelectPlayerFinish);
            EventCenter.Instance.RemoveObserver<PlayerType>(EventType.SelectPlayerBegin, OnSelectPlayerBegin);
            EventCenter.Instance.RemoveObserver(EventType.SelectPlayerCancel, OnSelectPlayerCancel);
            
            GameMediator.Instance.RemoveController(_inputController);
            GameMediator.Instance.RemoveController(_inputController);
            GameMediator.Instance.RemoveController(_inputController);
            GameMediator.Instance.RemoveSystem(_cameraSystem);
            
            _inputController?.Destroy();
            _playerController?.Destroy();
            _uiController?.Destroy();
            _cameraSystem?.Destroy();
            
            _inputController = null;
            _playerController = null;
            _uiController = null;
            _cameraSystem = null;
        }

        private void OnSelectPlayerFinish()
        {
            _playerController.TurnOnController();
        }

        private void OnSelectPlayerBegin(PlayerType playerType)
        {
            _playerController.SetSelectPlayer(playerType);
        }
        
        private void OnSelectPlayerCancel()
        {
            _playerController.ClearSelectPlayer();
        }
    }
}