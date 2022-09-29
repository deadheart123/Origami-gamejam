using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Animal
{
    CRANE,
    SNAKE,
    RAT,
}

public enum CollectableType
{
    COLLECTABLE,
    RETURN,
}

public class OrigamiCollectable : MonoBehaviour
{
    [SerializeField] private GameObject confetti;
    [SerializeField] private float bounceTime = 1f;
    public Animal animal;
    public CollectableType collectableType;

    private void Start()
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
            
            if(collectableType == CollectableType.COLLECTABLE)
            {
                CollectableManager.Instance.GetCollectable(animal);
            }
            else if(collectableType == CollectableType.RETURN)
            {
                AreaManager.Instance.LoadArea(0);
            }
            this.gameObject.SetActive(false);
        }
    }
}
