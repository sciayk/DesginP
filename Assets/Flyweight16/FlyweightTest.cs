using UnityEngine;
using System.Collections;

public class FlyweightTest : MonoBehaviour {

	void UniTest(){
		//Factory
	FlyweightFactor theFactory = new FlyweightFactor();

		//produce share Content
		theFactory.GetFlyweight ("1", "shared Content 1");
		theFactory.GetFlyweight ("2", "shared Content 2");
		theFactory.GetFlyweight ("3", "shared Content 3");

		//Get share Content
		Flyweight theFlyweight = theFactory.GetFlyweight ("1", "");
		theFlyweight.Operator ();

		//produce no share Content
		UnsharedCoincreteFlyweight theUnshared1= theFactory.GetUnsharedFlyweight("no share Message1");
		theUnshared1.Operator ();


		//using theFlyweight1 give theUnshared1,then produce theUnshared2

		//set share
		theUnshared1.SetFlyweight (theFlyweight);

		//produce no shareContent  and  use share1
		UnsharedCoincreteFlyweight theUnshared2 = theFactory.GetUnsharedFlyweight ("1", "", "no share Message2");
		theUnshared1.Operator();
		theUnshared2.Operator();

	}
	// Use this for initialization
	void Start () {
		UniTest ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
