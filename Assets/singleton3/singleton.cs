using UnityEngine;
using System.Collections;

public class singleton {

//	＊不推薦使用
//
//	使用特色：
//	只能一個此物件
//	提供一個快速存取物件方式
//
//	條件需要：
//	靜態類別屬性 static class firstsingleton{}
//	靜態類別方法	
//	重新定義類別建構者存取階級

	public string Name{get;set;}

	private static singleton _Instance; //空的屬性
	public static singleton Instance{
		get{if(_Instance==null){   //是空的就建構東西給他
				Debug.Log ("produce Singleton");

					_Instance=new singleton();
				}
				return _Instance;
			}
	}
	public void Talk(){
		Debug.Log ("123");
	}

	private singleton(){}  //將建構變成私人，讓他無法再被建構  singleton sin2=new singleton();  (無法在建構，一個防呆)
}

