using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	private int score = 0;

	private TextMesh millions;
	private TextMesh thousands;
	private TextMesh units;

	// Use this for initialization
	void Awake () {
		millions = transform.GetChild(0).GetComponent<TextMesh>();
		thousands = transform.GetChild(1).GetComponent<TextMesh>();
		units = transform.GetChild(2).GetComponent<TextMesh>();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void addScore(int amount) {
		score += amount;
		updateScore();
	} 

	private void updateScore() {
		int m = score / 1000000;
		int t = (score - m * 1000000) / 1000;
		int u = (score - m * 1000000 - t * 1000);

		string mstr = "";
		string tstr = "";
		string ustr = "";

		if (u < 100) {
			ustr = "0";
			if (u < 10) {
				ustr += "0";
			}
		}
		ustr += u;

		if (t < 100) {
			tstr = "0";
			if (t < 10) {
				tstr += "0";
			}
		}
		tstr += t;

		if (m < 100) {
			mstr = "0";
			if (m < 10) {
				mstr += "0";
			}
		}
		mstr += m;

		millions.text = mstr;
		thousands.text = tstr;
		units.text = ustr;
	}
}
