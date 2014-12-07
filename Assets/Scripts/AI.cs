using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
	private bool alive;

	// Use this for initialization
	void Start () {
		alive = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool isAlive() {
		return alive;
	}

	public void kill() {
		alive = false;
	}
}
