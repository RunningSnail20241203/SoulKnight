using Controller;
using GameLoop;
using Mediator;

namespace Facade.MainMenuScene
{
    public class Facade : AbstractFacade
    {
        private UIController _uiController;

        protected override void OnInit()
        {
            base.OnInit();
            _uiController = new UIController();
            GameMediator.Instance.RegisterController(_uiController);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            _uiController.GameUpdate();
        }

        public override void Destroy()
        {
            base.Destroy();
            GameMediator.Instance.RemoveController(_uiController);
            _uiController?.Destroy();
            _uiController = null;
        }
    }
}