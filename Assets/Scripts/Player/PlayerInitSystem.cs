using Components.Player;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems.Player
{
    public class PlayerInitSystem : IEcsInitSystem
    {
        readonly EcsWorld _world = null;
        private PlayerInitData _playerInitData;
        
        public void Init()
        {
            var player = _world.NewEntity();
            var spawnedPlayer = GameObject.Instantiate(_playerInitData.PlayerPrefab);
            
            ref var playerMovementComponent = ref player.Get<PlayerMovementComponent>();
                    playerMovementComponent.Transform = spawnedPlayer.transform;
                    playerMovementComponent.Speed = _playerInitData.PlayerSpeed;
                    
            ref var playerAnimationComponent = ref player.Get<PlayerAnimationComponent>();
                    playerAnimationComponent.Animator = spawnedPlayer.GetComponent<Animator>();
        }
    }
}