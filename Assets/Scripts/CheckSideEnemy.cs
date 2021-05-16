using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckSideEnemy : MonoBehaviour 
{
		public bool isrightWall;
		public GameObject enemyObj;

		void OnTriggerEnter(Collider other)
		{
			if(other.gameObject.tag == "wall")
			{
				Debug.Log ("hit wall");
				if (isrightWall) 
				{
					enemyObj.GetComponent<ENEMY> ().isableRight = false;
				} 
				else 
				{
					enemyObj.GetComponent<ENEMY> ().isableRight = true;	
				}
				if (!(isrightWall)) 
				{
					enemyObj.GetComponent<ENEMY> ().isableLeft = false;
				} 
				else 
				{
					enemyObj.GetComponent<ENEMY> ().isableLeft = true;
				}
			}
		}
		void OnTriggerExit (Collider other)
		{
			if (other.gameObject.tag == "wall") 
			{
				if (isrightWall) 
				{
					enemyObj.GetComponent<ENEMY> ().isableRight = false;	
				}
				if (!(isrightWall)) 
				{
					enemyObj.GetComponent<ENEMY> ().isableLeft = false;
				}
			}
		}
}
