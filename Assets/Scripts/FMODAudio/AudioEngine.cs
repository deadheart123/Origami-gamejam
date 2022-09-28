using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEngine : MonoBehaviour
{
    [SerializeField] private FmodEventReferences fmodEventReferences;

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


    }

    //Disable listeners for events (key for avoiding data leaks)
    void OnDisable()
    {

        AudioEventSystem.StopListening("StartGameMusic", StartGameMusic);
        AudioEventSystem.StopListening("StopGameMusic", StopGameMusic);
        AudioEventSystem.StopListening("PlayerJump", PlayerJump);

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
}
