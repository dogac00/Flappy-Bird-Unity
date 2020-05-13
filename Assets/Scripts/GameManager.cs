using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameSpeed = 2F;
    public float pipeDistance = 4.8F;

    public GameObject gameOverText;
    public Text score;
    public bool isGameOver;

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
	
	public void GameOver()
    {
        isGameOver = true;
        
        gameOverText.SetActive(true);

        var bird = GameObject.Find("bird");

        bird.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void IncrementScore()
    {
        var scoreNum = int.Parse(score.text);

        score.text = $"Score : {++scoreNum}";
    }
}
