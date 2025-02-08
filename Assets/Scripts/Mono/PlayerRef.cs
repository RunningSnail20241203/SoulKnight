using System;
using Character;
using UnityEngine;

namespace Mono
{
    public class PlayerRef : MonoBehaviour
    {
        public AbstractPlayer Player { get; private set; }

        public void SetPlayer(AbstractPlayer player)
        {
            Player = player;
        }

        private void OnDestroy()
        {
            Player = null;
        }
    }
}