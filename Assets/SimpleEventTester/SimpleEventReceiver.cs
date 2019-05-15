using UnityEngine;
using System.Collections;
using UMod;
using Synth.mods.utils;
using Synth.mods.events;
using Synth.mods.info;
using System.Collections.Generic;
using Synth.mods.interactions;
using System;

public class SimpleEventReceiver : ModScript, ISynthRidersEvents, ISynthRidersInfo, ISynthRidersInteractions {

	public override void OnModLoaded()
	{
        Debug.Log("Mod Loaded");
        GameObject eventViewer = ModAssets.Instantiate<GameObject>("ModEventViewer");
	}

    public override void OnModUnload() {		
		Debug.Log("Mod Unloaded");
        ModEventViewer.DestroyEventViewer();
	}

    /// <summary>
    /// Called when the Room Scene is loaded
    /// </summary>
    public void OnRoomLoaded()
    {
        ModEventViewer.AnchorLogViewer();
        ModEventViewer.PrintToLog("Key R play a random song OST");
        ModEventViewer.PrintToLog("You are in the room.");
    }

    /// <summary>
    /// Called when the Room Scene is unloaded
    /// </summary>
    public void OnRoomUnloaded()
    {
        ModEventViewer.PrintToLog("Room Unloaded");
    }

    /// <summary>
    /// Called when a song starge is loaded
    /// Receive a TrackData struct with info on the selected song
    /// </summary>
    public void OnGameStageLoaded(TrackData trackData)
    {
        ModEventViewer.AnchorLogViewer();
        ModEventViewer.PrintToLog("Key X to do GameOver");
        ModEventViewer.PrintToLog("is a custom song "+trackData.isCustomSong);
        ModEventViewer.PrintToLog("Song "+trackData.name+" by "+trackData.artist);
        ModEventViewer.PrintToLog("You are in the Game Stage");
    }

    /// <summary>
    /// Called when the song stage is unloaded
    /// </summary>
    public void OnGameStageUnloaded()
    {
        ModEventViewer.PrintToLog("Game Stage Unloaded");
        ModEventViewer.GameOverCallback = null;
    }	

    /// <summary>
    /// Called when the Score Stage is loaded
    /// </summary>
    public void OnScoreStageLoaded()
    {
        ModEventViewer.AnchorLogViewer();
        ModEventViewer.PrintToLog("You are in the Score Stage");
    }

    /// <summary>
    /// Called when the Score Stage is Unloaded
    /// </summary>
    public void OnScoreStageUnloaded()
    {
        ModEventViewer.PrintToLog("Score Stage Unloaded");
    }

    /// <summary>
    /// Called every time a note/wall is missed
    /// </summary>
    public void OnNoteFail(PointsData pointsData)
    {
        ModEventViewer.PrintToLog("A "+pointsData.noteType+" was failed");
    }

    /// <summary>
    /// Called every time a point is score
    /// Receive a PointsData struct with info on note/wall that give the poins
    /// </summary>
    public void OnPointScored(PointsData pointsData)
    {
        ModEventViewer.PrintToLog(pointsData.points+" points were scored!");
    }

    /// <summary>
    /// Called when the Song is finished
    /// Receive a SongFinished struct with info on the play data for that session
    /// </summary>
    public void OnSongFinished(SongFinishedData songFinishedData)
    {
        ModEventViewer.PrintToLog("Total points scored "+songFinishedData.points);
        ModEventViewer.PrintToLog("was perfect "+songFinishedData.wasPerfect);
        ModEventViewer.PrintToLog("Finished "+songFinishedData.trackData.name);
    }

    /// <summary>
    /// Called when the song is failed
    /// Receive a TrackData struct
    /// </summary>
    public void OnSongFailed(TrackData trackData)
    {
        ModEventViewer.PrintToLog("The song "+trackData.name+" was failed");
    }

    public void SetLoadedTracks(List<TrackData> tracks)
    {
        ModEventViewer.PrintToLog("There is a total of "+tracks.Count+" tracks installed");
        ModEventViewer.PrintToLog("Finding Songs...");
    }

    public void SetLoadedStages(List<StageData> stages)
    {
        ModEventViewer.PrintToLog("There is a total of "+stages.Count+" stages avalaible");
    }

    public void SetUserSelectedColors(Color leftHandColor, Color rightHandColor, Color oneHandSpecialColor, Color bothHandSpecialColor)
    {
        ModEventViewer.PrintToLog("both hand "+bothHandSpecialColor.ToString());
        ModEventViewer.PrintToLog("one hand "+oneHandSpecialColor.ToString());
        ModEventViewer.PrintToLog("right "+rightHandColor.ToString());
        ModEventViewer.PrintToLog("left "+leftHandColor.ToString());
        ModEventViewer.PrintToLog("Colors are:");
    }

    public void SetUICanvasCallback(Action<GameObject> callback)
    {
        // throw new NotImplementedException();
    }

    public void SetGameOverCallback(Action callback)
    {
        ModEventViewer.GameOverCallback = callback;
    }

    public void SetPlayTrackCallback(Action<int, int, int> callback)
    {
        ModEventViewer.PlayCallback = callback;
    }

    public void SetCurrentSongSelected(int CurrentSong)
    {
        throw new NotImplementedException();
    }

    public void SetRefreshCallback(Action callback)
    {
        throw new NotImplementedException();
    }

    public void SetSelectedTrackCallback(Action<int> callback)
    {
        throw new NotImplementedException();
    }

    public void SetFilterTrackCallback(Action<List<string>> callback)
    {
        throw new NotImplementedException();
    }
}
