using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repaler : MonoBehaviour {

    [SerializeField] bool _isAvalible;
    [SerializeField] AudioSource _replaySound;
	public void ReparePlayer()
    {
        if (!_isAvalible) return;
        Player.Instance.Demage();
        Player.Instance.gameObject.transform.eulerAngles = Vector3.zero;
        if (_replaySound != null) _replaySound.Play();
    }


}
