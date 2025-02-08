using UnityEngine;

namespace Controller.MiddleRoom
{
    public class InputController : AbstractController
    {
        public PlayerControlInput Input { get; private set; }
        private Vector2 _dir;

        protected override void OnInit()
        {
            base.OnInit();
            Input = new PlayerControlInput();
        }

        protected override void AlwaysUpdate()
        {
            base.AlwaysUpdate();
            Input.Hor = UnityEngine.Input.GetAxis("Horizontal");
            Input.Ver = UnityEngine.Input.GetAxis("Vertical");
            _dir.Set(Input.Hor, Input.Ver);
            if (_dir.magnitude != 0)
            {
                Input.WeaponAimPos = _dir;
            }

            Input.IsAttack = UnityEngine.Input.GetMouseButton(0);
        }

        public override void Destroy()
        {
            base.Destroy();
            Input = null;
        }
    }

    public class PlayerControlInput
    {
        public float Hor;
        public float Ver;
        public Vector2 WeaponAimPos;
        public bool IsAttack;
    }
}