using UnityEngine;
using System.Collections;

public class addBaseCompent : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] bg = GameObject.FindGameObjectsWithTag("bg");
		for (int i=0; i<bg.Length; i++) {
			bg[i].AddComponent("black2bg");
				}

		GameObject[] check = GameObject.FindGameObjectsWithTag("checked");
		for (int i=0; i<check.Length; i++) {
			check[i].AddComponent<BoxCollider>();
			check[i].AddComponent<ClickEvent>();
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
