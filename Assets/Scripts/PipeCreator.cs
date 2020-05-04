using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PipeCreator : MonoBehaviour
{
    public GameObject pipeUp, pipeDown, bird;
    public static int scoreCount = -1;
    public Text scoreTxt;

    void OnTriggerEnter2D(Collider2D collider)
    {
        scoreCount++;

        var curPos = this.transform.position;
        var newPos = new Vector3(curPos.x + 5, curPos.y);
        Instantiate(this.gameObject, newPos, Quaternion.identity);

        var pipe1Pos = new Vector3(curPos.x + 5, 5);
        var pipe2Pos = new Vector3(curPos.x + 5, -5);
        var scaleY1 = Random.Range(0.4F, 1.8F);
        var scaleY2 = Random.Range(0.4F, 1.8F);

        var newPipeUp = Instantiate(pipeUp, pipe1Pos, Quaternion.identity);
        var newPipeDown = Instantiate(pipeDown, pipe2Pos, Quaternion.identity);

        newPipeUp.SetActive(true);
        newPipeDown.SetActive(true);

        newPipeUp.transform.localScale = new Vector3(1, scaleY1, 1);
        newPipeDown.transform.localScale = new Vector3(1, scaleY2, 1);

        scoreTxt.text = $"Score : { scoreCount }";

        if (scoreCount == 20)
        {
            var bird = GameObject.Find("bird");

            var script = bird.GetComponent<BirdScript>();
            
            script.Success();
        }
    }
}
