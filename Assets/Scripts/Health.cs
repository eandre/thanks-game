using UnityEngine;
using System.Collections;

// Health tracks the health of a game object,
// and notifies listeners upon taking damage or on death.
public class Health : MonoBehaviour {
	public delegate void OnDamageTaken(int health, int damage);

	[SerializeField] private int max;         // Maximum health of the object
	private int current;                      // Current health of the object
	public OnDamageTaken DamageTakenListener; // Delegate listeners for when this game object takes damage

	// TakeDamage reduces the health of the game object, and notifies any listeners
	// of the damage taken.
	public void TakeDamage(int damage) {
		// If we're already dead, don't do anything
		if (current <= 0) {
			return;
		}

		// Reduce health by damage amount
		current -= damage;
		if (current < 0) {
			current = 0;
		}

		// Notify our listeners
		if (DamageTakenListener != null) {
			DamageTakenListener(current, damage);
		}
	}

	// Start is called on initialization
	void Start () {
		// Objects start out at their max health
		current = max;
	}
}
