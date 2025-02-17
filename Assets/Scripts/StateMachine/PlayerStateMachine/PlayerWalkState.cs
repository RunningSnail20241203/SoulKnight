using UnityEngine;

namespace StateMachine.PlayerStateMachine
{
    public class PlayerWalkState : PlayerState
    {
        #region Public

        public PlayerWalkState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        #endregion

        #region Protected

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _hor = Input.GetAxis("Horizontal");
            _ver = Input.GetAxis("Vertical");
            _moveDir.Set(_hor, _ver);
            if (_moveDir.magnitude > 0)
            {
                Rigidbody2D.transform.position += (Vector3)_moveDir.normalized * (Player.ShareAttr.speed * Time.deltaTime);
            }

            Player.IsLeft = _hor switch
            {
                > 0 => false,
                < 0 => true,
                _ => Player.IsLeft
            };
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            Animator.SetBool(IsRun, true);
        }

        protected override void OnExit()
        {
            base.OnExit();
            Animator.SetBool(IsRun, false);
        }

        #endregion

        #region Private

        private float _hor, _ver;
        private Vector2 _moveDir;

        #endregion
    }
}