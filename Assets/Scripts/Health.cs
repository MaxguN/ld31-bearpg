using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float hitPoints = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void hit(float damage, Attack hitter) {
		hitPoints -= damage;

		if (hitPoints <= 0) {
			hitter.kill();
			kill();
		}
	}

	private void kill() {
		Destroy(gameObject);
	}
}
