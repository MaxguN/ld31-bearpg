using UnityEngine;
using System.Collections;

public class Beardman : MonoBehaviour {
	private GameManager gm;
	private Score score;

	private Health healthScript;
	private Energy energyScript;
	private Level levelScript;

	private Transform health;
	private Transform energy;
	private Transform level;

	private float maxHealthWidth;
	private float maxEnergyWidth;
	private float maxExperienceWidth;

	private int healthUpgrades = 1;
	private int energyUpgrades = 1;

	// Use this for initialization
	void Awake () {
		gm = GameObject.FindWithTag("Scripts").GetComponent<GameManager>();
		score = GameObject.FindWithTag("Score").GetComponent<Score>();

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

	public bool useEnergy(float en) {
		return energyScript.useEnergy(en);
	}

	public bool hasEnergy(float en) {
		return energyScript.hasEnergy(en);
	}

	public void upgradeHealth() {
		healthScript.increaseHealth();
		healthUpgrades += 1;

		float posX = health.GetChild(1).localPosition.x + (health.GetChild(1).renderer.bounds.size.x / (healthUpgrades - 1)) / 2;

		health.GetChild(1).localPosition = new Vector3(posX, 0, 0.1f);
		health.GetChild(1).localScale = new Vector3(healthUpgrades, 1, 1);

		//maxHealthWidth = maxEnergyWidth * healthUpgrades / (healthUpgrades - 1);
	}

	public void upgradeEnergy() {
		energyScript.increaseEnergy();
		energyUpgrades += 1;

		float posX = energy.GetChild(1).localPosition.x + (energy.GetChild(1).renderer.bounds.size.x / (energyUpgrades - 1)) / 2;

		energy.GetChild(1).localPosition = new Vector3(posX, 0, 0.1f);
		energy.GetChild(1).localScale = new Vector3(energyUpgrades, 1, 1);
	}

	public void unlockSuperPunch() {
		GetComponent<ControlBeardman>().unlockSuperPunch();
	}

	public void unlockSuperKick() {
		GetComponent<ControlBeardman>().unlockSuperKick();
	}

	public void unlockUltraKick() {
		GetComponent<ControlBeardman>().unlockUltraKick();
	}

	public void updateHealth(float hp) {
		float maxHealth = healthScript.getMaxHealth();

		float scaleX = healthUpgrades * hp / maxHealth;
		float posX = (healthUpgrades - 1) * maxHealthWidth / 2 - maxHealthWidth * (healthUpgrades - scaleX) / 2;

		health.GetChild(0).localPosition = new Vector3(posX, 0, 0);
		health.GetChild(0).localScale = new Vector3(scaleX, 1, 1);
	}

	public void updateEnergy(float en) {
		float maxEnergy = energyScript.getMaxEnergy();

		float scaleX = energyUpgrades * en / maxEnergy;
		float posX = (energyUpgrades - 1) * maxEnergyWidth / 2 - maxEnergyWidth * (energyUpgrades - scaleX) / 2;

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

	public void kill(float hp, float en, float xp) {
		healthScript.gainHealth(hp);
		energyScript.gainEnergy(en);
		levelScript.gainExperience(xp);
		score.addScore(1000);
	}

	public void die() {
		gm.gameover();
	}
}
