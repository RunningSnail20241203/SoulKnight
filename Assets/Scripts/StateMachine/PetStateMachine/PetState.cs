using Character;
using Character.Pet;
using Character.Player;
using Pathfinding;
using UnityEngine;
using Utility;

namespace StateMachine.PetStateMachine
{
    public class PetState : AbstractState
    {
        #region Protected

        protected Animator Animator;
        protected Seeker Seeker;
        protected Path Path;
        protected AbstractPet Pet;
        protected Transform Transform => Pet.Transform;
        protected AbstractPlayer Player => Pet.Player;

        protected PetState(PetStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnInit()
        {
            base.OnInit();
            Pet = PetStateMachine.Pet;
            Animator = UnityTool.Instance.FindComponentFromChildren<Animator>(Pet.GameObject, "Sprite");
            Seeker = Pet.GameObject.GetComponent<Seeker>();
        }

        #endregion

        #region Private

        private PetStateMachine PetStateMachine => StateMachine as PetStateMachine;

        #endregion
    }
}