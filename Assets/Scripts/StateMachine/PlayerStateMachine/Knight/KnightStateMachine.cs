using Character;
using Character.Player;

namespace StateMachine.PlayerStateMachine.Knight
{
    public class KnightStateMachine : PlayerStateMachine
    {
        public KnightStateMachine(AbstractPlayer player) : base(player)
        {
            SetState<PlayerIdleState>();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            switch (CurrentState)
            {
                case PlayerIdleState:
                {
                    if (Ver != 0 || Hor != 0)
                    {
                        SetState<PlayerWalkState>();
                    }
                    break;
                }
                case PlayerWalkState:
                {
                    if (Ver == 0 && Hor == 0)
                    {
                        SetState<PlayerIdleState>();
                    }
                    break;
                }
            }
        }
    }
}