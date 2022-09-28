using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is where string references to all the event instances will go and instances will be initialized

[CreateAssetMenu(menuName = "SO/Audio/Events", fileName = "New Event Reference Sheet")]
public class FmodEventReferences : ScriptableObject
{
    //Setting inspector heading
    [Header("Non-Diagetic Audio")]
    //Declaring music instance and event string
    [SerializeField] private string musicEventName = null;
    public FMOD.Studio.EventInstance musicInstance;
    public FMODUnity.EventReference musicFmodEvent;


    //Setting inspector heading
    [Header("Player Audio")]
    [SerializeField] private string playerJumpEventName = null;
    public FMOD.Studio.EventInstance playerJumpEventInstance;

    public void MusicInstance()
    {
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(musicFmodEvent);
        Debug.Log(musicEventName);
    }

    public void PlayerJumpInstance()
    {
        playerJumpEventInstance = FMODUnity.RuntimeManager.CreateInstance("event:/" + playerJumpEventName);
        Debug.Log(playerJumpEventName);
    }

}