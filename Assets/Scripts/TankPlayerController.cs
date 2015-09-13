using UnityEngine;
using System.Collections;

// TankPlayerController allows the player to control
// a tank's movement, passing on input to the TankScript.
[RequireComponent(typeof(TankScript))]
public class TankPlayerController : MonoBehaviour {
	// Script that actually carries out the tank movement
	private TankScript tankScript;

	void Start() {
		// Get reference to our tank script
		tankScript = GetComponent<TankScript> ();
	}

	void Update() {
		// Use horizontal input to set turn speed
		float x = Input.GetAxis ("Horizontal");
		tankScript.SetTurnSpeed (x);

		// Use vertical input to set forward/backward speed
		float y = Input.GetAxis ("Vertical");
		tankScript.SetSpeed (y);

		// If we pressed the fire button, fire!
		if (Input.GetButtonDown ("Fire1")) {
			tankScript.Fire ();
		}
	}
}
