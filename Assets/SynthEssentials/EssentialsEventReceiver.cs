using UnityEngine;
using System.Collections;
using UMod;
using Synth.mods.events;
using Synth.mods.utils;

public class EssentialsEventReceiver : ModScript, ISynthRidersEvents {

    private string PREFAB_NAME = "SynthEssentialsWrap";
    GameObject essentialsWrap;
    

    public override void OnModLoaded()
	{
        Debug.Log("SynthEssentials Mod Loaded");
        essentialsWrap = ModAssets.Instantiate<GameObject>(PREFAB_NAME);
        essentialsWrap.name = PREFAB_NAME;
	}

    public override void OnModUnload() {		
		Debug.Log("SynthEssentials Mod Unloaded");
        EssentialVisibleWrapper.Clear();
	}

    /// <summary>
    /// Called when the Room Scene is loaded
    /// </summary>
    public void OnRoomLoaded()
    {
        Debug.Log("OnRoomLoaded SynthEssentials");
        EssentialVisibleWrapper.Show();
    }

    /// <summary>
    /// Called when the Room Scene is unloaded
    /// </summary>
    public void OnRoomUnloaded()
    {
        Debug.Log("OnRoomUnLoaded SynthEssentials");
        EssentialVisibleWrapper.Hide();
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

    public void OnGameStageUnloaded()
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
}
