using Character;

namespace StateMachine.PetStateMachine.MoreMoney
{
    public class MoreMoneyStateMachine : PetStateMachine
    {
        #region Public

        public MoreMoneyStateMachine(AbstractPet player) : base(player)
        {
        }

        #endregion

        #region Protected

        protected override void OnUpdate()
        {
            base.OnUpdate();
            switch (CurrentState)
            {
                case PetIdleState:
                    if (GetDistanceToPlayer() > 5)
                    {
                        SetState<PetFollowPlayerState>();
                    }
                    break;
                case PetFollowPlayerState:
                    if (GetDistanceToPlayer() < 2)
                    {
                        SetState<PetIdleState>();
                    }
                    break;
            }
        }

        #endregion
    }
}