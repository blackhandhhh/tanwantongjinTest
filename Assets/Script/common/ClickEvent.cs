using UnityEngine;
using System.Collections;

public class ClickEvent : MonoBehaviour {
	
	void OnMouseEnter()
	{
		string Addevent = PlayerPrefs.GetString (this.name,"EventBase");
		print (this.name);
		GameObject.FindGameObjectWithTag ("control").AddComponent(Addevent);
	}
}
