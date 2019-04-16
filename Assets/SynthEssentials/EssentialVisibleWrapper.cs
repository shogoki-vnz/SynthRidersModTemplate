using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialVisibleWrapper : MonoBehaviour {

	public static EssentialVisibleWrapper s_instance;

	public GameObject wrap;

	// Use this for initialization
	void Awake () {
		if(s_instance != null) {
			Destroy(this);
		}

		s_instance = this;
		DontDestroyOnLoad(this);
		Hide();
	}

	public static void Show() {
		if(s_instance == null) { return; }
		s_instance.wrap.SetActive(true);
	}

	public static void Hide() {
		if(s_instance == null) { return; }
		s_instance.wrap.SetActive(false);
	}

	public static void Clear() {
		if(s_instance == null) { return; }
		GameObject.Destroy(s_instance);
	}
}
