using System.Collections.Generic;
using Factory;
using Model;
using Singleton;
namespace Command
{
    public class PlayerCommand : Singleton<PlayerCommand>
    {
        public List<PlayerSkinType> GetSkinTypes(PlayerType playerType)
        {
            var playerModel = ModelContainer.Instance.GetModel<PlayerModel>();
            var attrs = playerModel.GetPlayerAttr(playerType);
            return attrs.skinTypes;
        }
    }
}