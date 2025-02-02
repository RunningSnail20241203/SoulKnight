using Character;
using Factory;

namespace Controller.MiddleRoom
{
    public class PlayerController :AbstractController
    {
        public IPlayer MainPlayer{ get; protected set; }

        protected override void OnInit()
        {
            base.OnInit();

            MainPlayer = PlayerFactory.Instance.CreatePlayer(PlayerType.Knight);
        }

        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            MainPlayer.GameUpdate();
        }
    }
}