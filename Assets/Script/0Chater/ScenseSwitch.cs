using UnityEngine;
using System.Collections;

public class ScenseSwitch : MonoBehaviour {

	int total = 0;
	// Use this for initialization
	void Start () {
		print ("yes");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A) && total > -1) {
			print ("left");
			total--;
			transform.Translate(-15,0,0);
		}
		else if(Input.GetKeyDown(KeyCode.D) && total < 1)
		{
			total++;
			transform.Translate(15,0,0);	
		}
	}
}
