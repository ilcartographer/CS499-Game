using UnityEngine;
using System.Collections;

public class WalkingEnemy : MonoBehaviour {
	public GameObject player;
	public float speed = 4;
	
	void Update() {
		transform.LookAt(player.transform);
		transform.Translate(Vector3.forward * Time.deltaTime);
	}
}
