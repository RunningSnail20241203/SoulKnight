using Character;

namespace StateMachine.PlayerStateMachine
{
    public class PlayerStateMachine : AbstractStateMachine
    {
        public AbstractPlayer Player { get; private set; }

        public PlayerStateMachine(AbstractPlayer player)
        {
            Player = player;
        }

        public override void Destroy()
        {
            base.Destroy();
            Player = null;
        }
    }
}