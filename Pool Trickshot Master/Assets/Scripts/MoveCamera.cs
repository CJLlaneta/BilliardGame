using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public Transform playerCueBall;
    public Transform WorldCueBall;

    public float smoothTime = 0.3F;
    public float Yoffset = -14.5f;
    private Vector3 velocity = Vector3.zero;

    private float OriginalY = 0;

    void Start()
    {
        OriginalY = transform.position.y;
    }
    void Update()
    {


        FollowTheBall();
    }
    void FixedUpdate()
    {

    }
    Transform _currentTarget;
    private void FollowTheBall()
    {
        if (playerCueBall.gameObject.activeInHierarchy)
        {
            _currentTarget = playerCueBall;
        }
        else
        {
            _currentTarget = WorldCueBall;
        }
        Vector3 targetPosition = new Vector3(_currentTarget.position.x, transform.position.y, _currentTarget.position.z + Yoffset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
    }
}
