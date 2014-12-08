using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	public float maxEnergy = 100f;

	private Beardman beardman;

	private float energy;
	private float baseEnergy;

	void Awake () {
		beardman = GetComponent<Beardman>();
		energy = 0;
		baseEnergy = maxEnergy;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void gainEnergy(float en) {
		energy += en;

		if (energy > maxEnergy) {
			energy = maxEnergy;
		}

		beardman.updateEnergy(energy);
	}

	public void increaseEnergy() {
		maxEnergy += baseEnergy;
	}

	public float getEnergy() {
		return energy;
	}

	public float getMaxEnergy() {
		return maxEnergy;
	}
}
