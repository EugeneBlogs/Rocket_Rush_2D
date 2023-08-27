using Components.UI.Joystick;
using Leopotam.Ecs;
using UnityEngine;

namespace Systems.UI.Joystick
{
    public class JoystickUIRunSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private EcsFilter<JoystickUIComponent> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref var joystickUIComponent = ref _filter.Get1(i);

                if (Input.touchCount > 0)
                {
                    if (Vector2.Distance(Input.GetTouch(0).position, joystickUIComponent.OriginHeaderPosition) < 800f)
                    {
                        if (Input.GetTouch(0).phase == TouchPhase.Began)
                        {
                            joystickUIComponent.TouchStart = true;
                            joystickUIComponent.FirstTouchPosition = Input.GetTouch(0).position;
                            joystickUIComponent.SecondTouchPosition = Input.GetTouch(0).position;

                            joystickUIComponent.Header.position = joystickUIComponent.FirstTouchPosition;
                            joystickUIComponent.Body.position = joystickUIComponent.FirstTouchPosition;
                        }
                    }

                    if ((Input.GetTouch(0).phase == TouchPhase.Moved ||
                         Input.GetTouch(0).phase == TouchPhase.Stationary) && joystickUIComponent.TouchStart == true)
                    {
                        joystickUIComponent.SecondTouchPosition = Input.GetTouch(0).position;
                        joystickUIComponent.Body.position = new Vector3(joystickUIComponent.FirstTouchPosition.x + joystickUIComponent.TouchDirection.x,
                            joystickUIComponent.FirstTouchPosition.y + joystickUIComponent.TouchDirection.y);
                    }

                    if (Input.GetTouch((0)).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                    {
                        joystickUIComponent.TouchStart = false;
                        joystickUIComponent.FirstTouchPosition = Vector2.zero;
                        joystickUIComponent.SecondTouchPosition = Vector2.zero;
                        joystickUIComponent.TouchDirection = Vector2.zero;
                        joystickUIComponent.Header.position = joystickUIComponent.OriginHeaderPosition;
                        joystickUIComponent.Body.position = joystickUIComponent.OriginBodyPosition;
                    }
                    
                    if (joystickUIComponent.TouchStart)
                    {
                        joystickUIComponent.TouchOffset = joystickUIComponent.SecondTouchPosition - joystickUIComponent.FirstTouchPosition;
                        joystickUIComponent.TouchDirection = Vector2.ClampMagnitude(joystickUIComponent.TouchOffset, 200f);
                    }
                }
            }
        }
    }
}