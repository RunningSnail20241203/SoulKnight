using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameLoop
{
    public class MainMenuGameLoop : MonoBehaviour
    {
        private Facade.MainMenuScene.Facade _facade;
        // Start is called before the first frame update
        private void Start()
        {
            _facade = new Facade.MainMenuScene.Facade();
        }

        // Update is called once per frame
        private void Update()
        {
            _facade.GameUpdate();
        }
    }
    
}
