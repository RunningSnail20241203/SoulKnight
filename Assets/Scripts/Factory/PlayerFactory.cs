using Character;
using Character.Player;
using Singleton;
using UnityEngine;

namespace Factory
{
    public class PlayerFactory : Singleton<PlayerFactory>
    {
        public IPlayer CreatePlayer(PlayerType playerType)
        {
            var obj = GameObject.Find(playerType.ToString());
            IPlayer player = playerType switch
            {
                PlayerType.Knight => new Knight(obj),
                _ => null
            };
            return player;
        }
    }

    public enum PlayerType
    {
        Knight,
    }
}