using UnityEngine;
using System.Collections;

//State Mold
//
//狀態模式舉例：德魯伊 變成動物形態
//人變成動物
//物件行為會跟者內部而改變（不論怎改變都是同一個物件）
//可能改變為移動速度，攻擊速度等等
//
//常被應用在ＡＩ人工智慧，帳號登入狀態ＥＸ：ＧＧＣ綠燈紅燈，角色狀態（上面舉例）
//
//優點：不需使用ＳＷＩＴＣＨ ＣＡＳＥ    
//每一個狀態有關的狀態操作都在同一個類別下，可以清楚瞭解此狀態所需的物件與配合類別
//
//
//遊戲開發中後期，可能會增加遊戲內容
//ＥＸ：增加小遊戲關卡，圖鑑，排行榜等等
//分析後覺得無法在現有場景下實作，就必須做下列事情
//一。新增場景
//二。加入新ＳＴＡＴＥ到這新場景，並實作功能
//三。決定要從哪個場景轉換
//四。新場景結束後要轉換到哪場景

public class Context{
	State m_State=null;
	public void Request(int Value){
		m_State.Handle (Value);

	}
	public void SetState(State theState){
		Debug.Log ("ConText.SetState:" + theState);
		m_State = theState;
	}
}

public abstract class State
{
	protected Context m_Context = null;
	public State(Context theContext){
		m_Context = theContext;
	}
	public abstract void Handle (int Value);
}

public class ConcreteStateA:State{
	public ConcreteStateA(Context theContext):base(theContext){
	}
	public override void Handle(int Vlaue){
		Debug.Log ("ConcreteStateA.Handle");
		if (Vlaue > 10)
			m_Context.SetState (new ConcreteStateB (m_Context));
	}
}
public class ConcreteStateB:State{
	public ConcreteStateB(Context theContext):base(theContext){
	}
	public override void Handle(int Vlaue){
		Debug.Log ("ConcreteStateB.Handle");
		if (Vlaue > 20)
			m_Context.SetState (new ConcreteStateC (m_Context));
	}
}
public class ConcreteStateC:State{
	public ConcreteStateC(Context theContext):base(theContext){
	}
	public override void Handle(int Vlaue){
		Debug.Log ("ConcreteStateC.Handle");
		if (Vlaue > 30)
			m_Context.SetState (new ConcreteStateA (m_Context));
	}
}
