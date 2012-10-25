using UnityEngine;
using System.Collections;

public class ScorePickup : MonoBehaviour {
	public int scoreValue = 5;
	
	void OnTriggerEnter(Collider collision) {
		if(collision.transform.CompareTag("Player")) {
			collision.gameObject.SendMessage("addScore", scoreValue);
			Destroy(gameObject);
		}		
	}
}
