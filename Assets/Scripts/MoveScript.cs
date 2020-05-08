using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * Move.speed;
    }
}
