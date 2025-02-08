using System.Collections.Generic;
using Controller.MiddleRoom;
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
        private IPlayerWeapon _curWeapon;
        private readonly List<IPlayerWeapon> _playerWeapons = new();
        private Vector2 _mouseDir;
        private PlayerControlInput _playerControlInput;

        #endregion

        #region Protected Data

        protected readonly PlayerStateMachine StateMachine;

        #endregion

        #region Property

        public Animator PlayerAnimator => _animator;
        public Rigidbody2D PlayerRigidbody2D => _rigidbody2D;

        #endregion

        #region Public API

        public async void AddWeapon(PlayerWeaponType playerWeaponType)
        {
            var weapon = await WeaponFactory.Instance.GetPlayerWeapon(playerWeaponType, this);
            if (_playerWeapons.Count == 0)
            {
                weapon.UseWeapon();
            }
            else
            {
                weapon.UnUseWeapon();
            }

            _playerWeapons.Add(weapon);
        }

        public void SetPlayerControlInput(PlayerControlInput playerControlInput)
        {
            _playerControlInput = playerControlInput;
        }

        public void SwapWeapon()
        {
            if (_playerWeapons.Count == 0) return;
            var index = _playerWeapons.FindIndex(x => x.IsUsed);
            if (index < _playerWeapons.Count - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            if (_curWeapon != null)
            {
                _curWeapon.UnUseWeapon();
            }

            UseWeapon(_playerWeapons[index]);
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
            if (Input.GetMouseButtonDown(1))
            {
                SwapWeapon();
            }

            if (_curWeapon != null)
            {
                _curWeapon.GameUpdate();
                _curWeapon.ControlWeapon(_playerControlInput.IsAttack);
                _curWeapon.RotateWeapon(_playerControlInput.WeaponAimPos);
            }
        }

        private void UseWeapon(IPlayerWeapon weapon)
        {
            weapon.UseWeapon();
            _curWeapon = weapon;
        }
    }
}