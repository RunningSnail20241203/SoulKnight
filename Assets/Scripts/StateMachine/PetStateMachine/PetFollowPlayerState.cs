using System.Collections;
using UnityEngine;
using Utility;

namespace StateMachine.PetStateMachine
{
    public class PetFollowPlayerState : PetState
    {
        #region Protected

        public PetFollowPlayerState(PetStateMachine stateMachine) : base(stateMachine)
        {
        }

        protected override void OnEnter()
        {
            base.OnEnter();
            Animator.SetBool(IsRun, true);
            CoroutinePool.Instance.StartCoroutine(this, FollowPlayer());
        }

        protected override void OnExit()
        {
            base.OnExit();
            Animator.SetBool(IsRun, false);
            CoroutinePool.Instance.StopCoroutine(this);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            MoveToTarget();

            Pet.IsLeft = _moveDir.x switch
            {
                > 0 => false,
                < 0 => true,
                _ => Pet.IsLeft
            };
        }

        #endregion


        #region Private

        private int _currentPathIndex;
        private const float MinDistance = 1f;
        private Vector3 _moveDir;

        private IEnumerator FollowPlayer()
        {
            while (true)
            {
                if (Seeker.IsDone())
                {
                    Seeker.StartPath(Transform.position, Player.Transform.position, (p) =>
                    {
                        Path = p;
                        _currentPathIndex = 1;
                        // Debug.Log($"[FollowPlayer]_currentPathIndex:{_currentPathIndex}");
                    });
                    // yield break;
                }
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void MoveToTarget()
        {
            if (Path == null) return;
            if (_currentPathIndex >= Path.vectorPath.Count) return;

            _moveDir = Path.vectorPath[_currentPathIndex] - Transform.position;
            Transform.position = Vector3.MoveTowards(Transform.position,
                Path.vectorPath[_currentPathIndex],
                Pet.ShareAttr.speed * Time.deltaTime);
            var distance = Vector2.Distance(Transform.position, Path.vectorPath[_currentPathIndex]);
            if (distance < MinDistance)
            {
                _currentPathIndex++;
                // Debug.Log($"[MoveToTarget]_currentPathIndex:{_currentPathIndex}");
            }
        }

        #endregion
    }
}