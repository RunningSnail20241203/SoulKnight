using StateMachine.PlayerStateMachine.Rogue;
using UnityEngine;

namespace Character.Player
{
    public class Rogue : AbstractPlayer
    {
        public Rogue(GameObject gameObject) : base(gameObject)
        {
            StateMachine.SetState<RogueIdleState>();
        }
    }
}