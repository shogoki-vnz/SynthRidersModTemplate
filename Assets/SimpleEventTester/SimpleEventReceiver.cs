using UnityEngine;
using System.Collections;
using UMod;
using Synth.mods;

public class SimpleEventReceiver : ModScript, ISynthRidersEvents {

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
        ModEventViewer.PrintToLog("You are in the room.");
    }

    /// <summary>
    /// Called when the Room Scene is unloaded
    /// </summary>
    public void OnRoomUnLoaded()
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
        ModEventViewer.PrintToLog("is a custom song "+trackData.isCustomSong);
        ModEventViewer.PrintToLog("Song "+trackData.name+" by "+trackData.artist);
        ModEventViewer.PrintToLog("You are in the Game Stage");
    }

    /// <summary>
    /// Called when the song stage is unloaded
    /// </summary>
    public void OnGameStageUnLoaded()
    {
        ModEventViewer.PrintToLog("Game Stage Unloaded");
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
        ModEventViewer.PrintToLog("Finished "+songFinishedData.songData.name);
    }

    /// <summary>
    /// Called when the song is failed
    /// Receive a TrackData struct
    /// </summary>
    public void OnSongFailed(TrackData trackData)
    {
        ModEventViewer.PrintToLog("The song "+trackData.name+" was failed");
    }
}
