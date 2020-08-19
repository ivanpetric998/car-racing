using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; 
    public GameObject gameOverPanel; 
    public bool gameOver = false;
    private int score = 0; 
    [SerializeField] private Text scoreText;
    [SerializeField] private Text finishScoreText;
    [SerializeField] private Text highScoreText;
    DataController dataController;
  
    void Awake() 
    {
        if(instance == null) 
        { 
            instance = this;
        }
        dataController=gameObject.GetComponent<DataController>();
    }
    public int GetScoore()
    {
        return score;
    }
    public void GameOver() 
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        dataController.SubmitNewPlayerScore(score);
        this.finishScoreText.text=this.score.ToString();
        this.highScoreText.text = this.dataController.GetHighestPlayerScore().ToString();
    }
    public void Retry() 
    {
        SceneManager.LoadScene("Game");
    }
    public void MainMenu() 
    {
        SceneManager.LoadScene("MainMenu"); 
    }
    public void IncrementScore(int brojPoena) 
    {
        this.score += brojPoena;
        this.scoreText.text = this.score.ToString();
    }

}
