using UnityEngine;
using System.Collections;

public class Punch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D target) {
		transform.parent.GetComponent<Attack>().punchEnter(target);
	}

	void OnTriggerExit2D(Collider2D target) {
		transform.parent.GetComponent<Attack>().punchLeave();
	}
}
