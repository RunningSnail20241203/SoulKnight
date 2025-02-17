using System;
using System.Collections.Generic;
using Controller;
using Controller.MiddleRoom;
using Factory;
using Mediator;
using Utility;

namespace Facade.MiddleRoom
{
    public class Facade : AbstractFacade
    {
        #region Private
        private PlayerController _playerController;
        private List<AbstractController> _controllers;
        private List<AbstractSystem> _systems;

        private void RegisterEvent()
        {
            EventCenter.Instance.RegisterObserver(EventType.SelectPlayerFinish, OnSelectPlayerFinish);
            EventCenter.Instance.RegisterObserver<PlayerType>(EventType.SelectPlayerBegin, OnSelectPlayerBegin);
            EventCenter.Instance.RegisterObserver(EventType.SelectPlayerCancel, OnSelectPlayerCancel);
        }

        private void UnRegisterEvent()
        {
            EventCenter.Instance.UnRegisterObserver(EventType.SelectPlayerFinish, OnSelectPlayerFinish);
            EventCenter.Instance.UnRegisterObserver<PlayerType>(EventType.SelectPlayerBegin, OnSelectPlayerBegin);
            EventCenter.Instance.UnRegisterObserver(EventType.SelectPlayerCancel, OnSelectPlayerCancel);
        }

        #region Event Handler

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

        #endregion

        #endregion

        #region Protected

        protected override void OnInit()
        {
            base.OnInit();

            _playerController = new PlayerController();
            _controllers = new List<AbstractController>
            {
                new InputController(),
                _playerController,
                new BulletController(),
                new UIController(),
                new EffectController(),
            };

            _systems = new List<AbstractSystem>
            {
                new CameraSystem(),
            };
            
            _controllers.ForEach(x=>GameMediator.Instance.RegisterController(x));
            _systems.ForEach(x=>GameMediator.Instance.RegisterSystem(x));

            RegisterEvent();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _controllers.ForEach(x => x.GameUpdate());
        }

        #endregion
       

        public override void Destroy()
        {
            base.Destroy();
            UnRegisterEvent();
            
            _controllers.ForEach(x=>GameMediator.Instance.RemoveController(x));
            _controllers.ForEach(x=>x.Destroy());
            _controllers.Clear();
            
            _systems.ForEach(x=>GameMediator.Instance.RemoveSystem(x));
            _systems.ForEach(x=>x.Destroy());
            _systems.Clear();
        }
    }
}