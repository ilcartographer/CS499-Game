using UnityEngine;
using System.Collections;

public class UpdateGUI : MonoBehaviour {
	public GUIText playerHealth;
	public GUIText playerScore;
	public GUIText locationText;
	
	
	public PlayerStatus player_status; 
	
	public CharacterController player_controller;
	
	// GOs in the scene that mark the start and end
	public StartPoint start;
	public EndPoint end;
	
	// x locations of the start and end
	private float startX;
	private float endX;
	
	void OnEnable() {
		startX = start.transform.position.x;
		endX = end.transform.position.x;
	}
	
	void OnGUI () {
		// Update player health & score
		playerHealth.text = "Health: " + player_status.currentHealth;
		playerScore.text = "Score: " + player_status.currentScore;
		
		// Move the location text's position based on where the player is
		// Keep in bounds, leave some padding
		float currentX = player_controller.transform.position.x;
		float percentage = Mathf.Clamp((float)(currentX - startX) / (float)(endX - startX), 0.05f, 0.95f);
		locationText.transform.position = new Vector3(percentage,
									locationText.transform.position.y,
									locationText.transform.position.z);
			
	}
}
