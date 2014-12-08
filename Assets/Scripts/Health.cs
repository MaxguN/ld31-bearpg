using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float hitPoints = 100;
	public float rewardHealth = 2;
	public float rewardEnergy = 10;
	public float rewardExperience = 1000;

	private Animator anim;
	private Beardman beardman;
	private AI ai;

	private float health;
	private float baseHealth;

	void Awake () {
		health = hitPoints;
		baseHealth = hitPoints;
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

	public void gainHealth(float hp) {
		health += hp;

		if (health > hitPoints) {
			health = hitPoints;
		}

		if (beardman) {
			beardman.updateHealth(health);
		}
	}

	public void increaseHealth() {
		hitPoints += baseHealth;
		health += baseHealth;

		beardman.updateHealth(health);
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
			hitter.kill(gameObject, rewardHealth, rewardEnergy, rewardExperience);
			die();
		}
	}

	private void die() {
		anim.SetTrigger("KO");

		if (ai) {
			ai.die();
		} else if (beardman) {
			beardman.die();
		}
	}
}
