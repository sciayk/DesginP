using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class IAState  {

//	ICharacterAI               <-    IAState
//	    繼承      						繼承
//	SoldierAI    EnemAI              個別ＡＩ設定





	//優點：
	//1.減少維護困難度和減少錯誤發生 。 不使用　　Switch case 來實作可避免沒檢查到所造成的錯誤
	//2.環境單純化 。 所有有關ＡＩ參數和物件都在ＡＩ類別下。所以可以清楚瞭解到每一個狀態執行狀況。與其他類別所使用物件分開也可以減少設定錯誤機會
	//
	//面對變化時候：
	//新增新類別繼承IAState
	//
	//總結：
	//與其他模式配合， ＥＸ：使用Bridge來負責產生物件角色，角色生產需要設定使用ＡＩ類別狀態
	//
	//其他應用方式：
	//ＲＰＧ中遭到法術命中會出現特殊狀態ＥＸ：冰凍、暈眩、變身



	protected ICharacterAI m_characterAI = null; // 角色ＡＩ設定


	//設定ＡＩ對像
	public void SetCharacterAI(ICharacterAI CharacterAI){
		m_characterAI = CharacterAI;
	}

	//設定攻擊目標
	public virtual void SetAttackPosition(Vector3 AttackPosition){
		
	}

	//更新
	public abstract void Update(List<ICharacterAI> Target);

	//目標移除

	public virtual void RemoveTargets (ICharacterAI Target){
		
	}


}

public class IderAIState:IAState{
	public override void Update(List<ICharacterAI>Target){
		//是否有目標 根據目標做什麼決定
	}
}

public class AttackAIState:IAState{
	//攻擊ＡＩ設定
	public override void Update(List<ICharacterAI>Target){
		//該怎麼攻擊
	}
}
//後面省略
	
