using StateMachine.PlayerStateMachine.Ranger;
using UnityEngine;

namespace Character.Player
{
    public class Ranger : AbstractPlayer
    {
        public Ranger(GameObject gameObject) : base(gameObject)
        {
            StateMachine.SetState<RangerIdleState>();
        }
    }
}