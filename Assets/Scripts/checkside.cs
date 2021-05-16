using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkside : MonoBehaviour 
{
	public bool isrightWall;


	public GameObject player;
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "wall")
		{
			Debug.Log ("hit wall");
			if (isrightWall) 
			{
				player.GetComponent<Movement> ().isableRight = false;
			} 
			else 
			{
				player.GetComponent<Movement> ().isableRight = true;	
			}
			if (!(isrightWall)) 
			{
				player.GetComponent<Movement> ().isableLeft = false;
			} 
			else 
			{
				player.GetComponent<Movement> ().isableLeft = true;
			}
		}
	}
	void OnTriggerExit (Collider other)
	{
		if (other.gameObject.tag == "wall") 
		{
			if (isrightWall) 
			{
				player.GetComponent<Movement> ().isableRight = false;	
			}
			if (!(isrightWall)) 
			{
				player.GetComponent<Movement> ().isableLeft = false;
			}
		}
	}
}
