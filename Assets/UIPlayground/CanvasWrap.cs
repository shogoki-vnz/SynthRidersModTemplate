using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UIPlayground.test {
	public class CanvasWrap : MonoBehaviour {

		public static CanvasWrap s_instance;

		public GameObject m_canvasWrap;

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
		}

		void Start() {
			if(s_instance == null) { return; }

			m_canvasWrap.SetActive(false);			
		}	

		public static void ShowMe() {
			if(!s_instance) { return; }

			s_instance.m_canvasWrap.SetActive(true);
		}

		public static void HideMe() {
			if(!s_instance) { return; }

			s_instance.m_canvasWrap.SetActive(false);
		}

		public static void DestroyMe() {
			if(s_instance == null) { return; }

			Destroy(s_instance);
		}

		public static void InitCanvasVRTK() {
			if(!s_instance.canvasSet && s_instance.setUICanvasCallback != null) {
				s_instance.canvasSet = true;
				s_instance.setUICanvasCallback(s_instance.gameObject.GetComponentInChildren<Canvas>().gameObject);
			}
		}
	}
}