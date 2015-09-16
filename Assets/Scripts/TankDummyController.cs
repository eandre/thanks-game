using UnityEngine;
using System.Collections;

// TankDummyController is a dummy controller that simply
// runs the tank in a circle.
[RequireComponent(typeof(TankScript))]
public class TankDummyController : MonoBehaviour {
	// Script that actually carries out the tank movement
	private TankScript tankScript;
	
	[SerializeField] private float fireFrequency; // How frequently the tank fires, in seconds
	private float fireCooldown;

	// Start is called on initialization
	void Start() {
		// Get reference to our tank script
		tankScript = GetComponent<TankScript> ();

		// Start out with the firing on cooldown
		fireCooldown = fireFrequency;

		// Make the tank turn right all the time
		tankScript.SetTurnSpeed (1);
		tankScript.SetSpeed (1);
	}

	// Update runs every frame
	void Update() {
		// Fire a bullet if we've waited for the duration of the cooldown
		fireCooldown -= Time.deltaTime;
		if (fireCooldown <= 0) {
			fireCooldown += fireFrequency;
			tankScript.Fire ();
		}
	}
}
