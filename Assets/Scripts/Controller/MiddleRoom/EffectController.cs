using System.Collections.Generic;
using Item.Effect;

namespace Controller.MiddleRoom
{
    public class EffectController : AbstractController
    {
        #region Public

        public void AddEffect(AbstractEffectBoom effect)
        {
            _effects.Add(effect);
        }

        #endregion

        #region Protected

        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            _effects.RemoveAll(x => !x.GameObject);
            _effects.ForEach(x=>x.GameUpdate());
        }

        #endregion

        #region Private

        private readonly List<AbstractEffectBoom> _effects = new();

        #endregion
    }
}