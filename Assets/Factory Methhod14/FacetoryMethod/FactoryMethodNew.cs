using UnityEngine;
using System.Collections;

public class FactoryMethodNew  {


	//第一種方式在物件變多時候會出現工廠子類別爆多情況
//	對於後續維護是非常困難的
//	當發生上述情況可以改由單一工廠
//	配合傳入參數決定生產哪個類別


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public abstract class Creator_MethodType{
	public abstract Product FacetoryMethod (int Type);
}

public class ConcreteCreator_MethodType:Creator_MethodType
{
	public ConcreteCreator_MethodType(){
		Debug.Log ("Facetory Product Type");
	}

	public override Product FacetoryMethod(int Type){
		switch (Type) {
		case 1:
			return new ConcreteProductAA ();
		case 2:
			return new ConcreteProductBB ();
		default:
			Debug.Log ("Type[" + Type + "]no this Type");
			break;
		}
		return null;
	}

}
