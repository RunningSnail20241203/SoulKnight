using Character;
using Character.Player;
using Controller.MiddleRoom;
using GameLoop;
using Mediator;
using Singleton;
using UnityEngine;
using Utility;

namespace Factory
{
    public class PlayerFactory : Singleton<PlayerFactory>
    {
        public AbstractPlayer GetPlayer(PlayerType playerType)
        {
            var obj = UnityTool.Instance.FindGameObjectInScene(playerType.ToString());
            AbstractPlayer player = playerType switch
            {
                PlayerType.Knight => new Knight(obj),
                PlayerType.Rogue => new Rogue(obj),
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
        Rogue,
    }

    public enum PlayerSkinType
    {
        None,
        Knight = 100,
        KnightLava,
        Rogue = 200,
        RogueKun,
        Wizard = 300,
        Assassin = 400,
        Alchemist = 500,
        Engineer = 600,
        Vampire = 700,
    }
}