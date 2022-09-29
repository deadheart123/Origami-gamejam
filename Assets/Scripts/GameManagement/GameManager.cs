using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    void Update()
    {
        if (playerData.playerDead)
        {
            ReloadScene();
        }
    }
    // Start is called before the first frame update
    void ReloadScene()
    {
        AudioEventSystem.TriggerEvent("StopGameMusic", this.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

   
}
