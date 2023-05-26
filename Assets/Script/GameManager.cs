using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public GameObject frontPage;
       private int score;

       public AudioSource audioSource; // Reference to the AudioSource component
    public AudioClip bg; 

    private void Awake()
    {
        ShowFrontPage();
        Application.targetFrameRate= 60;
        Pause();
        
        

    }

    
    public void Play () {
        score = 0;
        scoreText.text =score.ToString();
        
        frontPage.SetActive(false);
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale =1f;
        player.enabled =true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        }

         audioSource.PlayOneShot(bg);
    }

    public void ShowFrontPage()
{
    frontPage.SetActive(true);
   
}



    public void Pause () {
         player.enabled = false;
        Time.timeScale = 0f;
       
    }

    public void GameOver () {

        player.enabled = false;
        Time.timeScale = 0f;
        gameOver.SetActive(true);
        playButton.SetActive(true);
    }
    
    public void IncScore(){
        score++;
        scoreText.text = score.ToString();
    }
}
