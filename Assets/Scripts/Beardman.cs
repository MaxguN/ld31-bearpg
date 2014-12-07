using UnityEngine;
using System.Collections;

public class Beardman : MonoBehaviour {
	private Health healthScript;
	private Energy energyScript;
	private Level levelScript;

	private Transform health;
	private Transform energy;
	private Transform level;

	private float maxHealthWidth;
	private float maxEnergyWidth;
	private float maxExperienceWidth;

	// Use this for initialization
	void Awake () {
		health = GameObject.FindWithTag("Health").transform;
		energy = GameObject.FindWithTag("Energy").transform;
		level = GameObject.FindWithTag("Level").transform;

		maxHealthWidth = health.GetChild(0).renderer.bounds.size.x;
		maxEnergyWidth = energy.GetChild(0).renderer.bounds.size.x;
		maxExperienceWidth = level.GetChild(0).GetChild(0).renderer.bounds.size.x;
	}

	void Start() {
		healthScript = GetComponent<Health>();
		energyScript = GetComponent<Energy>();
		levelScript = GetComponent<Level>();

		updateHealth(healthScript.getHealth());
		updateEnergy(energyScript.getEnergy());
		updateLevel(levelScript.getLevel(), levelScript.getExperience());
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void updateHealth(float hp) {
		float maxHealth = healthScript.getMaxHealth();

		float scaleX = hp / maxHealth;
		float posX = -maxHealthWidth * (1 - scaleX) / 2;

		health.GetChild(0).localPosition = new Vector3(posX, 0, 0);
		health.GetChild(0).localScale = new Vector3(scaleX, 1, 1);
	}

	public void updateEnergy(float en) {
		float maxEnergy = energyScript.getMaxEnergy();

		float scaleX = en / maxEnergy;
		float posX = -maxEnergyWidth * (1 - scaleX) / 2;

		energy.GetChild(0).localPosition = new Vector3(posX, 0, 0);
		energy.GetChild(0).localScale = new Vector3(scaleX, 1, 1);
	}

	public void updateLevel(int lvl, float xp) {
		level.GetChild(1).GetComponent<TextMesh>().text = "LEVEL " + lvl;

		float maxExperience = levelScript.getMaxExperience();

		float scaleX = xp / maxExperience;
		float posX = -maxExperienceWidth * (1 - scaleX) / 2;

		level.GetChild(0).GetChild(0).localPosition = new Vector3(posX, 0, 0);
		level.GetChild(0).GetChild(0).localScale = new Vector3(scaleX, 1, 1);
	}

	public void kill() {
		levelScript.gainExperience(100);

	}

	public void die() {
		// endgame
	}
}
