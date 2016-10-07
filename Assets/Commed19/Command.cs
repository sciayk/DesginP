using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//
//命令模式
//ＥＸ：點餐之後廚房排入清單，依造順序製作
//
//定義：請求封裝成物件，將不同請求參數化，並配合紀錄、復原、佇列等等操作請求
//1.請求的封裝，2.請求的操作
//
//參數Ａ  參數Ｂ   參數Ｃ   參數Ｄ
//  |      |       |       |
//   ---------------------- 
//             |
//          參數集合
//             ｜
//Void FunctionName(ParamSet theParm)
//

//命令模式標準為：當請求被物件化時是否有『管理』的需求，如果有就以命令模式實作

//*不套用命令模式情況
//1.類別過多情況下，如果每個功能都套用命令模式，那就會產生類別過問題，每個命令都需要封裝，會造成專案不容易維護
//2.有些物件不需要被管理，ＥＸ：武器升級 。 武器升級請求發出去他就是被確認要執行的功能，因此不需要被暫緩功能
//
//需要大量請求時
//ＥＸ：需要和伺服器溝通的多人ＭＭＯ遊戲，伺服器端與客戶端溝通時，也會以命令模式來設計
//ＢＵＴ 中小型連線遊戲，兩端請求可能多達數百或千，如果每個都要請求命令會產生過多類別，可以使用下列方式改善
//1.使用ＣＡＬＬ ＢＡＣＫ 將一樣的東西管理，並針對每個命令，註冊一個回呼函示，將功能執行者改為一個方法，而非類別物件。
//最後將多個相同功能封裝一起。
//2.使用泛型：將命令介面以泛型來設計，將功能執行者定義為泛型類別，命令執行時呼叫泛型中固定方法，
//但是限制會比較大
//Ａ 必須限定每個命令封裝數量，封裝名稱不直覺，也就是將參數已ＰＡＲＭ1，2方式命名。
//Ｂ 因為固定呼叫某一方法，所以方法名稱固定不容易與實際功能聯想
//

//當命令模式需要新變化
//只要指令產生是正確的在任何功能需求點，都能快速產生所需指令。
//
//其他應用方式：
//網路連線遊戲：兩端的封包處理會使用命令模式實作，
//但對於封包命令管理，可能不會實作復原操作，一般注重在執行與紀錄上面，而紀錄則是另一個重點，透過紀錄可以分析玩家與伺服器的互動，
//有妨駭預警作用。


//兩個命令
public class Receiver1{
	public Receiver1(){}
	public void Action(string Command){
		Debug.Log ("Receiver1.Action:Command[" + Command + "]");
	}
}

public class Receiver2{
	public Receiver2(){}
	public void Action(int Param){
		Debug.Log ("Receiver2.Action:Param[" + Param.ToString() + "]");
	}
}

//將這兩個封裝
abstract public class Command {
	public abstract void Execute ();

}

public class ConcreteCommand1:Command{
	Receiver1 m_Receiver = null;
	string m_command = "";

	public ConcreteCommand1(Receiver1 Receiver,string Command){
		m_Receiver = Receiver;
		m_command = Command;
	}

	public override void Execute(){
		m_Receiver.Action (m_command);
	}

}

public class ConcreteCommand2:Command{
	Receiver2 m_Receiver = null;
	int m_Param = 0;

	public ConcreteCommand2(Receiver2 Receiver,int Param){
		m_Receiver = Receiver;
		m_Param=Param;
	}

	public override void Execute(){
		m_Receiver.Action (m_Param);
	}

}


//使用ＬＩＳＴ來儲存命令，當執行時候一次執行所有命令，並清空
public class Invoker{

	List<Command> m_Commands =new List<Command>();

	//AddCommand

	public void AddCommand(Command theCommand){
		m_Commands.Add (theCommand);
	}

	//start Command
	public void ExecuteCommand(){
		foreach (Command theCommand in m_Commands)
			theCommand.Execute ();
		m_Commands.Clear ();
	}

}