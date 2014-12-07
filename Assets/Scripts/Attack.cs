using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {
	public float punchDamage = 10;
	public float kickDamage = 20; 

	private Collider2D punching;
	private Collider2D kicking;

	private Beardman beardman;

	// Use this for initialization
	void Awake () {
		beardman = GetComponent<Beardman>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void punch() {
		if (punching) {
			punching.GetComponent<Health>().hit(punchDamage, this);
		}
	}

	public void kick() {
		if (kicking) {
			kicking.GetComponent<Health>().hit(kickDamage, this);
		}
	}

	public void kill() {
		punching = null;
		kicking = null;

		if (beardman) {
			beardman.kill();
		}
	}

	public void punchEnter(Collider2D target) {
		punching = target;
	}

	public void punchLeave() {
		punching = null;
	}

	public void kickEnter(Collider2D target) {
		kicking = target;
	}

	public void kickLeave() {
		kicking = null;
	}
}
