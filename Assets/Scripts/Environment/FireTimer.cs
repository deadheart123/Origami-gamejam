using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTimer : MonoBehaviour
{
    public ParticleSystem fireParticleSystem;
    public GameObject fireLight;
    [SerializeField] private float minTimeLength;
    [SerializeField] private float maxTimeLength;
    [SerializeField] private float minTimeStart;
    [SerializeField] private float maxTimeStart;

    private float lengthTimer;
    private float startTimer;

  
    void Start()
    {
        ResetLenghtTimer();
        ResetStartTimer();
        AudioEventSystem.TriggerEvent("StartFireStream", this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        lengthTimer = lengthTimer -= Time.deltaTime;
        

        if (lengthTimer <= 0)
        {
            //Stop fire
            fireParticleSystem.Stop();
            AudioEventSystem.TriggerEvent("StopFireStream", this.gameObject);
            fireLight.SetActive(false);
            startTimer = startTimer -= Time.deltaTime;
        }

        if (startTimer <= 0)
        {
            //startFire
            fireParticleSystem.Play();
            AudioEventSystem.TriggerEvent("StartFireStream", this.gameObject);
            fireLight.SetActive(true);
            ResetLenghtTimer();
            ResetStartTimer();
        }

    }

    void ResetLenghtTimer()
    {
        lengthTimer = Random.Range(minTimeLength, maxTimeLength);
       
    }

    void ResetStartTimer()
    {
        startTimer = Random.Range(minTimeStart, maxTimeStart);
    }
}
