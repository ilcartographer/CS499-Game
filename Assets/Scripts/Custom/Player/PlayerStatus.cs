using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	
	public int currentHealth = 100;
	public int currentScore  = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void doDamage(int damageToDeal) {
		currentHealth -= damageToDeal;	
		if(currentHealth < 0)
			currentHealth = 0;
	}
}
