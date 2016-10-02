using UnityEngine;
using System.Collections;

public class TemplantMethodText : MonoBehaviour {
	void UnityText(){
		AbstracClass theClass = new ConcreteClassA ();
		theClass.TemplatrMethod ();

		theClass = new ConcreteClassB ();
		theClass.TemplatrMethod ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
