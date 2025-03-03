using Character;
using Character.Pet;
using UnityEngine;

namespace StateMachine.PetStateMachine
{
    public class PetStateMachine : AbstractStateMachine
    {
        public AbstractPet Pet { get; private set; }

        protected PetStateMachine(AbstractPet player)
        {
            Pet = player;
            SetState<PetIdleState>();
        }

        protected float GetDistanceToPlayer()
        {
            return Vector2.Distance(Pet.Transform.position, Pet.Player.Transform.position);
        }
    }
}