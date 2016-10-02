using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//工廠配合享元ＭＯＤＥ 在數值設定上就不需要以ＳＷＩＴＣＨ選擇
//只要知道編號就能個別產生對應數值

//使用在數值設定  裝備  角色 寵物 等等數值上面（遊戲平衡調整數值）

//最好設計方式為把數值設定分開建檔，工廠改為讀取數值個別檔案，取入後再建立元件 ＊這裡是寫在一起  

//載入時間過長 原因檔案太多還有檔案存放格式 ＥＸ：JSON ，XML，工具 ，平台等差異 ，可使用延後初始策略，在需要使用時再進行初始化

//直接紀錄ＫＥＹ 不記錄Reference    
//由於每次都要以ＫＥＹ查詢所以會增加運算時間
//若是採用這方式 數值工廠就會成為遊戲設定資料庫 這角色任何跟遊戲有關數值設定都可以透過資料過查詢
//
//遊戲設計一開始就會先將ＳＱＬ存取架構 資料仔入 數值管理設定 等功能完成
//因為這是開發中企劃最常接觸到的一部份  也是企劃開發工具  所需功能之一



//欄位需要新增時候，需調整
//類別下新增數值欄位
//增加反序列化需要程式碼
//企劃工具新增數值欄位以及序列化動作



/// share I
public abstract class Flyweight  {
	protected string m_Content;//show message

	public Flyweight (){}

	public Flyweight(string Content){
		m_Content = Content;
	}

	public string GetContent(){
		return m_Content;
	}

	public abstract void Operator ();

}
//share Content
public class ConcreteFlyweight:Flyweight{
	public ConcreteFlyweight(string Content):base(Content){
	}

	public override void Operator(){
		Debug.Log ("ConcreteFlyweight.Content[" + m_Content + "]");
}
}
	//No share 
	public class UnsharedCoincreteFlyweight{
		Flyweight m_Flyweight=null;//share I

		string m_UnsharedContent;//Not share

		public UnsharedCoincreteFlyweight(string Content){
			m_UnsharedContent=Content;
		}

		//Set share Content
		public void SetFlyweight(Flyweight theFlyweight){
			m_Flyweight=theFlyweight;}

		public void Operator(){
			string Msg =string.Format("UnshareCoincreteFlyweight.Content[{0}]",m_UnsharedContent);
			if (m_Flyweight != null)
				Msg += "Contain:" + m_Flyweight.GetContent ();
			Debug.Log (Msg);
					
		}
	}

public class FlyweightFactor{
	Dictionary<string,Flyweight> m_Flyweights = new Dictionary<string,Flyweight> ();

	//Get share Content
	public Flyweight GetFlyweight(string Key,string Content){
		if (m_Flyweights.ContainsKey (Key))
			return m_Flyweights[Key];

			ConcreteFlyweight theFlyweight = new ConcreteFlyweight (Content);
		m_Flyweights [Key] = theFlyweight;
		Debug.Log("New ConcreteFlyweight Key["+Key+"] Content["+Content+"]");
		return theFlyweight;
	}
	// only get Content no share  @Flyweight
	public UnsharedCoincreteFlyweight GetUnsharedFlyweight (string Content){
		return new UnsharedCoincreteFlyweight(Content);

	}
	//get share and no share  Content @Flyweight
	public UnsharedCoincreteFlyweight GetUnsharedFlyweight(string Key,string sharedContent, string UnsharedContent){

		//Get share pt
		Flyweight sharedFlyweight = GetFlyweight (Key, sharedContent);

		//produce Content
		UnsharedCoincreteFlyweight theFlyweight=new UnsharedCoincreteFlyweight(UnsharedContent);
		theFlyweight.SetFlyweight (sharedFlyweight); //Set shared pt
		return theFlyweight;
	}
}