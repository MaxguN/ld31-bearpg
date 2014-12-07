using UnityEngine;
using System.Collections;

public class Conveyor : MonoBehaviour {
	private float maxSpeed = 5f;
	public float side = 1f;

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D corpse) {
		Debug.Log(corpse);
	}
}
