using UnityEngine;
using System.Collections;

public class StateText : MonoBehaviour {





	void UnityText(){
		Context theConText = new Context ();
		theConText.SetState (new ConcreteStateA (theConText));

		theConText.Request (5);
		theConText.Request (15);
		theConText.Request (25);
		theConText.Request (35);
	}
	// Use this for initialization
	void Start () {
		UnityText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
