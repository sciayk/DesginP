using UnityEngine;
using System.Collections;

public class touchmuch : MonoBehaviour {
	public Texture2D imageMenu;
	public Texture2D imageItem;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
	void ONGUI(){
		GUI.DrawTexture(new Rect(0,0,640,960),imageMenu);
			int Count=Input.touchCount;
			for(int i=0;i<Count;i++){
			Vector2 iPos = Input.GetTouch(i).position;
			float x = iPos.x;
			float y = iPos.y;
			GUI.DrawTexture(new Rect(x,960 - y,277,320), imageItem);
			GUI.Label(new Rect(x,960 - y,277,320), "Touch position is" + iPos);
			}
	}
}
