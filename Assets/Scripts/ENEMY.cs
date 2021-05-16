using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour 
{
	public GameObject ship;

	public bool gameStarted;

	public float waitTime;
	public float maxWait;
	public float minWait;

	public int movement;
	// 1 is to right
	//2 is to left
	//3 is stay in position
	public float speed;

	public GameObject bullet;
	public GameObject bulletSpot;

	public bool isableRight;
	public bool isableLeft;

	public float movementWait;

	public AudioClip shotSound;
	private AudioSource thisaudioObject;
	void Start ()
	{
		thisaudioObject = GetComponent<AudioSource> ();
		isableLeft = true;
		isableRight = true;
		StartCoroutine("Game");
		StartCoroutine("Movement");
	}
	IEnumerator Game()
	{
		if (gameStarted) 
		{
			thisaudioObject.PlayOneShot(shotSound);
			GameObject enemyBullet = Instantiate (bullet) as GameObject;
			enemyBullet.transform.position = bulletSpot.transform.position;
		}
		waitTime = Random.Range (minWait, maxWait);
		yield return new WaitForSeconds(waitTime);
		StartCoroutine("Game");
	}
	IEnumerator Movement()
	{
		if (gameStarted) 
		{
			movement = Random.Range (0, 3);
		}
		movementWait = Random.Range (0, 2);
		yield return new WaitForSeconds(movementWait);
		StartCoroutine("Movement");
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "bullet")
		{
			Debug.Log ("hit");
			ship.GetComponent<Movement> ().currentScore += 1;
			Debug.Log ("hit transfer");
		}
	}
	void Update()
	{
		if (movement == 1 && (isableRight)) 
		{
			transform.Translate (Vector3.right * Time.deltaTime * speed);
		}
		if (movement == 2 && (isableLeft)) 
		{
			transform.Translate (Vector3.left * Time.deltaTime * speed);
		}
	}
}
