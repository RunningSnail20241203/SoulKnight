using Controller.MiddleRoom;
using Factory;
using Mediator;
using Panels.MiddleRoom.SelectPlayer;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using EventType = Utility.EventType;

namespace Panels.MiddleRoom
{
    public class PanelSelectPlayer : AbstractPanel
    {
        private PlayerType _curSelectPlayerType;
        private GameObject _divMain;
        private SelectPlayerInterface _divSkin;
        public PanelSelectPlayer(AbstractPanel parent) : base(parent)
        {
            Children.Add(new PanelBattle(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            var btnBack = UnityTool.Instance.FindComponentFromChildren<Button>(GameObject, "ButtonBack");
            var btnNext = UnityTool.Instance.FindComponentFromChildren<Button>(GameObject, "ButtonNext");
            btnBack.onClick.AddListener(OnButtonBackClick);
            btnNext.onClick.AddListener(OnButtonNextClick);

            _divMain = UnityTool.Instance.FindGameObjectFromChildren(GameObject, "DivMain");
          
        }

        protected override void OnResume()
        {
            base.OnResume();
            _curSelectPlayerType = GameMediator.Instance.GetController<PlayerController>().CurSelectPlayerType;
            var skinNode = UnityTool.Instance.FindGameObjectFromChildren(GameObject, "DivSkin");
            _divSkin = new SelectPlayerInterface(skinNode, _curSelectPlayerType);
            _divMain.SetActive(true);
            _divSkin.SetActive(false);
        }

        private void OnButtonBackClick()
        {
            if (_divSkin.IsActive)
            {
                _divMain.SetActive(true);
                _divSkin.SetActive(false);
                return;
            }
            EventCenter.Instance.NotifyObserver(EventType.SelectPlayerCancel);
            Exit();
        }

        private void OnButtonNextClick()
        {
            if (_divMain.activeSelf)
            {
                _divMain.SetActive(false);
                _divSkin.SetActive(true);
                return;
            }
            GameMediator.Instance.GetController<PlayerController>().SetMainPlayer(_curSelectPlayerType);
            EnterPanel<PanelBattle>();
            EventCenter.Instance.NotifyObserver(EventType.SelectPlayerFinish);
        }

        public override void Destroy()
        {
            base.Destroy();
            _divSkin = null;
        }
    }
}