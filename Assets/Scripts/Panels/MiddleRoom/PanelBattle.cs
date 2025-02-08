using System;
using Controller.MiddleRoom;
using GameLoop;
using Mediator;

namespace Panels.MiddleRoom
{
    public class PanelBattle : AbstractPanel
    {
        public PanelBattle(AbstractPanel parent) : base(parent)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            var cameraSystem = GameMediator.Instance.GetSystem<CameraSystem>();
            var playerController = GameMediator.Instance.GetController<PlayerController>();
            cameraSystem.SwitchCamera(CameraType.FollowCamera);
            cameraSystem.SetFollowTarget(playerController.MainPlayer.Transform);
        }
    }
}