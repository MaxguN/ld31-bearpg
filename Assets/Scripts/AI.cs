using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	private ControlAI control;
	private bool alive;
	private bool conveyed;

	// Use this for initialization
	void Awake() {
		control = GetComponent<ControlAI>();
		alive = true;
		conveyed = false;
	}
	
	// Update is called once per frame
	void Update() {
	}

	public bool isAlive() {
		return alive;
	}

	public bool isConveyed() {
		return conveyed;
	}

	public void die() {
		alive = false;
		collider2D.isTrigger = true;
	}

	private void conveyLeft() {
		collider2D.isTrigger = false;
		conveyed = true;
		control.side = -1;
	}

	private void conveyRight() {
		collider2D.isTrigger = false;
		conveyed = true;
		control.side = 1;
	}

	void OnTriggerEnter2D(Collider2D floor) {
		if (floor.name == "Left conveyor") {
			conveyLeft();
		} else if (floor.name == "Right conveyor") {
			conveyRight();
		}
	}
}
