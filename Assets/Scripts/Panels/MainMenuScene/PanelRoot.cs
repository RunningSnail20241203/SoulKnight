using UnityEngine;
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

            UnityTool.Instance.FindComponentFromChildren<Button>(GameObject, "ButtonStart", true).onClick.AddListener(
                () => { Debug.Log("开始游戏"); });
        }
    }
}