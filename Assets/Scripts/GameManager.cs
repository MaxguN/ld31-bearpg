using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private Transform startscreen;
	private Transform endscreen;
	private Transform directions;

	private string state;

	// Use this for initialization
	void Awake() {
		startscreen = GameObject.FindWithTag("Startscreen").transform;
		endscreen = GameObject.FindWithTag("Gameover").transform;
		directions = GameObject.FindWithTag("Directions").transform;
	}

	void Start () {
		state = "start";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit")) {
			if (state == "start") {// || state == "end") {
				startscreen.renderer.enabled = false;
				state = "game";
			}
		}
	}

	public bool isRunning() {
		return state == "game";
	}

	public void gameover() {
		endscreen.renderer.enabled = true;
		state = "end";
	}
}
