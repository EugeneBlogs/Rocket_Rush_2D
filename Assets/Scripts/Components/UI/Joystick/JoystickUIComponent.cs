using UnityEngine;

namespace Components.UI.Joystick
{
    public struct JoystickUIComponent
    {
        public RectTransform Header;
        public RectTransform Body;

        public Vector2 OriginHeaderPosition;
        public Vector2 OriginBodyPosition;
        public Vector2 FirstTouchPosition;
        public Vector2 SecondTouchPosition;
        public Vector2 TouchOffset;
        public Vector2 TouchDirection;

        public bool TouchStart;
    }
}