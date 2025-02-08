using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoop
{
    public class MainMenuGameLoop : MonoBehaviour
    {
        private Facade.MainMenuScene.Facade _facade;

        private void Start()
        {
            _facade = new Facade.MainMenuScene.Facade();
        }


        private void Update()
        {
            _facade.GameUpdate();
        }
    }
}