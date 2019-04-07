using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class ModEventViewer : MonoBehaviour {

	public static ModEventViewer s_instance;

	public Transform m_loggerWrap;
	public Text m_loggerField; 
	private StringBuilder logSB;

	private Transform followerTransform;

	// Use this for initialization
	void Awake () {
		if(s_instance != null) {
			Destroy(this);
		}
		
		s_instance = this;
		DontDestroyOnLoad(this);
	}

	void Start() {
		if(s_instance == null) { return; }
		
		logSB = new StringBuilder();
		m_loggerField.text = string.Empty;
		m_loggerWrap.gameObject.SetActive(false);			
	}

	void FixedUpdate() {
		if(s_instance == null || followerTransform == null) { return; }
		
		m_loggerWrap.transform.position = followerTransform.position;
	}

	public static void ActivateLogViewer() {
		if(!s_instance) { return; }

		s_instance.m_loggerWrap.gameObject.SetActive(true);
	}

	public static void AnchorLogViewer() {
		if(s_instance == null) { return; }

		s_instance.m_loggerWrap.gameObject.SetActive(true);

		GameObject HeadsetFollower = GameObject.Find("HeadsetFollower");
		if(HeadsetFollower != null) {
			s_instance.followerTransform = HeadsetFollower.transform;
		}

		s_instance.logSB.Length = 0;
		// Set to 0 to clear memory
		s_instance.logSB.Capacity = 0;
		// Set to default capacity
		s_instance.logSB.Capacity = 16;
	}

	public static void PrintToLog(string message) {
		if(s_instance == null) { return; }

		s_instance.logSB.Insert(0, string.Format("{0}{1}",message, Environment.NewLine));
		s_instance.m_loggerField.text = s_instance.logSB.ToString();
	}

	public static void DestroyEventViewer() {
		if(s_instance == null) { return; }

		Destroy(s_instance);
	}
}
