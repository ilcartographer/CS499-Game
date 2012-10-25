using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {
	public float rotationSpeed = 240.0f;
	
	// Making public allows this to be attached to larger/smaller health packs
	public int healthValue = 20;
	public int scoreValue = 10;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.World);
	}
	
	void OnTriggerEnter(Collider collision) {
		if(collision.transform.CompareTag("Player")) {
			collision.gameObject.SendMessage("healPlayer", healthValue);
			collision.gameObject.SendMessage("addScore", scoreValue);
			
			Destroy(gameObject);
		}		
	}
}
