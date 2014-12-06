using UnityEngine;
using System.Collections;

public class ControlBeardman : MonoBehaviour {
	public float maxSpeed = 7f;

	private Animator anim;
	private Attack attack;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		attack = GetComponent<Attack>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			anim.SetTrigger("Punch");
			attack.punch();
		} else if (Input.GetButtonDown("Fire2")) {
			anim.SetTrigger("Kick");
			attack.kick();
		}
	}

	void FixedUpdate() {
		float h = Input.GetAxis("Horizontal");
		AnimatorStateInfo asi = anim.GetCurrentAnimatorStateInfo(0);

		if (h == 0 || asi.IsName("Base.Punch") || asi.IsName("Base.Kick")) {
			anim.SetBool("Run", false);
			rigidbody2D.velocity = new Vector2(0, 0);
		} else {
			anim.SetBool("Run", true);
			rigidbody2D.velocity = new Vector2(Mathf.Sign(h) * maxSpeed, 0);
			
			if (h > 0) {
				transform.localScale = new Vector3(1, 1, 1);
			} else {
				transform.localScale = new Vector3(-1, 1, 1);
			}
		}
	}
}
