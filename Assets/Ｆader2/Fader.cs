﻿using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {


//	定義一個最高的權限
//	只需要按一個東西，就能自動執行所有需要功能
//	ＥＸ：採車子油門
//	冷卻裝置、加速器、等等等等都不需要控制，使用者只需要踩油門就可以
//
//
//	可減少客戶端與需要互動系統的數量
//
//	優點：可將功能單純化。讓此功能只需要負責該功能，不需要去初始化與呼叫動作
//
//	減少系統耦合度有助於減少系統建置時間
//
//	容易分工：其他開發者只需要知道我給什麼他最後會給我什麼，不需要去理解內部操作
//
//	注意事項：所有系統都集中在ＦＡＣＡＤＥ時後會導致太大難以維護
//
//	可以重購介面類別，將功能相近整合，以減少內部依賴近
//
//	應用方式：
//	網路通訊，連線管理，訊息事件，封包 等等
//	ＳＱＬ ：讓非資料庫人員也能使用
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
