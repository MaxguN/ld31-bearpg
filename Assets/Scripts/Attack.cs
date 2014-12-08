using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public float punchDamage = 10;
	public float kickDamage = 20; 

	private ArrayList punching;
	private ArrayList kicking;
	private ArrayList superPunching;
	private ArrayList superKicking;
	private ArrayList ultraKicking;

	private Beardman beardman;

	// Use this for initialization
	void Awake () {
		beardman = GetComponent<Beardman>();
	}

	void Start() {
		punching = new ArrayList();
		kicking = new ArrayList();
		superPunching = new ArrayList();
		superKicking = new ArrayList();
		ultraKicking = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void punch() {
		if (punching.Count > 0) {
			((GameObject) punching[0]).GetComponent<Health>().hit(punchDamage, this);
		}
	}

	public void kick() {
		if (kicking.Count > 0) {
			((GameObject) kicking[0]).GetComponent<Health>().hit(kickDamage, this);
		}
	}

	public void superPunch() {
		foreach (GameObject target in superPunching) {
			target.GetComponent<Health>().hit(punchDamage, this);
		}
	}

	public void superKick() {
		foreach (Collider2D target in superKicking) {
			target.GetComponent<Health>().hit(kickDamage, this);
		}
	}

	public void ultraKick() {
		foreach (GameObject target in ultraKicking) {
			target.GetComponent<Health>().hit(kickDamage, this);
		}
	}

	public void kill(GameObject corpse, float hp, float energy, float xp) {
		punching.Remove(corpse);
		kicking.Remove(corpse);
		superPunching.Remove(corpse);
		superKicking.Remove(corpse);
		ultraKicking.Remove(corpse);

		if (beardman) {
			beardman.kill(hp, energy, xp);
		}
	}

	public void punchEnter(Collider2D target) {
		punching.Add(target.gameObject);
	}

	public void punchLeave(Collider2D target) {
		punching.Remove(target.gameObject);
	}

	public void kickEnter(Collider2D target) {
		kicking.Add(target.gameObject);
	}

	public void kickLeave(Collider2D target) {
		kicking.Remove(target.gameObject);
	}

	public void superPunchEnter(Collider2D target) {
		superPunching.Add(target.gameObject);
	}

	public void superPunchLeave(Collider2D target) {
		superPunching.Remove(target.gameObject);
	}

	public void superKickEnter(Collider2D target) {
		superKicking.Add(target.gameObject);
	}

	public void superKickLeave(Collider2D target) {
		superKicking.Remove(target.gameObject);
	}

	public void ultraKickEnter(Collider2D target) {
		ultraKicking.Add(target.gameObject);
	}

	public void ultraKickLeave(Collider2D target) {
		ultraKicking.Remove(target.gameObject);
	}
}
