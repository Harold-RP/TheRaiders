using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void LoadScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(AudioManager.instance.playingBgmNo < AudioManager.instance.bgmList.Count-1)
            {
                AudioManager.instance.playingBgmNo++;
                AudioManager.instance.SetMusic(AudioManager.instance.bgmList[AudioManager.instance.playingBgmNo]);
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
