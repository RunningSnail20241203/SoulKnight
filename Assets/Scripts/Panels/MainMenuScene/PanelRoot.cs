using Command;
using Model;
using UnityEngine;
using Utility;
using Button = UnityEngine.UI.Button;

namespace Panels.MainMenuScene
{
    public class PanelRoot : AbstractPanel
    {
        public PanelRoot() : base(null)
        {
        }

        protected override void OnInit()
        {
            base.OnInit();

            UnityTool.Instance.FindComponentFromChildren<Button>(GameObject, "ButtonStart").onClick.AddListener(
                () => { SceneCommand.Instance.LoadScene(SceneName.MiddleRoomScene); });
        }
    }
}