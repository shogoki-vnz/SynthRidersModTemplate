using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMod;
using Synth.mods.events;
using Synth.mods.utils;
using Synth.mods.interactions;
using System;

namespace UIPlayground.test {
    public class UIPlayground : ModScript, ISynthRidersEvents, ISynthRidersInteractions {

        public override void OnModLoaded()
        {
            var canvasWrapper = ModAssets.Instantiate<GameObject>("CanvasWrap");
            CanvasWrap.HideMe();
        }

        public override void OnModUnload() {	
            CanvasWrap.DestroyMe();
        }

        public void OnRoomLoaded()
        {
             CanvasWrap.ShowMe();
        }

        public void OnRoomUnloaded()
        {
            CanvasWrap.HideMe();
        }

        public void OnGameStageLoaded(TrackData trackData)
        {
            //
        }

        public void OnGameStageUnloaded()
        {
            //
        }

        public void OnScoreStageLoaded()
        {
            //
        }

        public void OnScoreStageUnloaded()
        {
            //
        }

        public void OnPointScored(PointsData pointsData)
        {
            //
        }

        public void OnNoteFail(PointsData pointsData)
        {
        //
        }

        public void OnSongFinished(SongFinishedData songFinishedData)
        {
            //
        }

        public void OnSongFailed(TrackData trackData)
        {
            //
        }

        public void SetUICanvasCallback(Action<GameObject> callback)
        {
            CanvasWrap.SetUICanvasCallback = callback;
            CanvasWrap.InitCanvasVRTK();
        }

        public void SetGameOverCallback(Action callback)
        {
            //
        }

        public void SetPlayTrackCallback(Action<int, int, int> callback)
        {
            //
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
}