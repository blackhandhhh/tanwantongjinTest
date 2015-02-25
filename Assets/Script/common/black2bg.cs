using UnityEngine;
using System.Collections;

public class black2bg : MonoBehaviour {

	// Use this for initialization
	public int value = 0;
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (value == 1) {
			Color color = this.GetComponent<tk2dSprite> ().color;
			color.r += 0.2f*Time.deltaTime;
			color.g += 0.2f*Time.deltaTime;
			color.b += 0.2f*Time.deltaTime;
			this.GetComponent<tk2dSprite> ().color = color;
			if(color.r>=1.0f)
				value = 0;
				}
	}

	public void Init()
	{
		Color color = this.GetComponent<tk2dSprite> ().color;
		color.r = 0;
		color.g = 0;
		color.b = 0;
		this.GetComponent<tk2dSprite> ().color = color;
		value = 1;
	}

}
