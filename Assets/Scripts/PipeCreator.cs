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
        var scales = CreateScales();

        var newPipeUp = Instantiate(pipeUp, pipe1Pos, Quaternion.identity);
        var newPipeDown = Instantiate(pipeDown, pipe2Pos, Quaternion.identity);

        newPipeUp.SetActive(true);
        newPipeDown.SetActive(true);

        newPipeUp.transform.localScale = new Vector3(1, scales.Item1, 1);
        newPipeDown.transform.localScale = new Vector3(1, scales.Item2, 1);

        var countToShow = scoreCount == -1 ? 0 : scoreCount;
        scoreTxt.text = $"Score : { countToShow }";

        if (scoreCount == 20)
        {
			var manager = GameObject.Find("Manager");

            var script = manager.GetComponent<GameManager>();
            
            script.Success();
        }
    }

    private (float, float) CreateScales()
    {
        float scale1, scale2;
        float difference;

        do
        {
            scale1 = Random.Range(0.4F, 1.8F);
            scale2 = Random.Range(0.4F, 1.8F);

            difference = Mathf.Abs(scale1 - scale2);

            print(difference);

        } while (difference < 0.32F);

        return (scale1, scale2);
    }
}
