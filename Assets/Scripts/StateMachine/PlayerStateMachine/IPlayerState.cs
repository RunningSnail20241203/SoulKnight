using Character;
using UnityEngine;

namespace StateMachine.PlayerStateMachine
{
    public abstract class IPlayerState : IState
    {
        #region Property
        protected IPlayer Player => PlayerStateMachine.Player;
        protected GameObject GameObject => Player.GameObject;
        protected Transform Transform => Player.Transform;
        protected Rigidbody2D Rigidbody2D => Player.PlayerRigidbody2D;
        protected Animator Animator => Player.PlayerAnimator;
        private PlayerStateMachine PlayerStateMachine => StateMachine as PlayerStateMachine;
        #endregion


        protected IPlayerState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        protected override void OnEnter()
        {
            base.OnEnter();
            Debug.Log(this);
        }

    }
}