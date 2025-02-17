using UnityEngine;

namespace StateMachine.PlayerStateMachine
{
    public class PlayerIdleState : PlayerState
    {
        #region Public

        public PlayerIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        #endregion


        #region Protected

        protected override void OnEnter()
        {
            base.OnEnter();
            Rigidbody2D.velocity = Vector2.zero;
        }

        #endregion
    }
}