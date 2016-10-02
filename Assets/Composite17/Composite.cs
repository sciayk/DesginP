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
//	  繼承      建構使用



	//優點：
	//1.介面跟功能分離：諾每個介面元件都是單純顯示設定與版面安排，上面不綁定任何遊戲功能腳本，基本就符合介面跟功能分離，可以容易轉移到其他專案
	//2.工作切分容易：當功能腳本從介面設定上移除，就能容易讓其他使用者從介面設計中脫離，
	//3.介面更動不引響專案：只要元件名稱不變，那麼介面更動就不容易引響到現有程式運作，像是元件大小、顏色等等

	//缺點：
	//1.元件名稱重複：元件收尋沒有設定好策略，以及層級沒有設定好，就可能發生名稱重複。因此使用ＴＯＯＬ這工具來提示重複名稱
	//2.元件更名不易：當介面需要更名，會讓原本元件無法取得。在ＴＯＯＬ裡面也有提示無法取得

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