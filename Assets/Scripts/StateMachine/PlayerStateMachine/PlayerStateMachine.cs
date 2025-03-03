using Character;
using Character.Player;
using UnityEngine;

namespace StateMachine.PlayerStateMachine
{
    public class PlayerStateMachine : AbstractStateMachine
    {
        public AbstractPlayer Player { get; private set; }

        protected PlayerStateMachine(AbstractPlayer player)
        {
            Player = player;
        }

        public override void Destroy()
        {
            base.Destroy();
            Player = null;
        }

        #region Protected

        protected float Hor, Ver;
        protected override void OnUpdate()
        {
            base.OnUpdate();
            Hor = Input.GetAxis("Horizontal");
            Ver = Input.GetAxis("Vertical");
        }

        #endregion
    }
}