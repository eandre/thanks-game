using UnityEngine;
using System.Collections;

public class MissileScript : MonoBehaviour {
	// Inspector configuration
	[SerializeField] private float speed;    // Speed at which the missile moves (units/sec)
	[SerializeField] private float duration; // Duration of time before the missile explodes without colliding

	// Private member variables
	private float lifetime; // Lifetime of missile until it self-explodes

	void Start() {
		lifetime = duration;
	}

	// Update runs every frame
	void Update () {
		float dist = speed * Time.deltaTime;

		// Always move straight along the Y axis in local space,
		// since the rotation will take care of moving us in the
		// right direction in world space
		transform.Translate (0, dist, 0, Space.Self);
	}

	// FixedUpdate runs every physics update
	void FixedUpdate() {
		lifetime -= Time.fixedDeltaTime;
		if (lifetime <= 0) {
			Explode ();
		}
	}

	// Explode triggers the missile explosion
	private void Explode() {
		// Just destroy it for now; we'll add explosion effects later
		Destroy (gameObject);
	}
}
