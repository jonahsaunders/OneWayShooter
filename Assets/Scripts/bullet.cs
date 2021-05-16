using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
	public float speed;
	void Update () 
	{
		transform.Translate (Vector3.up * Time.deltaTime * speed);
	}
	void Start()
	{
		Destroy (this.gameObject, 5);
	}
}
