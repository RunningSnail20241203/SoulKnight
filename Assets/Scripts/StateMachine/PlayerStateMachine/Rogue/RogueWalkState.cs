using UnityEngine;

namespace StateMachine.PlayerStateMachine.Rogue
{
    public class RogueWalkState : AbstractPlayerState
    {
        private float _hor, _ver;
        private Vector2 _moveDir;

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

            if (_hor > 0)
            {
                Player.IsLeft = false;
            }
            else if (_hor < 0)
            {
                Player.IsLeft = true;
            }

            if (_moveDir.magnitude == 0)
            {
                StateMachine.SetState<RogueIdleState>();
            }
        }


        public RogueWalkState(PlayerStateMachine stateMachine) : base(stateMachine)
        {
        }
    }
}