using UnityEngine;
using System.Collections;

public class StrategyText : MonoBehaviour {


	void Unitytext(){
		ConText theContext=new ConText();

		theContext.SetStrategy (new ContcreteSteategyA ());
		theContext.ContextInterface ();
		theContext.SetStrategy (new ContcreteSteategyB ());
		theContext.ContextInterface ();
		theContext.SetStrategy (new ContcreteSteategyC ());
		theContext.ContextInterface ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
