using Character;
using Factory;
using GameLoop;

namespace Controller.MiddleRoom
{
    public class PlayerController : AbstractController
    {
        public IPlayer MainPlayer { get; protected set; }

        protected override void OnInit()
        {
            base.OnInit();

            // MainPlayer = PlayerFactory.Instance.CreatePlayer(PlayerType.Knight);
            // MainPlayer.SetPlayerControlInput(GameMediator.Instance.GetController<InputController>().Input);
        }

        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            // MainPlayer.GameUpdate();
        }
    }
}