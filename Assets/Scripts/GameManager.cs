using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gameSpeed = 2F;
    public float pipeDistance = 4.8F;

    public GameObject gameOverText;
    public Text score;

    public void Replay()
    {
        SceneManager.LoadScene(0);
    }
	
	public void GameOver()
    {
        gameOverText.SetActive(true);

        //var activeBird = GameObject.Find("bird");

        //activeBird.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void IncrementScore()
    {
        var numText = score.text.Replace("Score : 0", "");
        var num = int.Parse(numText);
        score.text = $"Score : {++num}";
    }
}
