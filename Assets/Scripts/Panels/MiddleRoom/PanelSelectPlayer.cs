﻿

using Controller.MiddleRoom;
using Factory;
using GameLoop;
using Mediator;
using UnityEngine.UI;
using Utility;

namespace Panels.MiddleRoom
{
    public class PanelSelectPlayer : AbstractPanel
    {
        private PlayerType _curSelectPlayerType;
        public PanelSelectPlayer(AbstractPanel parent) : base(parent)
        {
            Children.Add(new PanelBattle(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            UnityTool.Instance.FindComponentFromChildren<Button>(GameObject ,"ButtonBack").onClick.AddListener(OnButtonBackClick);
            UnityTool.Instance.FindComponentFromChildren<Button>(GameObject ,"ButtonNext").onClick.AddListener(OnButtonNextClick);
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            _curSelectPlayerType = PlayerType.Knight;
        }

        private void OnButtonBackClick()
        {
            Exit();
        }

        private void OnButtonNextClick()
        {
            GameMediator.Instance.GetController<PlayerController>().SetMainPlayer(_curSelectPlayerType);
            EnterPanel<PanelBattle>();
            EventCenter.Instance.NotifyObserver(EventType.SelectPlayerFinish);
        }
    }
}