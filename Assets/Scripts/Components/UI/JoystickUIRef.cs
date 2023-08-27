using UnityEngine;

namespace RefAccess.UI
{
    public class JoystickUIRef : MonoBehaviour
    {
        [SerializeField] private RectTransform joystickHeader;
        [SerializeField] private RectTransform joystickBody;

        public RectTransform JoystickHeader => joystickHeader;
        public RectTransform JoystickBody => joystickBody;
    }
}