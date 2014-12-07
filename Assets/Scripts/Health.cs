using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float hitPoints = 100;

	private Animator anim;
	private Beardman beardman;
	private AI ai;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		beardman = GetComponent<Beardman>();
		ai = GetComponent<AI>();
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
		anim.SetTrigger("KO");

		if (ai) {
			ai.kill();
		} else if (beardman) {
			beardman.kill();
		}
	}
}
