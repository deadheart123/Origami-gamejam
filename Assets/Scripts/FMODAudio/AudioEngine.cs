using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEngine : MonoBehaviour
{
    [SerializeField] private FmodEventReferences fmodEventReferences;
    [SerializeField] private FmodParameters fmodParameters;
    private int origamiCollected = 0;
    

    void Start()
    {
        StartGameMusic(this.gameObject);
       
    }
    //Start listening for events
    void OnEnable()
    {

        AudioEventSystem.StartListening("StartGameMusic", StartGameMusic);
        AudioEventSystem.StartListening("StopGameMusic", StopGameMusic);
        AudioEventSystem.StartListening("PlayerJump", PlayerJump);
        AudioEventSystem.StartListening("OrigamiCollected", OrigamiCollected);
        AudioEventSystem.StartListening("TrampolineBounce", TrampolineBounce);
        AudioEventSystem.StartListening("RainDrop", RainDrop);
        AudioEventSystem.StartListening("RainDropHitPlayer", RainDropHitPlayer);
        AudioEventSystem.StartListening("StartFireStream", StartFireStream);
        AudioEventSystem.StartListening("StopFireStream", StopFireStream);
        AudioEventSystem.StartListening("PlayerDisintegrated", PlayerDisintegrated);


    }

    //Disable listeners for events (key for avoiding data leaks)
    void OnDisable()
    {

        AudioEventSystem.StopListening("StartGameMusic", StartGameMusic);
        AudioEventSystem.StopListening("StopGameMusic", StopGameMusic);
        AudioEventSystem.StopListening("PlayerJump", PlayerJump);
        AudioEventSystem.StopListening("OrigamiCollected", OrigamiCollected);
        AudioEventSystem.StopListening("TrampolineBounce", TrampolineBounce);
        AudioEventSystem.StopListening("RainDrop", RainDrop);
        AudioEventSystem.StopListening("RainDropHitPlayer", RainDropHitPlayer);
        AudioEventSystem.StopListening("StartFireStream", StartFireStream);
        AudioEventSystem.StopListening("StopFireStream", StopFireStream);
        AudioEventSystem.StopListening("PlayerDisintegrated", PlayerDisintegrated);

    }

    //Creates instance of music looping fmod event and then starts it
    private void StartGameMusic(GameObject triggerObject)
    {
        fmodEventReferences.MusicInstance();
        fmodEventReferences.musicInstance.start();
    }

    //Stops game music looping fmod event (with fade out) and releases it from memory
    private void StopGameMusic(GameObject triggerObject)
    {
        fmodEventReferences.musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        fmodEventReferences.musicInstance.release();
    }

    private void PlayerJump(GameObject triggerObject)
    {
        fmodEventReferences.PlayerJumpInstance();
        fmodEventReferences.playerJumpEventInstance.start();
        fmodEventReferences.playerJumpEventInstance.release();
    }

    private void OrigamiCollected(GameObject triggerObject)
    {
        fmodEventReferences.OrigamiCollectedInstance();
        fmodEventReferences.origamiCollectedInstance.start();
        fmodEventReferences.origamiCollectedInstance.release();
        origamiCollected = origamiCollected + 1;
        fmodParameters.SetParamByName<int>(fmodEventReferences.musicInstance, "OrigamiCollected", origamiCollected);
        Debug.Log("Origami" + origamiCollected);
    }

    private void TrampolineBounce(GameObject triggerObject)
    {
        fmodEventReferences.TrampolineBounceInstance();
        fmodEventReferences.trampolineBounceInstance.start();
        fmodEventReferences.trampolineBounceInstance.release();
    }

    private void RainDrop(GameObject triggerObject)
    {

        fmodEventReferences.RainDropInstance();
        fmodEventReferences.rainDropEventInstance.start();
        fmodEventReferences.rainDropEventInstance.release();
    }

    private void RainDropHitPlayer(GameObject triggerObject)
    {
        fmodEventReferences.RainHitPlayerInstance();
        fmodEventReferences.rainHitPlayerEventInstance.start();
        fmodEventReferences.rainHitPlayerEventInstance.release();
    }

    private void StartFireStream(GameObject triggerObject)
    {
        fmodEventReferences.FireStreamInstance();
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(fmodEventReferences.fireStreamInstance, triggerObject.GetComponent<Transform>(), triggerObject.GetComponent<Rigidbody>());
        fmodEventReferences.fireStreamInstance.start();
    }

    private void StopFireStream(GameObject triggerObject)
    {
        fmodEventReferences.fireStreamInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        fmodEventReferences.fireStreamInstance.release();
    }

    private void PlayerDisintegrated(GameObject triggerObject)
    {
        fmodEventReferences.PlayerDisintegratedInstance();
        fmodEventReferences.playerDisintegratedEventInstance.start();
        fmodEventReferences.playerDisintegratedEventInstance.release();
    }

}
