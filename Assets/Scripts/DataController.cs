using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.IO;
using System.Collections.Generic;
public class DataController : MonoBehaviour
{
    private PlayerScoore playerScoore;
    private SoundVolume soundVolume;
    void Start()
    {        
        LoadPlayerScoore();
        LoadSoundVolume();
    }

    private void LoadSoundVolume()
    {
        soundVolume=new SoundVolume();
        if(PlayerPrefs.HasKey("volume"))
        {
            soundVolume.volume = PlayerPrefs.GetFloat("volume");
        }
    }

    public void SetVolume(float vol)
    {
        soundVolume.volume=vol;
        PlayerPrefs.SetFloat("volume", soundVolume.volume);
    }

    public float GetVolume()
    {
        return soundVolume.volume;
    }
    public void SubmitNewPlayerScore(int newScore)
    {
        if(newScore > playerScoore.highestScore)
        {
            playerScoore.highestScore = newScore;
            SavePlayerScoore();
        }
    }

    public int GetHighestPlayerScore()
    {
        return playerScoore.highestScore;
    }

    private void LoadPlayerScoore()
    {
        playerScoore = new PlayerScoore();
        if(PlayerPrefs.HasKey("highestScore"))
        {
            playerScoore.highestScore = PlayerPrefs.GetInt("highestScore");
        }
    }

    private void SavePlayerScoore()
    {
        PlayerPrefs.SetInt("highestScore", playerScoore.highestScore);
    }
}
