using UnityEngine;
using System.Collections;

public class eyeWatch : MonoBehaviour {

	GameObject[] eyes;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W)) {
			eyes = GameObject.FindGameObjectsWithTag("eye");
		}

		if (Input.GetKeyUp (KeyCode.W)) {
			//GameObject[] eyes1 = GameObject.FindGameObjectsWithTag("eye");
			//for(int i=0;i<eyes1.Length;i++)
			//	eyes1[i].transform.Translate(0,0,5);
			for(int i=0;i<eyes.Length;i++)
			{
				Color color= eyes[i].GetComponent<tk2dSprite>().color;
				color.a = 0;
				eyes[i].GetComponent<tk2dSprite>().color = color;
			}
			eyes = null;
		}

		if(eyes!=null)
		{
			for(int i=0;i<eyes.Length;i++)
			{
				Color color= eyes[i].GetComponent<tk2dSprite>().color;
				if(color.a<1)
				{
					color.a += 2*Time.deltaTime;
					eyes[i].GetComponent<tk2dSprite>().color = color;
				}
			}
		}
		}
}
