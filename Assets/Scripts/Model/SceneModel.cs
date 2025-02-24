﻿using UnityEngine.SceneManagement;

namespace Model
{
    public class SceneModel : AbstractModel
    {
        public SceneName SceneName { get; private set; }
        public int SceneIndex { get; private set; }
        public override bool IsInited => true;

        public void SetData(int index)
        {
            SceneIndex = index;
            SceneName = index switch
            {
                0 => SceneName.MainMenuScene,
                1 => SceneName.MiddleRoomScene,
                2 => SceneName.BattleScene,
                _ => SceneName
            };
        }

        public SceneModel()
        {
            SetData(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public enum SceneName
    {
        MainMenuScene,
        MiddleRoomScene,
        BattleScene,
    }
}