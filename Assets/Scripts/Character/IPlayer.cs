using Factory;
using Mono;
using StateMachine.PlayerStateMachine;
using UnityEngine;
using Weapon;

namespace Character
{
    public class IPlayer : ICharacter
    {
        #region Private Data

        private readonly Animator _animator;
        private readonly Rigidbody2D _rigidbody2D;
        private IPlayerWeapon _playerWeapon;

        #endregion

        #region Protected Data

        protected PlayerStateMachine StateMachine;

        #endregion

        #region Property

        public Animator PlayerAnimator => _animator;
        public Rigidbody2D PlayerRigidbody2D => _rigidbody2D;

        #endregion

        #region Public API

        public async void AddWeapon(PlayerWeaponType playerWeaponType)
        {
            var weapon = await WeaponFactory.Instance.GetPlayerWeapon(playerWeaponType, this);
            _playerWeapon = weapon as IPlayerWeapon;
        }

        #endregion

        protected IPlayer(GameObject gameObject) : base(gameObject)
        {
            _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            _animator = UnityTool.Instance.GetComponentFromChildren<Animator>(gameObject, "Sprite");
            var playerRef = UnityTool.Instance.AddComponentForChildren<PlayerRef>(gameObject, "Collider");
            playerRef.SetPlayer(this);
            StateMachine = new PlayerStateMachine(this);
        }

        protected override void OnCharacterUpdate()
        {
            base.OnCharacterUpdate();
            StateMachine.GameUpdate();
        }
    }
}