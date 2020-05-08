using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText, successText;
    public GameObject bird, pipeCreator;

    public void Replay()
    {
        var initialBirdPos = new Vector3(-6, 0, 0);
        var initialCameraPos = new Vector3(0, 0, -10);
        var pipeCreatorPos = new Vector3(initialBirdPos.x + 5, 0);

        foreach (var pc in GameObject.FindObjectsOfType<GameObject>())
            if (pc.name.StartsWith("PipeCreator"))
                Destroy(pc);
        foreach (var pipe in GameObject.FindObjectsOfType<GameObject>())
            if (pipe.name.StartsWith("pipe-up") || pipe.name.StartsWith("pipe-down"))
                Destroy(pipe);

        bird.transform.position = initialBirdPos;
        bird.SetActive(true);
        var gameOver = bird.GetComponent<BirdScript>().gameOverText;
        var success = bird.GetComponent<BirdScript>().successText;
        gameOver.SetActive(false);
        success.SetActive(false);
        var creator = Instantiate(pipeCreator, pipeCreatorPos, Quaternion.identity);
        creator.SetActive(true);
        creator.name = "PipeCreator";

        var mainCamera = Camera.main;
        mainCamera.transform.position = initialCameraPos;

        Move.speed = 2;
        PipeCreator.scoreCount = -1;
        EventSystem.current.SetSelectedGameObject(null);
    }
	
	public void GameOver()
    {
        Move.speed = 0;

        gameOverText.SetActive(true);

        var bird = GameObject.Find("bird");

        bird.SetActive(false);
    }
	
	public void Success()
    {
		foreach (var creator in GameObject.FindObjectsOfType<GameObject>())
			if (creator.name.StartsWith("PipeCreator"))
				Destroy(creator);

        Move.speed = 0;

        successText.SetActive(true);

        var bird = GameObject.Find("bird");
		
		bird.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
