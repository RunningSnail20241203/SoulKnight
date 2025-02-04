using StateMachine.PlayerStateMachine;
using UnityEngine;

namespace Character
{
    public class IPlayer : ICharacter
    {
        #region Private Data
        private Animator _animator;
        private Rigidbody2D _rigidbody2D;
        #endregion

        #region Protected Data
        protected PlayerStateMachine StateMachine;
        #endregion

        #region Property
        public Animator PlayerAnimator => _animator;
        public Rigidbody2D PlayerRigidbody2D => _rigidbody2D;
        #endregion

        protected IPlayer(GameObject gameObject) : base(gameObject)
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _animator = Transform.Find("Sprite").GetComponent<Animator>();
            StateMachine = new PlayerStateMachine(this);
        }

        protected override void OnCharacterUpdate()
        {
            base.OnCharacterUpdate();
            StateMachine.GameUpdate();
        }
    }
}