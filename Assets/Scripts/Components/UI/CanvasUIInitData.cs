using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CanvasUIInitData", menuName = "ScriptableObjects/CanvasUIInitData", order = 0)]
    public class CanvasUIInitData : ScriptableObject
    {
        [SerializeField] private GameObject canvasPrefab;

        public GameObject CanvasPrefab => canvasPrefab;
    }
}