using Command;
using Model;
using Panels;

namespace Controller
{
    public class UIController : AbstractController
    {
        private AbstractPanel _panelRoot;


        protected override void OnInit()
        {
            base.OnInit();
            _panelRoot = SceneCommand.Instance.GetActiveSceneName() switch
            {
                SceneName.MainMenuScene => new Panels.MainMenuScene.PanelRoot(),
                SceneName.MiddleRoomScene => new Panels.MiddleRoom.PanelRoot(),
                _ => _panelRoot
            };
            
        }

        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            _panelRoot.GameUpdate();
        }

        public override void Destroy()
        {
            base.Destroy();
            _panelRoot?.Destroy();
            _panelRoot = null;
        }
    }
}