using UnityEngine;
using System.Collections;

public class FlyerEnemy : MonoBehaviour {
	bool hasBeenSeen = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnBecameVisible() {
		hasBeenSeen = true;	
	}
	
	void OnBecameInvisible() {
		if(hasBeenSeen)
			Destroy (gameObject);	
	}
}
