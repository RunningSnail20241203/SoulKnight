using UnityEngine;

namespace StateMachine.PlayerStateMachine.Rogue
{
    public class RogueIdleState : AbstractPlayerState
    {
        private static readonly int IsIdle = Animator.StringToHash("isIdle");
        private float _hor, _ver;
        private Vector2 _moveDir;

        public RogueIdleState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            Animator.SetBool(IsIdle, true);
            Rigidbody2D.velocity = Vector2.zero;
        }

        public override void OnExit()
        {
            base.OnExit();
            Animator.SetBool(IsIdle, false);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();

            _hor = Input.GetAxis("Horizontal");
            _ver = Input.GetAxis("Vertical");
            _moveDir.Set(_hor, _ver);
            if (_moveDir.magnitude > 0f)
            {
                StateMachine.SetState<RogueWalkState>();
            }
        }
    }
}