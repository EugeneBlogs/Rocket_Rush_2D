using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Объект вошёл в зону триггера.");
        Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(new Vector3(500f, 0, 0));
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Объект в зоне триггера.");
    }
}
