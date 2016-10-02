using UnityEngine;
using System.Collections;


//這範例讓命令模式在實作上彈性很大，也出現很多變化形式，所以在實作分析時候，可以注重在命令物件的操作行為來加以分析
//題目：分析復原以及取消復原這兩個動作   提示：將請求功能加以記錄（封裝），再下達復原指令時候，把原本動作取消，而取消動作本身需參考到該動作執行甚麼行為。
public class CommandText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		Invoker theInvoker = new Invoker ();

		Command theCommand = null;

		theCommand = new ConcreteCommand1 (new Receiver1 (), "Hellow");
		theInvoker.AddCommand (theCommand);


		theCommand = new ConcreteCommand2 (new Receiver2 (), 66666);
		theInvoker.AddCommand (theCommand);

		theInvoker.ExecuteCommand ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
