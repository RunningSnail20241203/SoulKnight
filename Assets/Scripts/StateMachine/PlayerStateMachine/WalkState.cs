using UnityEngine;

namespace StateMachine.PlayerStateMachine
{
    public class WalkState : AbstractPlayerState
    {
        private float _hor, _ver;
        private Vector2 _moveDir;
        
        public WalkState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            _hor = Input.GetAxis("Horizontal");
            _ver = Input.GetAxis("Vertical");
            _moveDir.Set(_hor, _ver);
            if (_moveDir.magnitude > 0)
            {
                Rigidbody2D.transform.position += (Vector3)_moveDir.normalized * (8 * Time.deltaTime);
            }

            Player.IsLeft = _hor switch
            {
                > 0 => false,
                < 0 => true,
                _ => Player.IsLeft
            };
        }
    }
}