using UnityEngine;

namespace StateMachine.PlayerStateMachine
{
    public class IdleState : AbstractPlayerState
    {
        #region Public

        public IdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnExit()
        {
            base.OnExit();
            Animator.SetBool(IsIdle, false);
        }

        #endregion


        #region Protected

        protected override void OnEnter()
        {
            base.OnEnter();
            Animator.SetBool(IsIdle, true);
            Rigidbody2D.velocity = Vector2.zero;
        }

        #endregion

        #region Private

        private static readonly int IsIdle = Animator.StringToHash("isIdle");

        #endregion
    }
}