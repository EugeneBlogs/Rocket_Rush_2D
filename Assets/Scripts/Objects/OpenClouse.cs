using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClouse : MonoBehaviour {


    [SerializeField] Vector3 _startPos;
    [SerializeField] Vector3 _finishPos;
    [SerializeField] float _movingTime = 1;
    [SerializeField] float _waitingTime = 0.1f;
    float _time = 0;
	// Use this for initialization
	void Start () {
        StartCoroutine(MoveTop());
	}
	
	IEnumerator MoveTop()
    {
        transform.localPosition = Vector3.Lerp(_startPos, _finishPos, _time / _movingTime);
        _time += Time.deltaTime;
        if (_time > _movingTime)
        {
            yield return new WaitForSeconds(_waitingTime);
            _time = 0;
            StartCoroutine(MoveBottom());
            yield break;
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine(MoveTop());
    }

    IEnumerator MoveBottom()
    {
        transform.localPosition = Vector3.Lerp(_finishPos, _startPos, _time / _movingTime);
        _time += Time.deltaTime;
       
        if (_time > _movingTime)
        {
            yield return new WaitForSeconds(_waitingTime);
            _time = 0;
            StartCoroutine(MoveTop());
            yield break;
        }
        yield return new WaitForEndOfFrame();
        StartCoroutine(MoveBottom());
    }
}
