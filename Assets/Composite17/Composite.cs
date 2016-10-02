using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Composite : IComponent {
	//組合模式
//	組合模式使用了樹狀結構，並應用在遊戲物件管理
//	使用了根節點、葉節點的概念
//	當根節點被刪除，葉節點也會被刪除
//
//	說明：不管是根還是葉都在同是繼承同一介面
//	Ｃ（元件介面）＝ 定義每隔節點可使用操作方法、Ｃo（組合節點＊指根節點）＝實作Ｃ與子節點操作有關方法、L（葉節點）＝實作Ｃ根本行為
//
//	C  <-  Co =>  C
//	   <-  Ｌ   
//	  繼承     建構使用

	//EX: unity Hierarchy


	//用來設計ＵＩ介面控制
	//ＥＸ： ＵＩＴ（底層） 給三個ＵＩ介面繼承  1.遊戲暫停2.遊戲狀態3.角色狀態 
	//用來控制上面三種ＵＩ開關設定
	List<IComponent> m_Childs=new List<IComponent>();

	public Composite(string Value){
		m_Value = Value;
	}

	public override void Operation (){
		Debug.Log("Composite["+m_Value+"]");

	}

	//AddPoint
	public override void Add(IComponent theComponent){
		Debug.LogWarning ("Add");
		m_Childs.Add (theComponent);
	}

	//Re Point
	public override void Remove(IComponent theComponent){
		Debug.LogWarning ("Remove");
		m_Childs.Remove (theComponent);
	}

	//Get Point
	public override IComponent GetChild(int Index){
		Debug.LogWarning ("GetChild");
		return m_Childs[Index];
	}
}
public abstract class IComponent{

	protected string m_Value;
	//操作
	public abstract void Operation ();

	public virtual void Add(IComponent theComponent){
		Debug.LogWarning ("no fruter");
	}

	public virtual void Remove(IComponent theComponent){
		Debug.LogWarning ("no Fruter");

	}

	public virtual IComponent GetChild(int Index){
		Debug.LogWarning ("no Fruter");
		return null;
	}

}

public class Leaf:IComponent{
	public Leaf(string Vlaue){
		m_Value=Vlaue;
	}

	public override void Operation(){
		Debug.Log ("Leaf[" + m_Value + "]start Operation()");
	}
}

//這種方式可能會產生重複命名的問題
//因此提供配套檢查姓名工具請看UITOOL