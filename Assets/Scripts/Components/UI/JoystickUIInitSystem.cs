using Components.UI.Canvas;
using Components.UI.Joystick;
using Leopotam.Ecs;
using RefAccess.UI;
using ScriptableObjects;
using UnityEngine;

namespace Systems.UI.Joystick
{
    public class JoystickUIInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<CanvasUIComponent> _filter;

        private JoystickUIInitData _joystickUIInitData;
        
        public void Init()
        {
            foreach (var i in _filter)
            {
                var canvasUIComponent = _filter.Get1(i);
                var joystickUI = _world.NewEntity();
                
                var spawnedJoystick =
                    GameObject.Instantiate(_joystickUIInitData.JoystickUIRef.gameObject, canvasUIComponent.Root);

                ref var joystickUIComponent = ref joystickUI.Get<JoystickUIComponent>();
                        joystickUIComponent.Header = spawnedJoystick.GetComponent<JoystickUIRef>().JoystickHeader;
                        joystickUIComponent.Body = spawnedJoystick.GetComponent<JoystickUIRef>().JoystickBody;
                        joystickUIComponent.OriginHeaderPosition = spawnedJoystick.GetComponent<JoystickUIRef>().JoystickHeader.position;
                        joystickUIComponent.OriginBodyPosition = spawnedJoystick.GetComponent<JoystickUIRef>().JoystickBody.position;
            }
        }
    }
}