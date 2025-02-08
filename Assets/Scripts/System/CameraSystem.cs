using Cinemachine;
using UnityEngine;

namespace System
{
    public class CameraSystem : AbstractSystem
    {
        public Camera MainCamera { get; private set; }

        private CinemachineVirtualCamera _staticCamera;
        private CinemachineVirtualCamera _selectCamera;
        private CinemachineVirtualCamera _followCamera;
        private const string CameraRoot = "Cameras";


        public void SetSelectTarget(Transform t)
        {
            _selectCamera.Follow = t;
        }

        public void SetFollowTarget(Transform t)
        {
            _followCamera.Follow = t;
        }

        public void SwitchCamera(CameraType cameraType)
        {
            switch (cameraType)
            {
                case CameraType.StaticCamera:
                    _staticCamera.Priority = 10;
                    _selectCamera.Priority = 0;
                    _followCamera.Priority = 0;
                    break;
                case CameraType.SelectCamera:
                    _staticCamera.Priority = 0;
                    _selectCamera.Priority = 10;
                    _followCamera.Priority = 0;
                    break;
                case CameraType.FollowCamera:
                    _staticCamera.Priority = 0;
                    _selectCamera.Priority = 0;
                    _followCamera.Priority = 10;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cameraType), cameraType, null);
            }
        }

        protected override void OnInit()
        {
            base.OnInit();
            MainCamera = Camera.main;
            var cameraRoot = UnityTool.Instance.FindGameObjectInScene(CameraRoot);
            _staticCamera =
                UnityTool.Instance.FindComponentFromChildren<CinemachineVirtualCamera>(cameraRoot,
                    CameraType.StaticCamera.ToString(), true);
            _selectCamera =
                UnityTool.Instance.FindComponentFromChildren<CinemachineVirtualCamera>(cameraRoot,
                    CameraType.SelectCamera.ToString(), true);
            _followCamera =
                UnityTool.Instance.FindComponentFromChildren<CinemachineVirtualCamera>(cameraRoot,
                    CameraType.FollowCamera.ToString(), true);
        }
    }

    public enum CameraType
    {
        StaticCamera,
        SelectCamera,
        FollowCamera,
    }
}