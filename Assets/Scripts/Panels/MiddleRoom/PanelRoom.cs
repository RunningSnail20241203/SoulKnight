using System;
using GameLoop;
using Mediator;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using CameraType = System.CameraType;

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
            Resume();
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
                        EnterPanel<PanelSelectPlayer>();
                    }
                }
            }
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            _cameraSystem.SwitchCamera(CameraType.StaticCamera);
        }
    }
}