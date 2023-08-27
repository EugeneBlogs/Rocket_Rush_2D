using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketList : MonoBehaviour {


    [SerializeField]
    List<RocketModel> _rockets;

    [SerializeField]
    ShopCard _sample;

    [SerializeField] RectTransform container;

    [SerializeField] Vector2 offset;

    RectTransform _sampleRect;
    Vector2 _startPosition = Vector3.zero;
    int _index = 0;

    private void Awake()
    {
        _sampleRect = _sample.GetComponent<RectTransform>();
        _startPosition = _sampleRect.offsetMin;
        offset.x *= _sampleRect.offsetMax.x - _sampleRect.offsetMin.x;
        container.offsetMax = new Vector2(container.offsetMin.x + offset.x * _rockets.Count, container.offsetMax.y);
    }

    void Start () {
		foreach(var r in _rockets)
        {
            ApplyRocket(r);
        }
	}

    void ApplyRocket(RocketModel rocket)
    {
        var element = Instantiate(_sample, container) as ShopCard;
        element.parameters = rocket;
        element.index = _index++;
        ApplyTransform(element.GetComponent<RectTransform>());
    }

    void ApplyTransform(RectTransform element)
    {
        element.offsetMin = _startPosition;
        element.offsetMax = _startPosition + new Vector2(_sampleRect.rect.width, _sampleRect.rect.height);
        _startPosition += offset;
    }
	
	
}
