using System;
using Character;
using Character.Pet;
using Character.Player;
using Singleton;
using Utility;

namespace Factory
{
    public class PetFactory : Singleton<PetFactory>
    {
        public AbstractPet GetPet(PetType petType, AbstractPlayer player)
        {
            var obj = UnityTool.Instance.FindGameObjectInScene(petType.ToString());
            return petType switch
            {
                PetType.MoreMoney => new MoreMoney(obj, player),
                _ => throw new ArgumentOutOfRangeException(nameof(petType), petType, null)
            };
        }
    }
}