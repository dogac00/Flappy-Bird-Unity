using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
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

        var script = mainCamera.GetComponent<CameraScript>();
        script.speed = 2;
        PipeCreator.scoreCount = 0;
        EventSystem.current.SetSelectedGameObject(null);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
