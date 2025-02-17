using StateMachine.PlayerStateMachine;
using StateMachine.PlayerStateMachine.Knight;
using StateMachine.PlayerStateMachine.Rogue;
using UnityEngine;

namespace Character.Player
{
    public class Rogue : AbstractPlayer
    {
        public Rogue(GameObject gameObject) : base(gameObject)
        {
        }

        #region Protected

        protected override PlayerType PlayerType => PlayerType.Rogue;
        protected override void OnCharacterStart()
        {
            base.OnCharacterStart();
            StateMachine = new RogueStateMachine(this);
        }

        #endregion

    }
}