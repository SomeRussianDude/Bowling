using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Ball ball;

    private Vector3 _offset;
    private float cameraStopPoint = 1829f;
    
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
