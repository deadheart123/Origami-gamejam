using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrigamiCollectable : MonoBehaviour
{
    [SerializeField] private GameObject confetti;
    [SerializeField] private float bounceTime = 1f;
    [SerializeField] private int loadSceneIndex;

    private void OnEnable()
    {
        CollectableManager.Instance.collectablesInScene.Add(this);
        LeanTween.moveY(this.gameObject, this.transform.position.y - 2f, bounceTime).setLoopPingPong();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            /*Instantiate(confetti, this.transform.position, Quaternion.identity);
            CollectableManager.Instance.GetCollectable();
            this.gameObject.SetActive(false);*/
            AudioEventSystem.TriggerEvent("OrigamiCollected", this.gameObject);
            AudioEventSystem.TriggerEvent("StopGameMusic", this.gameObject); //Multiple music starts playing when origarmi collected, so whacked this in here, for now
            // Teleport to new level
            SceneManager.LoadScene(loadSceneIndex);
        }
    }
}
