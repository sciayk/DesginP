using UnityEngine;
using System.Collections;

public class CompositeText : MonoBehaviour {
	void UnityText(){
		//new RootPoint
		IComponent theRoot = new Composite ("Root");

		theRoot.Add (new Leaf ("Leaf1"));
		theRoot.Add (new Leaf ("Leaf2"));

		//childPoint
		IComponent theChild1 = new Composite ("Child1");

		theRoot.Add (new Leaf ("Child1.Leaf1"));
		theRoot.Add (new Leaf ("Child1.Leaf2"));
		theRoot.Add (theChild1);

		//ChildPoint2
		IComponent theChild2 = new Composite ("Child2");

		theRoot.Add (new Leaf ("Child2.Leaf1"));
		theRoot.Add (new Leaf ("Child2.Leaf2"));
		theRoot.Add (theChild2);

		theRoot.Remove (theChild1);

		theRoot.Operation ();
	}
	// Use this for initialization
	void Start () {
		UnityText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
