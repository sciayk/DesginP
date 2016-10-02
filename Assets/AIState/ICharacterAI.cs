using UnityEngine;
using System.Collections;

public abstract class ICharacterAI  {

	protected ICharacterAI m_Character=null;

	protected ICharacterAI m_AI=null;
	protected IAState m_AIState = null; //角色ＡＩ狀態


	public ICharacterAI(ICharacterAI Character){
		m_Character = Character;

	}

	public virtual void ChangeAIState(IAState NewAIState){
		m_AIState = NewAIState;
		m_AIState.SetCharacterAI (this);
	}
}

public class SoldierAI:ICharacterAI{

	//設定初始ＡＩ
	public SoldierAI(ICharacterAI Character):base(Character){
		ChangeAIState(new IderAIState());
	}

}

public class EnemAI:ICharacterAI{
	
	public EnemAI(ICharacterAI Character):base(Character){
		ChangeAIState(new IderAIState());
	}

	public override void ChangeAIState(IAState NewAIState){
		ChangeAIState (NewAIState);
	}
}