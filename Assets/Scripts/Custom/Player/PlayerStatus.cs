using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public static readonly int START_HEALTH = 100;
	public readonly int MAX_HEALTH = 200;
	
	int currentHealth = START_HEALTH;
	int currentScore  = 0;
	
	void Update () {
		// Player will "swell up" as he gets low
		// Max scale is 1.5x (tenative)
		if(currentHealth < START_HEALTH) {
			float playerScale = 1.0f + ((100.0f - (float)currentHealth) / ((float)START_HEALTH * 2.0f));
			transform.localScale = new Vector3(playerScale, playerScale, playerScale);
		}
	}
	
	public int getHealth() {
		return currentHealth;
	}
	
	public int getScore() {
		return currentScore;
	}
	
	public void healPlayer(int healthToGive) {
		currentHealth += healthToGive;
		if(currentHealth > MAX_HEALTH)
			currentHealth = MAX_HEALTH;		
	}
	
	public void doDamage(int damageToDeal) {
		currentHealth -= damageToDeal;	
		if(currentHealth < 0)
			currentHealth = 0;
	}
	
	public void addScore(int scoreToAdd) {
		currentScore += scoreToAdd;
	}
}
