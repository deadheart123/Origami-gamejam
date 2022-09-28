using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrigamiCollectable : MonoBehaviour
{
    [SerializeField] private GameObject confetti;
    [SerializeField] private float bounceTime = 1f;

    private void OnEnable()
    {
        CollectableManager.Instance.collectablesInScene.Add(this);
        LeanTween.moveY(this.gameObject, this.transform.position.y - 2f, bounceTime).setLoopPingPong();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Instantiate(confetti, this.transform.position, Quaternion.identity);
            CollectableManager.Instance.GetCollectable();
            this.gameObject.SetActive(false);
        }
    }
}
