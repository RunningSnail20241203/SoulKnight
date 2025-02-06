using Character;
using UnityEngine;

namespace Mono
{
    public class PlayerRef : MonoBehaviour
    {
        public IPlayer Player { get; private set; }

        public void SetPlayer(IPlayer player)
        {
            Player = player;
        }
    }
}