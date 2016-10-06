using UnityEngine;
using System.Collections;

public class Run : MonoBehaviour {
	public GameObject Monster;
	public GameObject People;
	Vector3 PTP ;
	Vector3 MTP ;
	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
		MTP = Monster.transform.position;
		PTP = People.transform.position;
		Monster.transform.position += new Vector3 (0, 0, 0.1f);
		if (Input.GetKey (KeyCode.A)) {
			if (PTP.x < MTP.x) {
				People.transform.position+=new Vector3(0.2f,0,0);
			}else{People.transform.position-=new Vector3(0.2f,0,0);}
			if (PTP.z < MTP.z) {
				People.transform.position+=new Vector3(0,0,0.2f);
			}else{People.transform.position-=new Vector3(0,0,0.2f);}
		}
	}
}
