using StateMachine.PetStateMachine.MoreMoney;
using UnityEngine;

namespace Character.Pet
{
    public class MoreMoney : AbstractPet
    {
        protected override PetType PetType => PetType.MoreMoney;
        public MoreMoney(GameObject gameObject, AbstractPlayer player) : base(gameObject, player)
        {
            PetStateMachine = new MoreMoneyStateMachine(this);
        }
    }
}