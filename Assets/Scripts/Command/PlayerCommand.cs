using System.Collections.Generic;
using Model;
using Property.ShareProperty;
using Singleton;
namespace Command
{
    public class PlayerCommand : Singleton<PlayerCommand>
    {
        public List<PlayerSkinType> GetSkinTypes(PlayerType playerType)
        {
            var attrs = GetAttr(playerType);
            return attrs.skinTypes;
        }

        public PlayerShareAttr GetAttr(PlayerType playerType)
        {
            var playerModel = ModelContainer.Instance.GetModel<PlayerModel>();
            return playerModel.GetPlayerAttr(playerType);
        }
    }
}