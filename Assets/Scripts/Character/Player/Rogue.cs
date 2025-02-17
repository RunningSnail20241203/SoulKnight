using StateMachine.PlayerStateMachine;
using StateMachine.PlayerStateMachine.Knight;
using StateMachine.PlayerStateMachine.Rogue;
using UnityEngine;

namespace Character.Player
{
    public class Rogue : AbstractPlayer
    {
        public Rogue(GameObject gameObject) : base(gameObject)
        {
        }

        protected override void OnCharacterStart()
        {
            base.OnCharacterStart();
            StateMachine = new RogueStateMachine(this);
        }
    }
}