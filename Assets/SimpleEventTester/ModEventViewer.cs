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

	private Action<int, int, int> playCallback;
	private Action gameOverCallback;
	public static bool CanLoadSongs { get; set; }

    public static Action<int, int, int> PlayCallback
    {
        get
        {
            return s_instance.playCallback;
        }

        set
        {
            s_instance.playCallback = value;
        }
    }

    public static Action GameOverCallback
    {
        get
        {
            return s_instance.gameOverCallback;
        }

        set
        {
            s_instance.gameOverCallback = value;
        }
    }

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

	void LateUpdate() {
		if(PlayCallback != null) { 
			if(Input.GetKeyDown(KeyCode.R)) {
				PlayCallback(UnityEngine.Random.Range(0, 16), UnityEngine.Random.Range(0, 6), UnityEngine.Random.Range(0, 4));
			}
		}

		if(GameOverCallback != null) {
			if(Input.GetKeyDown(KeyCode.X)) {
				GameOverCallback();
			}
		}
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
