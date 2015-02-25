using UnityEngine;
using System.Collections;

public class Event002 : MonoBehaviour {

	// Use this for initialization
	UILabel speaker;
	UILabel words;
	string[,] script = new string[200,2];
	int count = 0;
	int nowcount = 0;
	int ableUpdate=1;

	int state = 1;  //1为接受键盘输入,0为不接受键盘输入
	Event002 eventNow;
	public void Start () {
		speaker = GameObject.FindWithTag ("speaker").GetComponent<UILabel> ();
		words = GameObject.FindWithTag ("words").GetComponent<UILabel> ();
		eventNow = this.GetComponent<Event002>();
		ScenseSwitch x = (ScenseSwitch)GameObject.Find("tk2dCamera").GetComponent("ScenseSwitch");
		x.enabled = false;
		InitArray ();
	}
	
	// Update is called once per frame
	public void Update () {
		if (ableUpdate == 0)
						return;
		if (nowcount >= count) {
			GameObject.FindWithTag ("speakCamera").camera.enabled = false;
			eventNow.enabled = false;
			this.GetComponent<Event002>().enabled = false;
			ScenseSwitch x = (ScenseSwitch)GameObject.Find("tk2dCamera").GetComponent("ScenseSwitch");
			x.enabled = true;
		//		print (eventNow);
		//	eventNow.enabled = false;
				}
		else {
			if(script[nowcount,0].Equals("black2bg"))
			{
				nowcount++;
				StartCoroutine(black2BG());
			}
			if(script[nowcount,0].Equals(""))
			{
				GameObject.Find("dialogTitle").GetComponent<tk2dSprite>().SetSprite("MyNameUnkown");
			}
			else
				GameObject.Find("dialogTitle").GetComponent<tk2dSprite>().SetSprite("YouNameKnow");
			speaker.text = script[nowcount,0];
			words.text = script[nowcount,1];
				}
		if (Input.GetKeyDown (KeyCode.Space)&&state==1) {
						nowcount++;
				}
	}

	void InitArray()
	{

		add ("???","“醒醒……快醒醒……快醒醒。”");
		add ("black2bg","");
		add ("“啊！”");
		add ("我睁开了眼睛。一名少女蹲在我的面前，正在用担心的眼神看着我。");
		add ("怎么回事？我刚刚好像是去意识了的样子。");
		add ("???","“没事吧……看你很难受的样子。”");
		add ("“啊，我没事。谢谢关心”");
		add ("我下意识的就这样说了。虽然说头现在还很晕，思维有些混乱，完全不是没事的状态。");
		add ("不过我没有在他人面前露出软弱的一面的习惯。");
		add ("话说刚刚那个是什么。梦……么？");
		add ("???","“你没事就太好了呢，所有人就剩你一直躺在这里。我们还以为你出了什么事呢。”");
		add (" 少女露出的有些安心的笑容。");
		add ("“啊，恩？所有人？”");
		add ("我看向少女的身后，除了我和她之外，这里还有别的其他的人。他们看上去都是和我差不多大的高中生。");
		add ("哎？那些高中生……感觉有些眼熟？");
		add ("以及，现在气氛，非常的……奇怪？");
		add ("大脑的之中的思考回路逐渐恢复。我这个时候才发现了更大的问题。");
		add ("我刚刚不是才踏入希望之峰的校舍的大门么……这里是哪？");
		}


	void add(string speaker,string words)
	{
		script [count, 0] = speaker;
		script [count, 1] = words;
		count++;
		}

	void add(string words)
	{
		script [count, 0] = "";
		script [count, 1] = words;
		count++;
	}


	//IEnumerator black2BG()
	IEnumerator black2BG()
	{
		print ("123");
		GameObject.FindWithTag ("bg").GetComponent<black2bg> ().enabled = true;
		ableUpdate = 0;
		yield return new WaitForSeconds (5.0f);
		ableUpdate = 1;
	}
}


