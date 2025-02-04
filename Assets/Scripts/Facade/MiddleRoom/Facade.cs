using Controller.MiddleRoom;
using GameLoop;

namespace Facade.MiddleRoom
{
    public class Facade : AbstractFacade
    {
        private PlayerController _playerController;

        protected override void OnInit()
        {
            base.OnInit();
            
            _playerController = new PlayerController();
            GameMediator.Instance.RegisterController(_playerController);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _playerController.GameUpdate();
        }
    }
}