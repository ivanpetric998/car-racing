using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    DataController dataController;
    
    void Awake () 
    {
        SetUpSingleton();
        audioSource = gameObject.GetComponent<AudioSource>(); 
        dataController=FindObjectOfType<DataController>();
	}
	
    private void SetUpSingleton()
    {
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if(GameManager.instance.gameOver)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        audioSource.volume=dataController.GetVolume();
    }

}
