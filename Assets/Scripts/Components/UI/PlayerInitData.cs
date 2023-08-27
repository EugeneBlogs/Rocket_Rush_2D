using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerInitData", menuName = "ScriptableObjects/PlayerInitData", order = 0)]
    public class PlayerInitData : ScriptableObject
    {
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private float playerSpeed;

        public GameObject PlayerPrefab => playerPrefab;
        public float PlayerSpeed => playerSpeed;
    }
}