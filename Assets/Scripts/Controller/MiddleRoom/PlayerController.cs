using System.Collections.Generic;
using Character;
using Character.Pet;
using Character.Player;
using Factory;
using GameLoop;

namespace Controller.MiddleRoom
{
    public class PlayerController : AbstractController
    {
        #region Public

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
        
        public void AddPet(AbstractPet pet)
        {
            _pets.Add(pet);
        }
        
        public override void Destroy()
        {
            base.Destroy();
            MainPlayer?.Destroy();
            MainPlayer = null;
            
            _pets.ForEach(x=>x.Destroy());
            _pets.Clear();
        }

        #endregion
        
        #region Protected
        protected override void OnAfterRunUpdate()
        {
            base.OnAfterRunUpdate();
            MainPlayer?.GameUpdate();
            _pets.ForEach(x=>x.GameUpdate());
        }
        #endregion

        #region Private

        private readonly List<AbstractPet> _pets = new();

        #endregion
    }
}