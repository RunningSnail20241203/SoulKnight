using Character;

namespace StateMachine.PlayerStateMachine
{
    public class PlayerStateMachine :IStateMachine
    {
        public IPlayer Player { get; set; }

        public PlayerStateMachine(IPlayer player)
        {
            Player = player;
        }
    }
}