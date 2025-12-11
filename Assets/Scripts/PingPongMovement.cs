using UnityEngine;

public class PingPongMovement : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 0.1f;
    public Transform StartPosition;
    public Transform EndPosition;

    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, distance);
        transform.position = Vector3.Lerp(StartPosition.position, EndPosition.position, pingPong / distance);
    }
}
