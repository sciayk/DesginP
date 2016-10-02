using UnityEngine;
using System.Collections;

public class FacetoryMethodText : MonoBehaviour {



//	四種方式會按照實務情況來作選擇
//	再不知道要用哪個方式時候
//	建議可以選擇第二種利用參數來產生物件
//	原因：可以避免過多工廠，也不必寫複雜的泛型。唯一要忍受是switch case語法的缺點
	// Use this for initialization
	void Start () {

		//First Function Facetory
		Product theProduct = null;
		Creator theCreator = null;

		theCreator = new ConcreteCreatProductA ();
		theProduct = theCreator.FacetoryMethod ();

		theCreator = new ConcreteCreatProductB ();
		theProduct = theCreator.FacetoryMethod ();


		//Second Function Facetory
		Creator_MethodType theCreatorMethodType= new ConcreteCreator_MethodType();

		theProduct = theCreatorMethodType.FacetoryMethod(1);
		theProduct = theCreatorMethodType.FacetoryMethod(2);


		//Three Function Facetory
		//第三種作法使用泛型，跟第一種比起來可省去實作方式，改用Ｔ類型別來產生物件

		Creator_GenericClass<ConcreteProductAA> Creator_ProductA = new Creator_GenericClass<ConcreteProductAA> ();
		theProduct = Creator_ProductA.FactoryMethod ();
		Creator_GenericClass<ConcreteProductBB> Creator_ProductB = new Creator_GenericClass<ConcreteProductBB> ();
		theProduct = Creator_ProductB.FactoryMethod ();

		//第四種方式實作
		Creatory_GenericMethod theCreatorGM= new ConcreteCreator_GenericMethod();
		theProduct = theCreatorGM.FactoryMethod<ConcreteProductAA> ();
		theProduct = theCreatorGM.FactoryMethod<ConcreteProductBB> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
