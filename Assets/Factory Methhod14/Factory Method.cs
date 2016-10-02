using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//當產生類別有下列情況建議使用工廠方法實作
//需要複雜流程
//需要載入外部資源ＥＸ：網路、資料庫等等
//有物件上限
//可重複使用


public class FactoryMethod  {

	//定義：
	//定義一個物件的界面，但是讓子類別決定要生產什麼類別物件。工廠模式讓類別實例化程序延遲到子類別實行

}

public abstract class Creator{
	//子類別回傳對應Product形態
	public abstract Product FacetoryMethod ();

}

public abstract class Product{
	//都是我的子類別ＡＡ和ＢＢ

}
	

public class ConcreteProductAA:Product{
	public ConcreteProductAA(){
		Debug.Log("生成產品AA");
	}
}

public class ConcreteProductBB:Product{
	public ConcreteProductBB(){
		Debug.Log("生成產品BB");
	}
}

//生產工廠Ａ和Ｂ

public class ConcreteCreatProductA:Creator{
	public ConcreteCreatProductA(){
		Debug.Log ("I'm FacetoryA");
	}

	public override Product FacetoryMethod(){
		return new ConcreteProductAA ();
	}
}


public class ConcreteCreatProductB:Creator{
	public ConcreteCreatProductB(){
		Debug.Log ("I'm FacetoryB");
	}

	public override Product FacetoryMethod(){
		return new ConcreteProductBB ();
	}
}




//Three Founction 

//跟第一個實作比起來可省去繼承實作方式
//改用Ｔ類別型別
//
//另外使用這句語法來限定Ｔ類別，只能是Product群組內的類別
//public class Creator_GenericClass<T> where T:Product
 

public class Creator_GenericClass<T> where T:Product,new(){
	public Creator_GenericClass(){
		Debug.Log ("Product Facetory:Creator_GenericClass"+typeof(T).ToString());
	}
	public Product FactoryMethod(){
		return new T ();
	}
}

//第四種方式
//因為泛型不使用繼承，所以客戶端無法取得工廠屆面
//若需要工廠屆面，可改用泛型方法
interface Creatory_GenericMethod{
	Product FactoryMethod<T>() where T:Product,new();
}

//重新實作Facetory Method 以回傳Product物件
public class ConcreteCreator_GenericMethod:Creatory_GenericMethod{
	public ConcreteCreator_GenericMethod(){
		Debug.Log ("Product Facetory:ConcreteCreator_GenericMethod");
	}

	public Product FactoryMethod<T> () where T:Product, new(){
		return new T();
	}
}
//用interface 宣告一個介面，必定意FactoryMethod<T>
//客戶端可指定要生產Ｔ類別，實作類別就會將Ｔ類別物件稱生並回傳
//Ｔ類別在宣告時候，必須指定為Product類別，並能使用new方式產生出來