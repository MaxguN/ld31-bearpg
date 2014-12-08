using UnityEngine;
using System.Collections;

public class ControlBeardman : MonoBehaviour {
	public float maxSpeed = 7f;
	public float comboTimeout = 0.25f;

	private GameManager gm;
	private Animator anim;
	private Attack attack;

	private bool superPunch = false;
	private bool superKick = false;
	private bool ultraKick = false;

	private float timer = 0f;
	private bool actionCombo = false;
	private ArrayList actions;

	// Use this for initialization
	void Awake () {
		gm = GameObject.FindWithTag("Scripts").GetComponent<GameManager>();
		anim = GetComponent<Animator>();
		attack = GetComponent<Attack>();
	}
	
	// Update is called once per frame
	void Update () {
		if (gm.isRunning()) {
			if (actionCombo) {
				if (timer <= 0) {
					actionCombo = false;
					performAction();
				} else {
					if (Input.GetButtonDown("Fire1")) {
						actions.Add("Fire1");
						timer = comboTimeout;
					} else if (Input.GetButtonDown("Fire2")) {
						actions.Add("Fire2");
						timer = comboTimeout;
					} else {
						timer -= Time.deltaTime;
					}
				}
			} else {
				if (Input.GetButtonDown("Fire1")) {
					actions = new ArrayList();
					actions.Add("Fire1");
					actionCombo = true;
					timer = comboTimeout;
				} else if (Input.GetButtonDown("Fire2")) {
					actions = new ArrayList();
					actions.Add("Fire2");
					actionCombo = true;
					timer = comboTimeout;
				}
			}
		}
	}

	void FixedUpdate() {
		if (gm.isRunning()) {
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

	private void performAction() {
		bool breakCombo = false;
		string result = null;

		foreach (string action in actions) {
			switch (action) {
				case "Fire1" :
					switch (result) {
						case null :
							result = "Punch";
							break;
						case "Kick" :
							if (superKick) {
								result = "Super Kick";
							} else {
								breakCombo = true;
							}
							break;
						default :
							breakCombo = true;
							break;
					}
					break;
				case "Fire2" :
					switch (result) {
						case null :
							result = "Kick";
							break;
						case "Punch" :
							if (superPunch) {
								result = "Super Punch";
							} else {
								breakCombo = true;
							}
							break;
						case "Super Kick" :
							if (ultraKick) {
								result = "Ultra Kick";
							} else {
								breakCombo = true;
							}
							break;
						default :
							breakCombo = true;
							break;
					}
					break;
				default :
					breakCombo = true;
					break;
			}

			if (breakCombo) {
				break;
			}
		}

		switch (result) {
			case "Punch" :
				anim.SetTrigger("Punch");
				attack.punch();
				break;
			case "Kick" :
				anim.SetTrigger("Kick");
				attack.kick();
				break;
			case "Super Punch" :
				anim.SetTrigger("SuperPunch");
				attack.superPunch();
				break;
			case "Super Kick" :
				anim.SetTrigger("SuperKick");
				attack.superKick();
				break;
			case "Ultra Kick" :
				anim.SetTrigger("UltraKick");
				attack.ultraKick();
				break;
			default :
				break;
		}
	}

	public void unlockSuperPunch() {
		superPunch = true;
	}

	public void unlockSuperKick() {
		superKick = true;
	}

	public void unlockUltraKick() {
		ultraKick = true;
	}
}
