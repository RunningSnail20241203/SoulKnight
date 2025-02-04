using StateMachine.PlayerStateMachine.Knight;
using UnityEngine;

namespace Character.Player
{
    public class Knight : IPlayer
    {
        public Knight(GameObject gameObject) : base(gameObject)
        {
            StateMachine.SetState<KnightIdleState>();
        }
    }
}