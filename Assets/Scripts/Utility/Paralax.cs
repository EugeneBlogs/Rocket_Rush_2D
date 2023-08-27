using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {

	[SerializeField] List<GameObject> levels;
	[SerializeField] List<float> coofs;
	[SerializeField] Transform _mainPlayer;
	Vector3 prevPos;

	// Use this for initialization
	void Start () {
		prevPos = _mainPlayer.position;
	}



	// Update is called once per frame
	void LateUpdate () {
		Vector3 delta = _mainPlayer.position - prevPos;
		delta.y = 0;

		for (int i = 0; i < levels.Count; ++i) {
			levels [i].transform.position += delta / coofs [i];
		}
		
		prevPos = _mainPlayer.position;
	}
}
