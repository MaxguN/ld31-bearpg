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
			levelUp();
		}

		beardman.updateLevel(level, experience);
	}

	private void levelUp() {
		experience -= nextLevel;
		nextLevel *= 2;
		level += 1;

		// Temp autoselect upgrades
		switch (level) {
			case 2 :
				beardman.upgradeHealth();
				break;
			case 3 :
				beardman.unlockSuperPunch();
				break;
			case 4 :
				beardman.upgradeEnergy();
				break;
			case 5 :
				beardman.unlockSuperKick();
				break;
			case 6 :
				beardman.upgradeHealth();
				break;
			case 7 :
				beardman.unlockUltraKick();
				break;
			case 8 :
				beardman.upgradeEnergy();
				break;
			default:
				break;
		}
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
