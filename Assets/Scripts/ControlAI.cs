using UnityEngine;
using System.Collections;

public class ControlAI : MonoBehaviour {
	public float maxSpeed = 3.5f;
	public int side = 1;

	private Animator anim;
	private AI ai;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		ai = GetComponent<AI>();
		transform.localScale = new Vector3(side, 1, 1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (ai.isAlive()) {
			anim.SetBool("Walk", true);
			rigidbody2D.velocity = new Vector2(side * maxSpeed, 0);
		}
	}
}
