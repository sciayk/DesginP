using UnityEngine;
using System.Collections;

public class singletonText : MonoBehaviour {

	void unitytext(){
		singleton.Instance.Name = "Hello";
		singleton.Instance.Name = "world";
		singleton.Instance.Talk ();
		Debug.Log (singleton.Instance.Name);


	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
