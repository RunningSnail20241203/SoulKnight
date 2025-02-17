using StateMachine.PlayerStateMachine.Knight;
using UnityEngine;

namespace Character.Player
{
    public class Knight : AbstractPlayer
    {
        public Knight(GameObject gameObject) : base(gameObject)
        {
        }

        protected override void OnCharacterStart()
        {
            base.OnCharacterStart();
            StateMachine = new KnightStateMachine(this);
        }
    }
}