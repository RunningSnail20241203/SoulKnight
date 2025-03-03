using System.Collections.Generic;
using Command;
using Controller.MiddleRoom;
using Factory;
using Mediator;
using Mono;
using Property.ShareProperty;
using StateMachine.PlayerStateMachine;
using UnityEngine;
using Utility;
using Weapon;

namespace Character.Player
{
    public class AbstractPlayer : AbstractCharacter, IDestroy
    {
        #region Public
        public Animator PlayerAnimator { get; }
        public Rigidbody2D PlayerRigidbody2D { get; }
        public PlayerShareAttr ShareAttr { get; set; }

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

        #region Protected

        protected PlayerStateMachine StateMachine;

        #region Override Methods

        protected virtual PlayerType PlayerType => PlayerType.None;

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

        protected override void OnInit()
        {
            base.OnInit();

            ShareAttr = PlayerCommand.Instance.GetAttr(PlayerType);
            
            var pet = PetFactory.Instance.GetPet(PetType.MoreMoney, this);
            GameMediator.Instance.GetController<PlayerController>().AddPet(pet);
        }

        #endregion

        protected AbstractPlayer(GameObject gameObject) : base(gameObject)
        {
            PlayerRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
            PlayerAnimator = UnityTool.Instance.FindComponentFromChildren<Animator>(gameObject, "Sprite");
            var playerRef = UnityTool.Instance.AddComponentForChildren<PlayerRef>(gameObject, "Collider");
            playerRef.SetPlayer(this);
            
       
        }

        #endregion

        #region Private

        private AbstractPlayerWeapon _curWeapon;
        private readonly List<AbstractPlayerWeapon> _playerWeapons = new();
        private PlayerControlInput _playerControlInput;

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
    }
}