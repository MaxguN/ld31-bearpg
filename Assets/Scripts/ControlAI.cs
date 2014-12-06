using UnityEngine;
using System.Collections;

public class ControlAI : MonoBehaviour {
	public float maxSpeed = 3.5f;
	public int side = 1;

	private Animator anim;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		transform.localScale = new Vector3(side, 1, 1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		anim.SetBool("Walk", true);
		rigidbody2D.velocity = new Vector2(side * maxSpeed, 0);
	}
}
