using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float cameraStopPoint = 18.29f;

    private Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
        _offset = transform.position - ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowBall();
    }

    private void FollowBall()
    {
        if (transform.position.z >= cameraStopPoint)
        {
            return;
        }

        transform.position = ball.transform.position + _offset;
    }
}