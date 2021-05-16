using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour 
{
	public int currentScore;
	public static int highScore;

	public float speed;

	public GameObject bullet;
	public GameObject bulletSpot;

	public bool insideRight;
	public bool insideLeft;

	public Text highscoreText;
	public Text currentscoreText;

	public bool isableRight;
	public bool isableLeft;

	public GameObject enemy;

	public GameObject start;

	public GameObject Background;

	public GameObject left;
	public GameObject right;

	public int startDirection;

	public GameObject enemyStart;


	public AudioClip boomSound;
	private AudioSource thisaudioObject;
	void Start()
	{
		thisaudioObject = GetComponent<AudioSource> ();
		Background.SetActive (true);
		highScore = PlayerPrefs.GetInt ("highscore", highScore);
	}
	public void StartGame ()
	{
		enemy.transform.position = enemyStart.transform.position;
		startDirection = Random.Range (1, 3);
		if (startDirection == 1)
		{
			isableLeft = true;
			isableRight = false;
		}
		if (startDirection == 2)
		{
			isableRight = true;
			isableLeft = false;
		}
		enemy.GetComponent<ENEMY> ().gameStarted = true;
		Background.SetActive (false);
		currentScore = 0;
	}
	public void Shoot()
	{
		GameObject newBullet = Instantiate (bullet) as GameObject;
		newBullet.transform.position = bulletSpot.transform.position;
	}
	public void rightInside()
	{
		if (!(isableRight)) 
		{
			insideRight = true;
		}
	}
	public void leftInside()
	{
		if (!(isableLeft)) 
		{
			insideLeft = true;
		}
	}
	public void leftOutside()
	{
		insideLeft = false;
	}
	public void rightOutside()
	{
		insideRight = false;
	}
	void Update () 
	{
		highscoreText.text = highScore.ToString ();
		currentscoreText.text = currentScore.ToString ();
		
		if (currentScore > highScore) 
		{
			highScore = currentScore;
			PlayerPrefs.SetInt ("highscore", highScore);
		}
		if (insideRight)
		{
			if (!(isableRight))
			{
				transform.Translate (Vector3.right * Time.deltaTime * speed);
			}
		}
		if (insideLeft) 
		{
			if (!(isableLeft))
			{
				transform.Translate (Vector3.left * Time.deltaTime * speed);
			}
		}
		if (isableLeft) 
		{
			left.SetActive (false);
		} 
		else 
		{
			left.SetActive (true);
		}
		if (isableRight) 
		{
			right.SetActive (false);
		} 
		else 
		{
			right.SetActive (true);
		}
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "enemybullet")
		{
			thisaudioObject.PlayOneShot(boomSound);
			this.gameObject.transform.position = start.transform.position;
			insideRight = false;
			insideLeft = false;
			currentScore = 0;
			enemy.GetComponent<ENEMY> ().gameStarted = false;
			Background.SetActive (true);
		}
	}
}
