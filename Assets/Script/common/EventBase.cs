using UnityEngine;
using System.Collections;

public class EventBase : MonoBehaviour {

	public const int ONMENU = 1;
	public const int KEYABLE = 0;
	public const int KEYUNABLE = 2;
	public const int DESTORY = 3;

	public tk2dSprite personPic;

	UILabel speaker;
	UILabel words;
	string[,] script = new string[200,2];
	int count = 0;
	int nowcount = 0;
	int state = 0;

	string dialogTitle = "dialogTitle";
	string myName = "MyNameUnkown";
	string youName = "YouNameKnow";
	string bgTag = "bg";
	string speakerTag = "speaker";
	string wordsTag = "words";
	string mainCamera = "speakMCamera";
	string speakCamera ="speakCamera";


	public void setDialogTitle(string dialogTitle)
	{
		this.dialogTitle = dialogTitle;
	}

	public void setMyName(string myName)
	{
		this.myName = myName;
		}

	public void setYouName(string youName)
	{
		this.youName = youName;
		}

	public void setBGTag(string BGTag)
	{
		this.bgTag = BGTag;
		}

	public void setSpeakerTag(string speakerTag)
	{
		this.speakerTag = speakerTag;
		}

	public void setWordsTag(string wordsTag)
	{
		this.wordsTag = wordsTag;
		}

	public void setMainCamera(string mainCamera)
	{
		this.mainCamera = mainCamera;
		}

	public void setSpeakCamera(string speakCamera)
	{
		this.speakCamera = speakCamera;
		}

	// Use this for initialization
	void Start () {
		Init ();
	}
	
	// Update is called once per frame
	void Update () {
		if (state == DESTORY)
						return;
		if (nowcount >= count) {
			UnInit();
			state = DESTORY;
			return ;
				}
		switch(state)
		{
		case ONMENU:OnMenu();
			break;
		case KEYABLE:onKey_Able();
			break;
		case KEYUNABLE:onKey_Unable();
			break;
		}
	}

	protected void OnMenu(){
		}

	protected void onKey_Able(){
		if(script[nowcount,0].Equals("black2bg"))
		{
			nowcount++;
			StartCoroutine(black2BG());
		}
		if (script [nowcount, 0].Equals ("setPerson")) {
			nowcount++;
			Instantiate(personPic);
				}
		if(script[nowcount,0].Equals(""))
		{
			GameObject.Find(dialogTitle).GetComponent<tk2dSprite>().SetSprite(myName);
		}
		else
			GameObject.Find(dialogTitle).GetComponent<tk2dSprite>().SetSprite(youName);
		speaker.text = script[nowcount,0];
		words.text = script[nowcount,1];
		if (Input.GetKeyDown (KeyCode.Space)&&state==KEYABLE) {
			print ("space");
			nowcount++;
			}
		}

	protected void onKey_Unable(){

		}

	public virtual IEnumerator black2BG()
	{
		GameObject[] obj = GameObject.FindGameObjectsWithTag (bgTag);
		for (int i=0; i<obj.Length; i++) {
			obj[i].GetComponent<black2bg>().enabled = true;
			obj[i].GetComponent<black2bg>().Init();
				}
		GameObject.FindWithTag ("person").GetComponent<black2bg> ().enabled = true;
		GameObject.FindWithTag ("person").GetComponent<black2bg> ().Init ();
		state = KEYUNABLE;
		yield return new WaitForSeconds (5.0f);
		state = KEYABLE;
	}

	protected virtual void Init(){
		GameObject.FindWithTag (speakCamera).camera.enabled = true;
		speaker = GameObject.FindWithTag (speakerTag).GetComponent<UILabel> ();
		words = GameObject.FindWithTag (wordsTag).GetComponent<UILabel> ();
		ScenseSwitch x = (ScenseSwitch)GameObject.Find(mainCamera).GetComponent("ScenseSwitch");
		x.enabled = false;
		eyeWatch y = (eyeWatch)GameObject.Find(mainCamera).GetComponent<eyeWatch>();
		y.enabled = false;
		InitArray ();
	}
	protected virtual void UnInit(){
		GameObject.FindWithTag (speakCamera).camera.enabled = false;
		ScenseSwitch x = (ScenseSwitch)GameObject.Find(mainCamera).GetComponent("ScenseSwitch");
		x.enabled = true;
		eyeWatch y = (eyeWatch)GameObject.Find(mainCamera).GetComponent<eyeWatch>();
		y.enabled = true;
		GameObject.Find (dialogTitle).GetComponent<Transform> ().Translate (0,100,0);
	}
	protected virtual void InitArray(){
		//todo;
	}

	protected void add(string speaker,string words)
	{
		script [count, 0] = speaker;
		script [count, 1] = words;
		count++;
	}
	
	protected void add(string words)
	{
		script [count, 0] = "";
		script [count, 1] = words;
		count++;
	}
}
