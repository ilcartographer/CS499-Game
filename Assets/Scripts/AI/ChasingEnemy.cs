using UnityEngine;
using System.Collections;

public class ChasingEnemy : MonoBehaviour {
	Transform playerModel;
	Transform currentEnemy;
	
	float moveSpeed = 2.0f;
	float rotationSpeed = 3.0f;
	
	void Awake() {
		currentEnemy = transform;	
	}
		
	
	// Use this for initialization
	void Start () {
		playerModel = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {	
		Vector3 directionToMove = new Vector3(0, 0, 0);
		
		if(playerModel.position.x - currentEnemy.position.x > 5) {
			directionToMove = new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
		} else if(playerModel.position.x - currentEnemy.position.x < -5) {
			directionToMove = new Vector3(-1 * moveSpeed * Time.deltaTime, 0f, 0f);
		}
		
		currentEnemy.Translate(directionToMove, null);
	}
}
