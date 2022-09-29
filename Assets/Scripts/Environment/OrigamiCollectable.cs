using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrigamiCollectable : MonoBehaviour
{
    [SerializeField] private GameObject confetti;
    [SerializeField] private float bounceTime = 1f;

    [SerializeField] private GameObject mainArea;
    [SerializeField] private GameObject loadArea;

    private void OnEnable()
    {
        LeanTween.moveY(this.gameObject, this.transform.position.y - 2f, bounceTime).setLoopPingPong();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(confetti, this.transform.position, Quaternion.identity);
            AudioEventSystem.TriggerEvent("OrigamiCollected", this.gameObject);
            AudioEventSystem.TriggerEvent("StopGameMusic", this.gameObject); //Multiple music starts playing when origarmi collected, so whacked this in here, for now

            loadArea.SetActive(true);
            loadArea.GetComponent<Area>().LoadSubArea();

            mainArea.SetActive(false);
        }
    }
}
