using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : MonoBehaviour {

    const int ASTEROIDS_COUNT = 10;

    [SerializeField] Vector2 _posiblePeriodRange;
    [SerializeField] List<GameObject> _samples;

    private void Start()
    {
        StartCoroutine(SpawnNewObject());
    }

    IEnumerator SpawnNewObject()
    {
        if (AsteroidObject.Count < ASTEROIDS_COUNT)
        {
            Spawn();
        }
        yield return new WaitForSeconds(Random.Range(_posiblePeriodRange.x, _posiblePeriodRange.y));
        StartCoroutine(SpawnNewObject());
    }

    void Spawn()
    {
        var s = _samples[Random.Range(0, _samples.Count)];
        var rot = new Vector3(0, 0, Random.value * 360);
        Instantiate(s, transform.position, Quaternion.Euler(rot));
    }

}
