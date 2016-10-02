using UnityEngine;
using System.Collections;

public class TemplateMthod {
	//
	//樣板模式
	//當發現有相同演算流程時候可以使用樣板模式
	//
	//定義：在一個操作方法中定義演算法的流程，當中某些步驟由子類別完成，樣板模式讓子類別在不更動原有演算法流程下
	//還能夠重新定義當中的步驟
	//1.定義一個演算法流程，即是明確定義演算法每一個步驟，並寫在父類別中，而每一個方法都是一個呼叫
	//2.為什麼要子類別完成，而不是父類別完成？
	//Ｏ定義流程時候，有些步驟需要以當時環境來決定。
	//Ｏ定義演算法時候，針對每一個步驟都提供預設解決方案，但有時候會出現更好的方法，此時就要讓這個更好的方法能在原有架構中使用
	//
	//
	//優點：將可能重複出現的流程從子類別提升到父類別，減少重複的發生
	//但是，如果步驟開放太多，並要求子類別必須全部實作，反而會造成困難，也不容易維護
	//
//
//
//	應用方式：
//	在ＲＰＧ裡面，施放法術時候會有一系列檢查條件，像是：魔力是否足夠，冷卻，對象是否在範圍內，等等條件。依造不同法術條件而不一樣。
//	這些檢查方式就可以使用樣板模式
//
//	線上遊戲登入也可以使用。例如：顯示登入方式，選擇登入方法，輸入帳密，像伺服器請求登入...等等
//	將登入流程實作成登入流程樣板，對應不同登入方式OpenID，自動登入，快速登入
}

//定義流程，分為兩個步驟
public abstract class AbstracClass{
	public void TemplatrMethod(){
		primitiveOperation1 ();
		primitiveOperation2 ();
	}

	protected abstract void primitiveOperation1 ();
	protected abstract void primitiveOperation2 ();
}

public class ConcreteClassA:AbstracClass{
	protected override void primitiveOperation1(){
		Debug.Log ("A.primitiveOperation1");
	}
	protected override void primitiveOperation2(){
		Debug.Log ("A.primitiveOperation2");
	}
}

public class ConcreteClassB:AbstracClass{
	protected override void primitiveOperation1(){
		Debug.Log ("B.primitiveOperation1");
	}
	protected override void primitiveOperation2(){
		Debug.Log ("B.primitiveOperation2");
	}
}
