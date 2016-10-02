using UnityEngine;
using System.Collections;

public static class UITool {
	
	//可查詢ＵＩ介面下的名稱
	private static GameObject m_CanvasObj=null;
	public static GameObject FindUIGameObject(string UIName){
		if (m_CanvasObj == null)
			m_CanvasObj = UnityTool.FindGameObject ("Canvas");
		if (m_CanvasObj == null)
			return null;
		return UnityTool.FindChildGameObject (m_CanvasObj, UIName);
	}
	public static T GetUIComponent<T>(GameObject Container,string UIName) where T: UnityEngine.Component{
		GameObject ChildGameObject=UnityTool.FindChildGameObject(Container,UIName);
		if(ChildGameObject ==null)
			return null;
		T temObj = ChildGameObject.GetComponent<T>();
		if(temObj == null){
			Debug.LogWarning("Part["+UIName+"]不是["+typeof(T)+"j");
			return null;
		}
		return temObj;
	}
}
public static class UnityTool{
	public static GameObject FindGameObject(string GameObjectName){
		GameObject pTmpGameObj = GameObject.Find (GameObjectName);
		if(pTmpGameObj==null){
			Debug.LogWarning ("場景找不到GameObject[" + GameObjectName + "]");
			return null;
			}
		return pTmpGameObj;
	}

	public static GameObject FindChildGameObject(GameObject Container,string gameobjectName){
		if(Container ==null){
			Debug.LogError ("NGUICustomTools.GetChild:Container=null");
			return null;
			}	

		Transform pGameObjectTF = null;

		if (Container.name == gameobjectName)
			pGameObjectTF = Container.transform;
		else {
			Transform[] allChildren = Container.transform.GetComponentsInChildren<Transform> ();
			foreach (Transform Child in allChildren) {
				if (Child.name == gameobjectName) {
					if (pGameObjectTF == null)
						pGameObjectTF = Child;
					else
						Debug.LogWarning ("Container[" + Container.name + "]下找出重複名稱[" + gameobjectName + "]");
				}
			}
		}
		if (pGameObjectTF == null) {
			Debug.LogError ("元件[" + Container.name + "]Find Child is no[" + gameobjectName + "]"); 
			return null;
		}
		return pGameObjectTF.gameObject;
	}
}
		