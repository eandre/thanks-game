using UnityEngine;
using System.Collections;

// TankScript enforces the tank-like behavior of the object,
// exposing an interface to the controller script that allows
// the player or AI to control the tank, without breaking the
// game rules of how a tank should move, and abstracting away
// from how the controlling is done (key bindings etc).
public class TankScript : MonoBehaviour {
	// Inspector configuration
	[SerializeField] private float maxSpeed;           // The maximum forward/backward speed in units/second
	[SerializeField] private float maxTurn;            // The maximum right/left turning speed in degrees/second

	// Cached components
	FireTriggerScript fireTrigger;

	void Start() {
		fireTrigger = GetComponentInChildren<FireTriggerScript> ();
	}

	// Private member variables
	private float speed;     // Current forward/backward speed (between -1 and 1)
	private float turnSpeed; // Current left/right turning speed (between -1 and 1)

	// Update is called every frame
	void Update () {
		// Compute distance we moved since last frame
		float dist = speed * maxSpeed * Time.deltaTime;

		// Perform translation in local space so we move in line with our rotation
		transform.Translate (0, dist, 0, Space.Self);

		// Compute angle we rotated since last frame (inverted since we want left to be a positive angle)
		float angle = -turnSpeed * maxTurn * Time.deltaTime;

		// Perform the rotation around the Z axis
		transform.Rotate (0, 0, angle);
	}

	// SetSpeed controls the forward/backward speed of the tank,
	// as a percentage of maximum speed (from -1 to 1).
	// Negative values indicate reversing.
	public void SetSpeed(float speed) {
		// Only allow values in the range of -1 to 1
		this.speed = Mathf.Clamp (speed, -1, 1);
	}

	// SetTurnSpeed controls the right/left turning speed of the tank,
	// as a percentage of maximum turning speed (from -1 to 1).
	// Negative values indicate turning left.
	public void SetTurnSpeed(float turnSpeed) {
		// Only allow values in the range of -1 to 1
		this.turnSpeed = Mathf.Clamp (turnSpeed, -1, 1);
	}

	// Fire fires a missile from the barrel
	public void Fire() {
		// Simply forward this call to our fire trigger
		fireTrigger.Fire ();
	}
}
