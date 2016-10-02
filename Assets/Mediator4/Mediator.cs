using UnityEngine;
using System.Collections;


//仲介者模式
//
//優點：不會引入太多其他系統
//不論是對外訊息或是資訊傳達都只透過ConcreteMeidator
//
//對系統依賴性低 
//當系統或街面有所更改受引響的只有ConcreteMeidator
//
//注意事項：類別過多會造成介面爆炸
//
//其他應用方式：網路引擎 連線管理系統與封包管理系統 透過此溝通，就能輕易地針對連線管理系統抽換使用的方式，ＴＣＰ或ＵＤＰ
//資料庫引擎：內部可以分為數個子系統，有專門負責產生連線和操作的語法，兩個之間的溝通可以透過此來進行，讓兩者不互相依賴方便抽換另一個系統

//  ==========                   																		==========
// || face a ||    ============														  ==========        || Sys a ||   
// ||        || <= || face    || 													 ||        || =>    ==========
//  ==========     || all     ||													 ||        ||       ===========
//  ==========     ||         ||                    ==============					 ||  sys   || =>    || Sya b ||
// || face c ||    ||         ||      get all ==>   ||  center   ||   <=== get all   ||   all  ||       ===========
// ||        || <= ||         ||                    ||  chenge   ||                  ||        ||       ===========
//  ==========     ||         ||                    ==============   				 ||        || =>    || Sys c ||
//  ==========     ||         ||													 ||        ||       ===========
// || face b || <= ||         || 													 ||        ||  
// ||        ||    ============ 													  ========== 
//  ==========
public abstract class Mediator  {
	public abstract void SendMessage (Colleague theColleague, string Message);
}
	// Use this for initialization
	public abstract class Colleague{
		protected Mediator m_Mediator=null; //透過Mediator對外溝通

		public Colleague(Mediator theMediator){
			m_Mediator=theMediator;
		}

		public abstract void Reguest (string Message); //Mediator通知請求
	}



public class ConcreateColleague1:Colleague{
	public ConcreateColleague1 (Mediator theMediator) : base (theMediator){
	}

	public void Action(){
		m_Mediator.SendMessage (this, "Colleagel1發出通知");
	}

	public override void Reguest (string Message){
		Debug.Log ("ConcreateColleague1.Request:"+Message);
	}
}

public class ConcreateColleague2:Colleague{
	public ConcreateColleague2 (Mediator theMediator) : base (theMediator){
	}

	public void Action(){
		m_Mediator.SendMessage (this, "Colleagel2發出通知");
	}

	public override void Reguest (string Message){
		Debug.Log ("ConcreateColleague2.Request:"+Message);
	}

}


	//實作Mediator介面並集合管理Collage物件

	public class ConcreteMeidator:Mediator{
		ConcreateColleague1 m_Colleague1=null;
		ConcreateColleague2 m_Colleague2=null;

		public void SetColleageu1(ConcreateColleague1 theColleague){
			m_Colleague1 = theColleague;	
		}


		public void SetColleageu2(ConcreateColleague2 theColleague){
			m_Colleague2 = theColleague;	
		}

		public override void SendMessage(Colleague theColleague,string Message){
			if (m_Colleague1 == theColleague)
				m_Colleague2.Reguest (Message);

			if (m_Colleague2 == theColleague)
				m_Colleague1.Reguest (Message);
		}
	}