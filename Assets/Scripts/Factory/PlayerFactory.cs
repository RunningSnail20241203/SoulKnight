using Character;
using Character.Player;
using Controller.MiddleRoom;
using GameLoop;
using Mediator;
using Singleton;
using UnityEngine;

namespace Factory
{
    public class PlayerFactory : Singleton<PlayerFactory>
    {
        public AbstractPlayer GetPlayer(PlayerType playerType)
        {
            var obj = GameObject.Find(playerType.ToString());
            AbstractPlayer player = playerType switch
            {
                PlayerType.Knight => new Knight(obj),
                PlayerType.Ranger => new Ranger(obj),
                _ => null
            };
            if (player == null) return null;

            player.SetPlayerControlInput(GameMediator.Instance.GetController<InputController>().Input);
            return player;

        }
    }

    public enum PlayerType
    {
        None,
        Knight,
        Ranger,
    }
    
    public enum PlayerSkin
    {
        Base,
        Kun,
    }
}