using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {
	public float maxEnergy = 100f;

	private Beardman beardman;
	private float energy;

	void Awake () {
		energy = 0;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getEnergy() {
		return energy;
	}

	public float getMaxEnergy() {
		return maxEnergy;
	}
}
