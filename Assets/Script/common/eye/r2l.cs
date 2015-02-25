using UnityEngine;
using System.Collections;

public class r2l : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Rotate (0,0,60*Time.deltaTime,Space.Self);
	}
}
