using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class FireTriggerScript : MonoBehaviour {
	// Inspector configuration
	[SerializeField] private GameObject missilePrefab; // Prefab of missile to fire

	// Cached components
	Animator animator;

	// Start is called at initialization
	void Start() {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Fire() {
		// Create a new missile based on the prefab
		GameObject missile = Instantiate (missilePrefab);
		
		// Copy the position and rotation from our tank
		missile.transform.rotation = transform.rotation;
		missile.transform.position = transform.position;
		
		// Trigger the 'Fire' animation
		Debug.Log ("Firing!");
		animator.SetTrigger ("Fire");
	}
}
