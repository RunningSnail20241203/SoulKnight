using Model;
using Property.ShareProperty;
using Singleton;
namespace Command
{
    public class PetCommand : Singleton<PetCommand>
    {
        public float GetMoveSpeed(PetType petType)
        {
            var playerModel = ModelContainer.Instance.GetModel<PetModel>();
            var attrs = playerModel.GetPetAttr(petType);
            return attrs.speed;
        }

        public PetShareAttr GetAttr(PetType petType)
        {
            var playerModel = ModelContainer.Instance.GetModel<PetModel>();
            return playerModel.GetPetAttr(petType);
        }
    }
}