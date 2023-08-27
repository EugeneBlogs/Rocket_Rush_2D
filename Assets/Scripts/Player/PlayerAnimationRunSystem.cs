using Components.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.Player
{
    public class PlayerAnimationRunSystem : IEcsRunSystem
    {
        private EcsFilter<PlayerAnimationComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                var playerAnimationComponent = _filter.Get1(i);

                var horizontal = Input.GetAxisRaw("Horizontal");
                var vertical = Input.GetAxisRaw("Vertical");

                if (horizontal != 0 || vertical != 0)
                    playerAnimationComponent.Animator.Play("Movement");
                if (horizontal == 0 && vertical == 0)
                    playerAnimationComponent.Animator.Play("Idle");

                if (horizontal != 0 || vertical != 0)
                {
                    playerAnimationComponent.Animator.SetFloat("Horizontal", horizontal);
                    playerAnimationComponent.Animator.SetFloat("Vertical", vertical);
                }
            }
        }
    }
}