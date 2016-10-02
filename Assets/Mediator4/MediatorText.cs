using UnityEngine;
using System.Collections;

public class MediatorText : MonoBehaviour {

	void UnityText(){
		ConcreteMeidator pMediator = new ConcreteMeidator ();

		ConcreateColleague1 pColleague1 = new ConcreateColleague1 (pMediator);
		ConcreateColleague2 pColleague2 = new ConcreateColleague2 (pMediator);

		pMediator.SetColleageu1 (pColleague1);
		pMediator.SetColleageu2 (pColleague2);

		pColleague1.Action ();
		pColleague2.Action ();
	}
	// Use this for initialization
	void Start () {
		UnityText ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
