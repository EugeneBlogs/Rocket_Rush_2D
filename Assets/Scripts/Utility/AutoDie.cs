using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDie : MonoBehaviour {

    [SerializeField]
    float lifeTime = 0.1f;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, lifeTime);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
