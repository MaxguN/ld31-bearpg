using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	private Beardman beardman;

	private int level;
	private float experience;
	private float nextLevel;

	void Awake() {
		level = 1;
		experience = 0;
		nextLevel = 1000;
	}

	// Use this for initialization
	void Start () {
		beardman = GetComponent<Beardman>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gainExperience(float xp) {
		experience += xp;

		if (experience > nextLevel) {
			experience -= nextLevel;
			nextLevel *= 2;
			level += 1;
		}

		beardman.updateLevel(level, experience);
	}

	public int getLevel() {
		return level;
	}

	public float getExperience() {
		return experience;
	}

	public float getMaxExperience() {
		return nextLevel;
	}
}
