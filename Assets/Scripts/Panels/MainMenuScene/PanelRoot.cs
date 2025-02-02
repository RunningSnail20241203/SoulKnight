using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace Panels.MainMenuScene
{
    public class PanelRoot : IPanel
    {
        public PanelRoot() : base(null)
        {
        }

        protected override void OnInit()
        {
            base.OnInit();

            UnityTool.Instance.GetComponentFromChildren<Button>(GameObject, "ButtonStart").onClick.AddListener(
                () => { Debug.Log("开始游戏"); });
        }
    }
}