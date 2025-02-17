using Character;

namespace StateMachine.PlayerStateMachine.Rogue
{
    public class RogueStateMachine : PlayerStateMachine
    {
        public RogueStateMachine(AbstractPlayer player) : base(player)
        {
            SetState<IdleState>();
        }
        
        protected override void OnUpdate()
        {
            base.OnUpdate();
            switch (CurrentState)
            {
                case IdleState:
                {
                    if (Ver != 0 || Hor != 0)
                    {
                        SetState<WalkState>();
                    }
                    break;
                }
                case WalkState:
                {
                    if (Ver == 0 && Hor == 0)
                    {
                        SetState<IdleState>();
                    }
                    break;
                }
            }
        }
    }
}