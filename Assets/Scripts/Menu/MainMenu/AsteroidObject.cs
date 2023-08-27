using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class AsteroidObject : MonoBehaviour {

    public static int Count;

    [SerializeField] float _liveDistance = 10f;
    [SerializeField] float _forseScale = 100f;

    [SerializeField] Vector2 _firstPowerRange;
    Rigidbody2D _rig;
    bool _isMoving;
    Vector3 _lastPosition = Vector3.zero;

    private void Start()
    {
        ++Count;
        _rig = GetComponent<Rigidbody2D>();
        AddFirstForse();
    }

    void AddFirstForse()
    {
        var f = Random.Range(_firstPowerRange.x, _firstPowerRange.y);
        _rig.AddForce(transform.position * -f);
    }

    void Update () {
        CheckLive();
	}

    private void FixedUpdate()
    {
        if (_isMoving)
            CheckMove();
    }

    void CheckLive()
    {
        if (transform.localPosition.magnitude > _liveDistance)
        {
            --Count;
            Destroy(gameObject);
        }
    }

    void CheckMove()
    {
        var pos = Input.mousePosition;
        pos = Camera.main.ScreenToWorldPoint(pos);

        if(_lastPosition!=Vector3.zero)
            _rig.velocity = ((pos-transform.localPosition)*Time.fixedDeltaTime*_forseScale);

        _lastPosition = pos;
    }

    private void OnMouseDown()
    {
        _isMoving = true;
        _rig.velocity = Vector3.one*0.1f;
        _lastPosition = Vector3.zero;
    }

    private void OnMouseUp()
    {
        _isMoving = false;
    }
}
