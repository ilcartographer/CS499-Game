using UnityEngine;

using System.Collections;

public class PlayerStatus : MonoBehaviour {
	public static readonly int START_HEALTH = 100;
	public readonly int MAX_HEALTH = 200;
	
	int currentHealth = START_HEALTH;
	int currentScore  = 0;
	bool isDying = false;
	
	public AnimationClip deathAnimation;
	
	void Start() {
		animation.AddClip(deathAnimation, "player_death");	
	}
	
	void Update () {
		// Player will "swell up" as he gets low
		// Max scale is 1.5x (tenative)
		if(!isDying) {
			if(currentHealth < START_HEALTH) {
				float playerScale = 1.0f + (((float)START_HEALTH - (float)currentHealth) / ((float)START_HEALTH /** 2.0f*/));
				transform.localScale = new Vector3(playerScale, playerScale, playerScale);
				
			}
			if(currentHealth <= 0) {
				isDying = true;
				gameObject.SendMessage ("SetControllable", false);
				GameObject.Find("Muzzle").SendMessage ("DisableFire", false);
				animation.Play("player_death");
			}
		}
		
		if(isDying) {
			if(!animation.IsPlaying("player_death")) {
				Application.LoadLevel("GameOverScreen");
			} else {
				Vector3 rotationVector = new Vector3(1.0f * Time.time, 0.0f, 0.0f);
				gameObject.transform.Rotate(rotationVector);	
			}
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
