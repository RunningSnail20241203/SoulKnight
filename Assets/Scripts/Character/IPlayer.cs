using UnityEngine;

namespace Character
{
    public class IPlayer : ICharacter
    {
        protected Animator _animator;
        public IPlayer(GameObject gameObject) : base(gameObject)
        {
        }

        protected override void OnInit()
        {
            base.OnInit();
            _animator = Transform.Find("Sprite").GetComponent<Animator>();
        }
    }
}