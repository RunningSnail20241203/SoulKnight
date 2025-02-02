using UnityEngine;

namespace Character.Player
{
    public class Knight :IPlayer
    {
        private float hor, ver;
        private Vector2 moveDir;
        private Rigidbody2D _rigidbody2D;
        public Knight(GameObject gameObject) : base(gameObject)
        {
        }

        protected override void OnCharacterUpdate()
        {
            base.OnCharacterUpdate();
            hor = Input.GetAxis("Horizontal");
            ver = Input.GetAxis("Vertical");
            moveDir.Set(hor, ver);
            if (moveDir.magnitude > 0)
            {
                _rigidbody2D.transform.position += (Vector3)moveDir * 8 * Time.deltaTime;
            }
        }
    }
}