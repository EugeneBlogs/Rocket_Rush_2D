using RefAccess.UI;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "JoystickUIInitData", menuName = "ScriptableObjects/JoystickUIInitData", order = 0)]
    public class JoystickUIInitData : ScriptableObject
    {
        [SerializeField] private JoystickUIRef joystickUIRef;

        public JoystickUIRef JoystickUIRef => joystickUIRef;
    }
}