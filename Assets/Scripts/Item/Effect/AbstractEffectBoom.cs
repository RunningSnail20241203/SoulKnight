using Controller.MiddleRoom;
using Mediator;
using UnityEngine;

namespace Item.Effect
{
    public class AbstractEffectBoom : AbstractItem
    {
        #region Public

        public void AddToController()
        {
            GameMediator.Instance.GetController<EffectController>().AddEffect(this);
        }

        #endregion
        
        protected AbstractEffectBoom(GameObject obj) : base(obj)
        {
        }

        protected override void OnExit()
        {
            base.OnExit();
            Object.Destroy(GameObject);
        }
    }
}