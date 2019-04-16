using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
// using VRTK;

public class ComingSoonVisibleWrapper : MonoBehaviour {

	public static ComingSoonVisibleWrapper s_instance;

	public GameObject wrap;
	public VideoPlayer videoPlayer;
	public GameObject canvas;
	public Button button;

	private bool canvasSet = false;

	private Action<GameObject> setUICanvasCallback;

    public static Action<GameObject> SetUICanvasCallback
    {
        get
        {
            return s_instance.setUICanvasCallback;
        }

        set
        {
            s_instance.setUICanvasCallback = value;
        }
    }

    // Use this for initialization
    void Awake () {
		if(s_instance != null) {
			Destroy(this);
		}

		s_instance = this;
		DontDestroyOnLoad(this);
		// canvas.AddComponent<VRTK_UICanvas>();
		button.onClick.AddListener(TogglePlay);
		Hide();
	}

	public static void InitCanvasVRTK() {
		if(!s_instance.canvasSet && s_instance.setUICanvasCallback != null) {
			Debug.Log("To canvas name "+s_instance.canvas.name);
			s_instance.canvasSet = true;
			s_instance.setUICanvasCallback(s_instance.canvas);
		}
	}

	public static void Show() {
		if(s_instance == null) { return; }
		s_instance.wrap.SetActive(true);		
	}

	public static void Hide() {
		if(s_instance == null) { return; }
		s_instance.wrap.SetActive(false);
	}

	public void TogglePlay() {
		if(videoPlayer.isPlaying) {
			videoPlayer.Pause();
		} else {
			videoPlayer.Play();
		}
	}

	public static void Clear() {
		if(s_instance == null) { return; }
		GameObject.Destroy(s_instance);
	}
}
