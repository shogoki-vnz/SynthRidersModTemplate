using UnityEngine;
using System.Collections;
using UMod;
using Synth.mods.events;
using Synth.mods.utils;
using Synth.mods.interactions;
using System;
using System.Collections.Generic;

public class ComingSoonEventReceiver : ModScript, ISynthRidersEvents, ISynthRidersInteractions {

    private string PREFAB_NAME = "VideoWrap";
    GameObject trailersWrap; 

    public override void OnModLoaded()
	{
        Debug.Log("ComingSoon Mod Loaded");
        trailersWrap = ModAssets.Instantiate<GameObject>(PREFAB_NAME);
        trailersWrap.name = PREFAB_NAME;
	}

    public override void OnModUnload() {		
		Debug.Log("ComingSoon Mod Unloaded");
        ComingSoonVisibleWrapper.Clear();
	}

    /// <summary>
    /// Called when the Room Scene is loaded
    /// </summary>
    public void OnRoomLoaded()
    {
        Debug.Log("OnRoomLoaded ComingSoon");
        ComingSoonVisibleWrapper.Show();
    }

    /// <summary>
    /// Called when the Room Scene is unloaded
    /// </summary>
    public void OnRoomUnloaded()
    {
        Debug.Log("OnRoomUnLoaded ComingSoon");
        ComingSoonVisibleWrapper.Hide();
    }

    public void OnNoteFail(PointsData pointsData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnPointScored(PointsData pointsData)
    {
        //throw new System.NotImplementedException();
    }    

    public void OnGameStageLoaded(TrackData trackData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnScoreStageLoaded()
    {
        //throw new System.NotImplementedException();
    }

    public void OnScoreStageUnloaded()
    {
        //throw new System.NotImplementedException();
    }

    public void OnSongFailed(TrackData trackData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnSongFinished(SongFinishedData songFinishedData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnGameStageUnloaded()
    {
        throw new System.NotImplementedException();
    }

    public void SetUICanvasCallback(Action<GameObject> callback)
    {
        Debug.Log("SetUICanvasCallback load");
        ComingSoonVisibleWrapper.SetUICanvasCallback = callback;
        ComingSoonVisibleWrapper.InitCanvasVRTK();
    }

    public void SetGameOverCallback(Action callback)
    {
        //throw new NotImplementedException();
    }

    public void SetPlayTrackCallback(Action<int, int, int> callback)
    {
        //throw new NotImplementedException();
    }

    public void SetRefreshCallback(Action callback)
    {
        //throw new NotImplementedException();
    }

    public void SetSelectedTrackCallback(Action<int> callback)
    {
        //throw new NotImplementedException();
    }

    public void SetFilterTrackCallback(Action<List<string>> callback)
    {
        //throw new NotImplementedException();
    }

    public void SetRefreshCallback(Action<Action, bool> callback) {
        //throw new NotImplementedException();
    }

    public void SetFilterTrackCallback(Action<List<string>, Action, bool> callback) {
        //throw new NotImplementedException();
    }
}
