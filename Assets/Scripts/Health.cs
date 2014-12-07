using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float hitPoints = 100;

	private Animator anim;
	private Beardman beardman;
	private AI ai;

	private float health;

	void Awake () {
		health = hitPoints;
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		beardman = GetComponent<Beardman>();
		ai = GetComponent<AI>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getHealth() {
		return health;
	}

	public float getMaxHealth() {
		return hitPoints;
	}

	public void hit(float damage, Attack hitter) {
		health -= damage;

		if (beardman) {
			beardman.updateHealth(health);
		}

		if (health <= 0) {
			hitter.kill();
			kill();
		}
	}

	private void kill() {
		anim.SetTrigger("KO");

		if (ai) {
			ai.die();
		} else if (beardman) {
			beardman.die();
		}
	}
}
