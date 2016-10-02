using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class REandNoRE : MonoBehaviour {


}
public class Re{
	public Re(){}
	public void Action(string Command){
		Debug.Log ("Re[" + Command + "]");
	}
}

public class NoRE{
	public NoRE(){}
	public void Action(int Param){
		Debug.Log ("NoRE[" + Param.ToString() + "]");
	}
}

//將這兩個封裝
abstract public class ReOrNoRe {
	public abstract void Execute ();

}

public class ReOrNoRe1:ReOrNoRe{
	Re m_Re = null;
	string m_command = "";

	public ReOrNoRe1(Re Ree,string Command){
		m_Re = Ree;
		m_command = Command;
	}

	public override void Execute(){
		m_Re.Action (m_command);
	}

}

public class ReOrNoRe2:ReOrNoRe{
	NoRE m_NoRE = null;
	int m_Param = 0;

	public ReOrNoRe2(NoRE Ree,int Param){
		m_NoRE = Ree;
		m_Param=Param;
	}

	public override void Execute(){
		m_NoRE.Action (m_Param);
	}

}


//使用ＬＩＳＴ來儲存命令，當執行時候一次執行所有命令，並清空
public class Invokera{

	List<ReOrNoRe> m_ReOrNoRe =new List<ReOrNoRe>();

	//AddCommand

	public void AddCommand(ReOrNoRe theReOrNoRe){
		m_ReOrNoRe.Add (theReOrNoRe);
	}

	//start Command
	public void ExecuteReOrNoRe(){
		foreach (ReOrNoRe theReOrNoRe in m_ReOrNoRe)
			theReOrNoRe.Execute ();
		m_ReOrNoRe.Clear ();
	}

}