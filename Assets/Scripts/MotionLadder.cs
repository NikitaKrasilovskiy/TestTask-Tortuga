using UnityEngine;

public class MotionLadder : MonoBehaviour
{
    private float speedX = 0.7f, speedY = -0.7f;

    void Update()
    {
        transform.Translate(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);

        if (transform.position.x >= 6)
        { transform.position = new Vector3(-30, 30, 0); }
    }
}