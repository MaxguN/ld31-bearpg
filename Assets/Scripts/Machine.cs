using UnityEngine;
using System.Collections;

public class Machine : MonoBehaviour {
	public Transform ennemyTransform;
	public float duplicationRatio = 0.1f;
	public float spawnDelay = 3f;
	public int side = 1;

	private Transform spawnDestination;
	private int backlog = 0;
	private float timer;

	// Use this for initialization
	void Awake () {
		spawnDestination = transform.parent.parent.GetChild(transform.parent.GetSiblingIndex() + 1);
		resetTimer();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0) {
			spawn();
			resetTimer();
		}
	}

	private void resetTimer() {
		timer = spawnDelay;
	}

	private void spawn() {
		if (backlog > 0) {
			Transform liveBody = (Transform) Instantiate(ennemyTransform);
			liveBody.parent = spawnDestination;
			liveBody.position = new Vector3(transform.position.x, -1, 0);
			liveBody.GetComponent<ControlAI>().setSide(side);

			backlog -= 1;
		}
	}

	void OnTriggerEnter2D(Collider2D corpse) {
		Destroy(corpse.gameObject);

		if (backlog == 0) {
			resetTimer();
		}

		backlog += 1;

		if (Random.value < 0.1f) {
			backlog += 1;
		}
	}
}
