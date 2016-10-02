using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//	創造者模式
//
//	工廠是將生產地點集中管理
//	但是如何在生產物件過程中，更有效率、彈性需配合其他模式
//
//	創造者模式就是常使用來搭配的其中之一
//
//	定義：將一個複雜物件的流程，與他的物件表現分離出來，讓相同的建構流程可以產生不同物件行為表現
//	ＥＸ：同一種車有兩台，在兩台裝上不一樣的引擎他們速度就會不一樣
//	     一樣的安裝流程其中一個流程放的東西不一樣，而最後有不同的表現行為
//
//	＊把握這兩個原則
//	流程分析安排
//	功能分開實作

public abstract class Builder  {

	public abstract void BuildPart1 (BuilderProduct theProduct);
	public abstract void BuildPart2 (BuilderProduct theProduct);
}

public class ConcreteBuilderA:Builder  {

	public override void BuildPart1 (BuilderProduct theProduct){
		theProduct.AddPart ("ConcreteBuilderA_P1");
	}
	public override void BuildPart2 (BuilderProduct theProduct){
		theProduct.AddPart ("ConcreteBuilderA_P2");
	}
}

public class ConcreteBuilderB:Builder  {

	public override void BuildPart1 (BuilderProduct theProduct){
		theProduct.AddPart ("ConcreteBuilderB_P1");
	}
	public override void BuildPart2 (BuilderProduct theProduct){
		theProduct.AddPart ("ConcreteBuilderB_P2");
	}
}

public class BuilderProduct{
	private List<string> m_Part = new List<string> ();
	public BuilderProduct(){
	}

	public void AddPart(string Part){
		m_Part.Add (Part);
	}

	public void ShowProduct(){
		foreach (string Part in m_Part)
			Debug.Log (Part);
	}
}

//建造指示者
public class Director{
	private BuilderProduct m_Produce;
	public Director(){
	}
		//建立
	public void Construct(Builder theBuilder){
		m_Produce=new BuilderProduct();
		theBuilder.BuildPart1 (m_Produce);
		theBuilder.BuildPart2 (m_Produce);
	}
	//結果
	public BuilderProduct GetResult(){
		return m_Produce;
		}
}




