using System;
using UnityEngine;
using System.Collections;

public class CameraMover : MonoBehaviour
{

    private Transform _target;
    [SerializeField] private float _removalRate = 1.2f;
    [SerializeField]
    Vector2 _followBounds;
    private float _deltaX;
    private float _normalPlayerY;
    private bool _isStart = false;


    private float _normalCameraY;

    [SerializeField] private float _cameraUpAmplitude = 0.1f;
    private float _normalSize;
    [SerializeField]
    private GameObject _background;

    [SerializeField]
    Vector3 _backgroundNormalSize;

	void Start ()
	{
        _target = FindObjectOfType<Player>().transform;
	    _normalCameraY = transform.position.y;
        StartFollow();
	}
	
	// Update is called once per frame
	void Update () {
       
	    if (_isStart)
	    {
	         transform.position = new Vector3(Mathf.Clamp(_target.position.x + _deltaX,_followBounds.x,_followBounds.y),
                                              _normalCameraY + (_target.transform.position.y - _normalPlayerY) * _cameraUpAmplitude,
                                              -100);
            // _normalZ  - (_target.position.y - _normalPlayerY)*_removalRate
            GetComponent<Camera>().orthographicSize = _normalSize + (_target.position.y - _normalPlayerY) * _removalRate;
            ResizeBackground();
	    }
	}

    public void StartFollow()
    {
        _isStart = true;
        _deltaX = transform.position.x - _target.position.x;
        _normalPlayerY = _target.position.y;
        _normalSize = GetComponent<Camera>().orthographicSize;
        _backgroundNormalSize = _background.transform.localScale;
    }

    private void ResizeBackground()
    {
        var special_coof = 0.0775f / 0.4f;
        _background.transform.localScale = _backgroundNormalSize + _backgroundNormalSize * (_target.position.y - _normalPlayerY) * special_coof * _removalRate;
    }
}
