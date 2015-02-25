using UnityEngine;
using System.Collections;

public class EventMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString (this.name, "Event002Overrid");
		PlayerPrefs.SetString ("Fujioka","doorFujioka");
		string nowEvent=PlayerPrefs.GetString(this.name,"EventBase");

		GameObject.FindWithTag ("control").AddComponent (nowEvent);
		this.GetComponent<EventMap> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
