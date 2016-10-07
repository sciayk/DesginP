using UnityEngine;
using System.Collections;

//責任鏈模式
//EX:我向客服詢問一個問題，他不知道幫我轉線到其他部門，直到有一部門知道我要的答案
//再套用此模式解決問題時，將以下幾個重點分別提出實作，即可達成基本需求
//。可以解決請求的接收者物件：這些物件能夠了解『請求』的訊息內容，並知道是否能解決。
//。接收者物件間的串接：利用一個串接機制，將每一個可能可以解決問題的物件串接起來，當本身無法解決就將請求傳遞下去
//。請求自動轉移：請求自動轉移給下一個，過程中不需要特別轉換介面



public class chainofResponsibility : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public abstract class Handler{
	protected Handler m_NextHandler=null;

	public Handler(Handler theNextHandler){
		m_NextHandler = theNextHandler;
	}

	public virtual void HandleRequest(int Cost){
		if (m_NextHandler != null)
			m_NextHandler.HandleRequest (Cost);
	}
}

public class ConcreteHandler1:Handler{
	private int m_CostCheck = 10;

	public ConcreteHandler1(Handler theNextHandler):base (theNextHandler){
	}

	public override void HandleRequest(int Cost){
		if (Cost <= m_CostCheck)
			Debug.Log ("ConcrteHandler1.HandleRequest OK!!PASS!!");
		else
			base.HandleRequest (Cost);
	}
}

public class ConcreteHandler2:Handler{
	private int m_CostCheck = 20;

	public ConcreteHandler2(Handler theNextHandler):base (theNextHandler){
	}

	public override void HandleRequest(int Cost){
		if (Cost <= m_CostCheck)
			Debug.Log ("ConcrteHandler2.HandleRequest OK!!PASS!!");
		else
			base.HandleRequest (Cost);
	}
}

public class ConcreteHandler3:Handler{
	private int m_CostCheck = 30;

	public ConcreteHandler3(Handler theNextHandler):base (theNextHandler){
	}

	public override void HandleRequest(int Cost){
		
			Debug.Log ("ConcrteHandler3.HandleRequest OK!!PASS!!");
	
	}
}