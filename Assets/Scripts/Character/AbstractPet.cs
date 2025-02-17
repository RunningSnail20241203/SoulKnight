using Command;
using Property.ShareProperty;
using StateMachine.PetStateMachine;
using UnityEngine;

namespace Character
{
    public class AbstractPet : AbstractCharacter, IDestroy
    {
        #region Public

        public PetShareAttr ShareAttr;
        public AbstractPlayer Player { get; private set; }
        public void Destroy()
        {
            PetStateMachine?.Destroy();
            PetStateMachine = null;
            Player = null;
            ShareAttr = null;
        }

        #endregion

        #region Protected

        protected PetStateMachine PetStateMachine { get; set; }
        protected virtual PetType PetType => PetType.None;

        protected AbstractPet(GameObject gameObject, AbstractPlayer player) : base(gameObject)
        {
            Player = player;
        }

        protected override void OnInit()
        {
            base.OnInit();
            ShareAttr = PetCommand.Instance.GetAttr(PetType);
        }

        protected override void OnCharacterUpdate()
        {
            base.OnCharacterUpdate();
            PetStateMachine?.GameUpdate();
        }

        #endregion
    }
}