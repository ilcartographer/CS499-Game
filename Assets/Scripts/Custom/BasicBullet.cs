using UnityEngine;
using System.Collections;

public class BasicBullet : MonoBehaviour {
	public float speed = .1f;
	public Vector3 direction = new Vector3(1, 0, 0);
	public float lifeSpan = 2.0f;
	public float maxDistance = 10.0f;
	public int damage = 10;
	
	private Transform bullet;
	private float spawnTime;
	private float currentDistanceTravelled = 0.0f; 
	private bool hasHitPlayer = false;
	
	void OnEnable() {
		bullet = transform;
		spawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		// move the bullet in the specified direction by the total
		// distance (speed * time)
		currentDistanceTravelled += speed;
		bullet.Translate(direction * speed * Time.deltaTime);
		
		if(Time.time >= lifeSpan + spawnTime) {
			Destroy(gameObject);	
		}
	}
	
	void OnTriggerEnter(Collider collision) {
		BulletCollide(collision);
	}
	
	void OnTriggerStay(Collider collision) {
		BulletCollide(collision);
	}
	
	void BulletCollide(Collider collision) {
		// If the collision is with the player, inform the player script
		// with how much damage to deal
		if(collision.transform.CompareTag("Player") && !hasHitPlayer) {
			collision.gameObject.SendMessage("doDamage", damage);
			hasHitPlayer = true;
			
		}
		
		Destroy(gameObject);
	}
	
	void PlayerCollision(GameObject player) {
		player.SendMessage ("doDamage", damage);
		hasHitPlayer = true;
	}
	
	
}
