using Character;
using UnityEngine;

namespace StateMachine.PlayerStateMachine
{
    public abstract class AbstractPlayerState : AbstractState
    {
        #region Property
        protected AbstractPlayer Player => PlayerStateMachine.Player;
        protected GameObject GameObject => Player.GameObject;
        protected Transform Transform => Player.Transform;
        protected Rigidbody2D Rigidbody2D => Player.PlayerRigidbody2D;
        protected Animator Animator => Player.PlayerAnimator;
        private PlayerStateMachine PlayerStateMachine => StateMachine as PlayerStateMachine;
        #endregion


        protected AbstractPlayerState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    }
}