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