using UnityEngine;
using System.Collections;



public abstract class Strategy {
	public abstract void AlogorithmInterface ();
}


// 設定所需要演算法
public class ContcreteSteategyA:Strategy{
	public override void AlogorithmInterface(){
		Debug.Log ("ContcreteSteategyA.AlogorithnInterface");
	}
}
public class ContcreteSteategyB:Strategy{
	public override void AlogorithmInterface(){
		Debug.Log ("ContcreteSteategyB.AlogorithnInterface");
	}
}
public class ContcreteSteategyC:Strategy{
	public override void AlogorithmInterface(){
		Debug.Log ("ContcreteSteategyC.AlogorithnInterface");
	}
}

//擁有Strategy的客戶端

public class  ConText{
	Strategy m_Strategy = null;

	public void SetStrategy(Strategy theStrategy){
		m_Strategy = theStrategy;
	}

	//執行演算法
	public void ContextInterface(){
		m_Strategy.AlogorithmInterface ();
	}
}