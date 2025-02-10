using System;
using Factory;
using GameLoop;
using Mediator;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Utility;
using CameraType = System.CameraType;
using EventType = Utility.EventType;

namespace Panels.MiddleRoom
{
    public class PanelRoom : AbstractPanel
    {
        private CameraSystem _cameraSystem;
        private Collider2D _collider2D;
        private const string PlayerLayer = "Player";

        public PanelRoom(AbstractPanel parent) : base(parent)
        {
            Children.Add(new PanelSelectPlayer(this));
        }

        protected override void OnInit()
        {
            base.OnInit();
            _cameraSystem = GameMediator.Instance.GetSystem<CameraSystem>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            if (Input.GetMouseButtonDown(0))
            {
                if (_cameraSystem.MainCamera != null)
                {
                    var point = Input.mousePosition;
                    point.z = -_cameraSystem.MainCamera.transform.position.z;
                    point = _cameraSystem.MainCamera.ScreenToWorldPoint(point);
                    var layer = 1 << LayerMask.NameToLayer(PlayerLayer);
                    _collider2D = Physics2D.OverlapCircle(point, 0.1f, layer);
                    if (_collider2D)
                    {
                        _cameraSystem.SwitchCamera(CameraType.SelectCamera);
                        _cameraSystem.SetSelectTarget(_collider2D.transform.parent);
                        if (Enum.TryParse(_collider2D.transform.parent.name, out PlayerType playerType))
                        {
                            EventCenter.Instance.NotifyObserver(EventType.SelectPlayerBegin, playerType);
                        }
                        EnterPanel<PanelSelectPlayer>();
                    }
                }
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
            _cameraSystem.SwitchCamera(CameraType.StaticCamera);
        }
    }
}