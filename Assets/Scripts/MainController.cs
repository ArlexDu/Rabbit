using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

	private bool startcombine = true;
	private bool stopcombine = false;
	private bool recovery = false;
	private bool showcompoents = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 1, 0);
		if (startcombine) {
			StartCoroutine ("stopCombine");
		}
		if (stopcombine){
			StartCoroutine("Recovery");
		}
		if (recovery) {
			StartCoroutine ("showCompoents");
		}
		if (showcompoents){
			StartCoroutine("startCombine");
		}
	}

	// 完成模型旋转
	IEnumerator stopCombine(){
		startcombine = false;
		yield return new WaitForSeconds (1);
		foreach (Transform child in transform) {
			if (child.gameObject.name == "rabbit") {
				child.gameObject.SetActive (true);
				continue;
			}
			child.gameObject.GetComponent<Move> ().Stop();
			child.gameObject.SetActive (false);
		}
		stopcombine = true;
	}

	//各个部分爆炸效果
	IEnumerator Recovery(){
		stopcombine = false;
		yield return new WaitForSeconds (3);
		foreach (Transform child in transform) {
			if (child.gameObject.name == "rabbit") {
				child.gameObject.SetActive (false);
				continue;
			}
			child.gameObject.GetComponent<Move> ().Recovery();
			child.gameObject.SetActive (true);
		}
		recovery = true;
	}

	//各个部分静止旋转效果
	IEnumerator showCompoents(){
		recovery = false;
		yield return new WaitForSeconds (1);
		foreach (Transform child in transform) {
			if (child.gameObject.name == "rabbit") {
				continue;
			}
			child.gameObject.GetComponent<Move> ().Stop();
		}
		showcompoents = true;
	}
	//各个部分合并旋转效果
	IEnumerator startCombine(){
		showcompoents = false;
		yield return new WaitForSeconds (1);
		foreach (Transform child in transform) {
			if (child.gameObject.name == "rabbit") {
				continue;
			}
			child.gameObject.GetComponent<Move> ().Restart();
		}
		startcombine = true;
	}
}
