using Panels.MainMenuScene;

namespace Controller.MainMenuScene
{
    public class UIController : AbstractController
    {
        private PanelRoot _panelRoot;


        protected override void OnInit()
        {
            base.OnInit();
            _panelRoot = new PanelRoot();
        }

        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            _panelRoot.GameUpdate();
        }
    }
}