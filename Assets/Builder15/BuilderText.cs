using UnityEngine;
using System.Collections;

public class BuilderText : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Director theDirectoir = new Director ();
		BuilderProduct theBuilderProduct = null;

		//use BuilderA Product
		theDirectoir.Construct(new ConcreteBuilderA());
		theBuilderProduct = theDirectoir.GetResult ();
		theBuilderProduct.ShowProduct ();

		//use BuilderB Product
		theDirectoir.Construct(new ConcreteBuilderB());
		theBuilderProduct = theDirectoir.GetResult ();
		theBuilderProduct.ShowProduct ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
