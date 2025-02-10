using System;
using System.Collections.Generic;
using Command;
using Factory;
using UnityEngine;
using UnityEngine.UI;
using Utility;

namespace Panels.MiddleRoom.SelectPlayer
{
    public class SelectPlayerInterface
    {
        private GameObject GameObject { get; set; }

        private int _curSelectSkinIndex;
        private List<PlayerSkinType> _playerSkinTypes;
        private Animator _playerAnimator;
        private readonly PlayerType _playerType;

        public bool IsActive => GameObject.activeSelf;

        public SelectPlayerInterface(GameObject obj, PlayerType playerType)
        {
            GameObject = obj;
            _playerType = playerType;

            UnityTool.Instance.FindComponentFromChildren<Button>(obj, "ButtonLeft").onClick.AddListener(OnButtonLeftClick);
            UnityTool.Instance.FindComponentFromChildren<Button>(obj, "ButtonRight").onClick.AddListener(OnButtonRightClick);
            Enter();
        }

        public void SetActive(bool active)
        {
            GameObject.SetActive(active);
        }

        private void Enter()
        {
            _playerSkinTypes = PlayerCommand.Instance.GetSkinTypes(_playerType);
            var playerObj = UnityTool.Instance.FindGameObjectInScene(_playerType.ToString());
            _playerAnimator = UnityTool.Instance.FindComponentFromChildren<Animator>(playerObj, "Sprite");
            if (Enum.TryParse<PlayerSkinType>(_playerAnimator.runtimeAnimatorController.name, out var skinType))
            {
                _curSelectSkinIndex = _playerSkinTypes.IndexOf(skinType);
            }
        }

        private void OnButtonLeftClick()
        {
            _curSelectSkinIndex = (int)Mathf.Repeat(_curSelectSkinIndex - 1, _playerSkinTypes.Count);
            ChangeSkin(_curSelectSkinIndex);
        }

        private void OnButtonRightClick()
        {
            _curSelectSkinIndex = (int)Mathf.Repeat(_curSelectSkinIndex + 1, _playerSkinTypes.Count);
            ChangeSkin(_curSelectSkinIndex);
        }

        private async void ChangeSkin(int index)
        {
            if (index < 0 || index >= _playerSkinTypes.Count) return;
            var playerSkinType = _playerSkinTypes[index];
            var skin = await ResourceFactory.Instance.GetAnimatorController(_playerType.ToString(), playerSkinType.ToString());
            _playerAnimator.runtimeAnimatorController = skin;
        }
    }
}