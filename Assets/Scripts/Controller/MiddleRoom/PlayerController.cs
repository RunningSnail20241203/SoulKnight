using Character;
using Factory;
using GameLoop;

namespace Controller.MiddleRoom
{
    public class PlayerController : AbstractController
    {
        public AbstractPlayer MainPlayer { get; private set; }
        public PlayerType CurSelectPlayerType { get; private set; }

        public void SetMainPlayer(PlayerType playerType)
        {
            MainPlayer = PlayerFactory.Instance.GetPlayer(playerType);
        }

        public void SetSelectPlayer(PlayerType playerType)
        {
            CurSelectPlayerType = playerType;
        }

        public void ClearSelectPlayer()
        {
            CurSelectPlayerType = PlayerType.None;
        }
        
        protected override void OnAfterRunUpdate()
        {
            base.OnAfterRunUpdate();
            MainPlayer?.GameUpdate();
        }

        public override void Destroy()
        {
            base.Destroy();
            MainPlayer?.Destroy();
            MainPlayer = null;
        }
    }
}