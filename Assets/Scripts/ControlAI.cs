using UnityEngine;
using System.Collections;

public class ControlAI : MonoBehaviour {
	public float maxSpeed = 3.5f;
	public int side = 1;

	private GameManager gm;
	private Animator anim;
	private Attack attack;
	private AI ai;
	private Transform beardman;

	private bool punch = false;
	private float timer = 0;

	// Use this for initialization
	void Awake () {
		gm = GameObject.FindWithTag("Scripts").GetComponent<GameManager>();
		anim = GetComponent<Animator>();
		attack = GetComponent<Attack>();
		ai = GetComponent<AI>();
		beardman = GameObject.FindWithTag("Player").transform;

		setSide(side);
	}

	void Update() {
		if (gm.isRunning()) {
			if (ai.isAlive()) {
				float distance = transform.position.x - beardman.position.x;

				setSide((int) -Mathf.Sign(distance));

				if (!punch) {
					if (Mathf.Abs(distance) <= 0.45f) {
						timer = 0.25f;
						punch = true;
					}
				} else {
					if (timer <= 0) {
						punch = false;
						anim.SetTrigger("Punch");
						attack.punch();
					}
					
					timer -= Time.deltaTime;
				}
			} else {
				punch = false;
			}
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gm.isRunning()) {
			AnimatorStateInfo asi = anim.GetCurrentAnimatorStateInfo(0);

			if (asi.IsName("Base.Punch") || punch) {
				anim.SetBool("Walk", false);
				rigidbody2D.velocity = new Vector2(0, 0);
			} else {
				if (ai.isAlive()) {
					anim.SetBool("Walk", true);
					rigidbody2D.velocity = new Vector2(side * maxSpeed, 0);
				} else if (ai.isConveyed()) {
					rigidbody2D.velocity = new Vector2(side * maxSpeed, 0);
				}
			}
		}
	}

	public void setSide(int value) {
		side = value;
		transform.localScale = new Vector3(side, 1, 1);
	}
}
