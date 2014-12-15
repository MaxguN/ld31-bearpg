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
						checkAction();
						timer = comboTimeout;
					} else if (Input.GetButtonDown("Fire2")) {
						actions.Add("Fire2");
						checkAction();
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

			if (!asi.IsName("Base.Punch") && !asi.IsName("Base.Kick")) {
				anim.SetFloat("Speed", Mathf.Abs(h));
				rigidbody2D.velocity = new Vector2(h * maxSpeed, rigidbody2D.velocity.y);
				
				if (h > 0) {
					transform.localScale = new Vector3(1, 1, 1);
				} else if (h < 0) {
					transform.localScale = new Vector3(-1, 1, 1);
				}
			}
		}
	}

	private void checkAction() {
		string result = null;

		for (int i = 0; i < actions.Count; i += 1) {
			switch((string) actions[i]) {
				case "Fire1" :
					switch (result) {
						case null :
							result = "Punch";
							break;
						case "Kick" :			
							if (superKick  && GetComponent<Beardman>().hasEnergy(25)) {
								result = "Super Kick";
							} else {
								performKick();
								actions.RemoveAt(i - 1);
								i -= 1;
							}
							break;
						case "Punch" :
							performPunch();
							actions.RemoveAt(i - 1);
							i -= 1;
							break;
						case "Super Kick" :
							performSuperKick();
							actions.RemoveAt(i - 1);
							actions.RemoveAt(i - 2);
							i -= 2;
							break;
						default :
							break;
					}
					break;
				case "Fire2" :
					switch (result) {
						case null :
							result = "Kick";
							break;
						case "Punch" :
							if (superPunch && GetComponent<Beardman>().hasEnergy(25)) {
								result = "Super Punch";
							} else {
								performPunch();
								actions.RemoveAt(i - 1);
								i -= 1;
							}
							break;
						case "Super Kick" :
							if (ultraKick && GetComponent<Beardman>().hasEnergy(150)) {
								result = "Ultra Kick";
							} else {
								performSuperKick();
								actions.RemoveAt(i - 1);
								actions.RemoveAt(i - 2);
								i -= 2;
							}
							break;
						case "Kick" :
							performKick();
							actions.RemoveAt(i - 1);
							i -= 1;
							break;
						default :
							break;
					}
					break;
				default :
					break;
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
							if (superKick && GetComponent<Beardman>().hasEnergy(25)) {
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
							if (superPunch && GetComponent<Beardman>().hasEnergy(25)) {
								result = "Super Punch";
							} else {
								breakCombo = true;
							}
							break;
						case "Super Kick" :
							if (ultraKick && GetComponent<Beardman>().hasEnergy(150)) {
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
				performPunch();
				break;
			case "Kick" :
				performKick();
				break;
			case "Super Punch" :
				performSuperPunch();
				break;
			case "Super Kick" :
				performSuperKick();
				break;
			case "Ultra Kick" :
				performUltraKick();
				break;
			default :
				break;
		}
	}

	private void performPunch() {
		anim.SetTrigger("Punch");
		attack.punch();
	}

	private void performKick() {
		anim.SetTrigger("Kick");
		attack.kick();
	}

	private void performSuperPunch() {
		if (GetComponent<Beardman>().useEnergy(25)) {
			anim.SetTrigger("SuperPunch");
			attack.superPunch();
		}
	}

	private void performSuperKick() {
		if (GetComponent<Beardman>().useEnergy(25)) {
			anim.SetTrigger("SuperKick");
			attack.superKick();
		}
	}

	private void performUltraKick() {
		if (GetComponent<Beardman>().useEnergy(150)) {
			anim.SetTrigger("UltraKick");
			attack.ultraKick();
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
