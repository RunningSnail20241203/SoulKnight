using UnityEngine;

namespace StateMachine.PlayerStateMachine.Knight
{
    public class KnightWalkState : IPlayerState
    {
        private float _hor, _ver;
        private Vector2 _moveDir;
        
        public KnightWalkState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
            _hor = Input.GetAxis("Horizontal");
            _ver = Input.GetAxis("Vertical");
            _moveDir.Set(_hor, _ver);
            if (_moveDir.magnitude > 0)
            {
                Rigidbody2D.transform.position += (Vector3)_moveDir * 8 * Time.deltaTime;
            }

            if (_moveDir.magnitude == 0)
            {
                _stateMachine.SetState<KnightIdleState>();
            }
        }
    }
}