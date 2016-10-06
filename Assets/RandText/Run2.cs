using UnityEngine;
using System.Collections;

public class Run2 : MonoBehaviour {
	int Row,endRow,stepRow;
	int Col,endCol,stepCol;
	public Transform MonPos;
	public Transform PeoPos;
	int NextRow,NextCol;
	int a,b;
	int deltaCol,deltaRow;

	int currentStep,KMaxPartLength,pathRowTager,pathColTarger;
	int[] pathRow,PathCol;
	// Use this for initialization
	void Start () {
		GetPosRun ();
		deltaRow= endRow - Row;
		deltaCol = endCol - Col;
	}
	
	// Update is called once per frame
	void Update () {
		if (deltaCol < 0)
			stepCol = -1;
		else
			stepCol = 1;
		if (deltaRow < 0)
			stepRow = -1;
		else
			stepRow = 1;
		deltaCol = Mathf.Abs (deltaCol * 2);
		deltaRow = Mathf.Abs (deltaRow * 2);
		currentStep++;
	}

	void GetPosRun(){
		for(currentStep=0;currentStep<KMaxPartLength;currentStep++){
			pathRow[currentStep]=-1;
			PathCol[currentStep]=-1;
		}
		currentStep=0;
		pathRowTager=endRow;
		pathColTarger=endCol;
	}

	void Bresenham(){
		int fraction;
		if (deltaCol > deltaRow) {
			fraction = deltaRow * 2 - deltaCol;
		
			while (NextCol != endCol) {
				if (fraction >= 0) {
					NextRow = NextRow + stepRow;
					fraction = fraction - deltaCol;
				}
				NextCol = NextCol - stepCol;
				fraction = fraction - deltaRow;
				pathRow [currentStep] = NextRow;
				PathCol [currentStep] = NextCol;
				currentStep++;

			}
		} else {
			fraction = deltaCol * 2 - deltaRow;

			while (NextRow !=endRow) {
				if (fraction >= 0) {
					NextCol = NextCol + stepCol;
					fraction = fraction - deltaRow;
				}
				NextRow = NextRow - stepRow;
				fraction = fraction - deltaCol;
				pathRow [currentStep] = NextRow;
				PathCol [currentStep] = NextCol;
				currentStep++;
			}
		}
	}
}
