using Components.UI.Canvas;
using Leopotam.Ecs;
using ScriptableObjects;
using UnityEngine;

namespace Systems.UI.Joystick
{
    public class CanvasUIInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private CanvasUIInitData _canvasUIInitData;
        
        public void Init()
        {
            var canvas = _world.NewEntity();
            var spawnedCanvas = GameObject.Instantiate(_canvasUIInitData.CanvasPrefab);

            ref var canvasUIComponent = ref canvas.Get<CanvasUIComponent>();
                    canvasUIComponent.Canvas = spawnedCanvas.GetComponent<Canvas>();
                    canvasUIComponent.Root = spawnedCanvas.transform;
        }
    }
}