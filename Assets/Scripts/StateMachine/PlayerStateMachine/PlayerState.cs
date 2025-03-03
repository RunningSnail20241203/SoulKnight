using Character;
using Character.Player;
using UnityEngine;

namespace StateMachine.PlayerStateMachine
{
    public abstract class PlayerState : AbstractState
    {
        #region Private
        private PlayerStateMachine PlayerStateMachine => StateMachine as PlayerStateMachine;
        #endregion




        #region Protected

        protected AbstractPlayer Player => PlayerStateMachine.Player;
        protected GameObject GameObject => Player.GameObject;
        protected Transform Transform => Player.Transform;
        protected Rigidbody2D Rigidbody2D => Player.PlayerRigidbody2D;
        protected Animator Animator => Player.PlayerAnimator;
        protected PlayerState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        #endregion
    }
}