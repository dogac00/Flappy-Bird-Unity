using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public float speed = 10F;

    private void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
}
