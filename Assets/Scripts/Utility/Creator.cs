using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Creator : MonoBehaviour
{
	public GameObject _sample;
	public Transform _startPos;
	public Transform _endPos;
	public Vector2 _offset;
	public string _tagReplaceObj = "Barrel";
	public float _offsetChain;
	public int _cnt;

	
    public void Create()
    {
#if UNITY_EDITOR
        GameObject temp = new GameObject();
		temp.name = "Build" + transform.childCount.ToString();
		temp.transform.parent = transform;

        for(int i = 0; i < _cnt; i++)
        {
            var pref = PrefabUtility.InstantiatePrefab(_sample  ) as GameObject;
            pref.transform.position = (Vector2)_startPos.position + _offset * i;
            pref.transform.parent = temp.transform;
        }
#endif	
    }


	public void ReplaceObj()
	{
		Transform[] tr = GetComponentsInChildren<Transform>();

		for (int i = 0; i < tr.Length; i++)
		{
			Transform t = tr[i];

			if (t.gameObject.tag == _tagReplaceObj)
			{
				Instantiate(_sample, t.position, t.rotation, t.parent);
				DestroyImmediate(t.gameObject);
			}
		}
	}


	public void CreateChain()
	{
		if (!_sample || !_sample.GetComponent<HingeJoint2D>())
		{
			Debug.LogError("Не выбран объект Sample или у него нет компотнета HingeJoint2D");
			return;
		}

		Rigidbody2D previousRb = null;
		GameObject temp = new GameObject("Chain" + transform.childCount.ToString());
		int count = (int)(Vector3.Distance(_startPos.position, _endPos.position) / Mathf.Abs(_offsetChain)) + 1;
		temp.transform.parent = transform;
		temp.transform.localPosition = Vector2.zero;

		for (int i = 0; i < count; i++)
		{
			Rigidbody2D rb;
			Vector3 pos = temp.transform.position + (new Vector3(0f, _offsetChain) * i);
			rb = Instantiate(_sample, pos, Quaternion.identity, temp.transform).GetComponent<Rigidbody2D>();

			if (i == 0 || i == count - 1)
				rb.bodyType = RigidbodyType2D.Static;
			if(i != 0)
				rb.GetComponent<HingeJoint2D>().connectedBody = previousRb;

			previousRb = rb;
		}

		Vector2 dir = _endPos.position - _startPos.position;
		temp.transform.position = _startPos.position;
		temp.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(dir.y, dir.x) * 180f / 3.14f + 90f);
	}
}
