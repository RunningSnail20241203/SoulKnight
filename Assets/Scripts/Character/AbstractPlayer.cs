using System.Collections.Generic;
using Controller.MiddleRoom;
using Factory;
using Mono;
using StateMachine.PlayerStateMachine;
using UnityEngine;
using Utility;
using Weapon;

namespace Character
{
    public class AbstractPlayer : AbstractCharacter, IDestroy
    {
        #region Private Data

        private AbstractPlayerWeapon _curWeapon;
        private readonly List<AbstractPlayerWeapon> _playerWeapons = new();
        private PlayerControlInput _playerControlInput;

        #endregion

        #region Protected Data

        protected PlayerStateMachine StateMachine;

        #endregion

        #region Property

        public Animator PlayerAnimator { get; }

        public Rigidbody2D PlayerRigidbody2D { get; }

        #endregion

        #region Public API

        public async void AddWeapon(PlayerWeaponType playerWeaponType)
        {
            var weapon = await WeaponFactory.Instance.GetPlayerWeapon(playerWeaponType, this);
            if (_playerWeapons.Count == 0)
            {
                UseWeapon(weapon);
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

        public virtual void Destroy()
        {
            StateMachine?.Destroy();
            StateMachine = null;

            foreach (var weapon in _playerWeapons)
            {
                weapon.Destroy();
            }

            _playerWeapons.Clear();

            _curWeapon?.Destroy();
            _curWeapon = null;

            _playerControlInput = null;
        }

        #endregion

        #region Override Methods

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

        #endregion

        #region Private Methods

        private void UseWeapon(AbstractPlayerWeapon weapon)
        {
            _curWeapon?.UnUseWeapon();
            _curWeapon = weapon;
            _curWeapon.UseWeapon();
        }

        private void SwapWeapon()
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

            UseWeapon(_playerWeapons[index]);
        }

        #endregion

        #region Protected Methods

        protected AbstractPlayer(GameObject gameObject) : base(gameObject)
        {
            PlayerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            PlayerAnimator = UnityTool.Instance.FindComponentFromChildren<Animator>(gameObject, "Sprite");
            var playerRef = UnityTool.Instance.AddComponentForChildren<PlayerRef>(gameObject, "Collider", true);
            playerRef.SetPlayer(this);
        }

        #endregion
    }
}