using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour {

	public VideoPlayer videoPlayer;
    
	public void TogglePlay() {
		if(videoPlayer.isPlaying) {
			videoPlayer.Pause();
		} else {
			videoPlayer.Play();
		}
	}
}
