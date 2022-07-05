using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickController : MonoBehaviour
{


    public float rotationSpeed = 5;
    public Transform QueBall;

    public Slider sldForce;




    public float ForceLimit = 5.5f;
    public float ForceSliderOffset = 1.5f;

    private Vector3 Direction;
    private Vector3 mouseLastPosition;

    GameObject[] TargetBall;

    void Awake()
    {
        TargetBall = GameObject.FindGameObjectsWithTag("TargetBall");
        TargetBallPause();
        sldForce.maxValue = ForceLimit;
    }

    void TargetBallPause()
    {
        foreach (GameObject g in TargetBall)
        {
            if (g.activeInHierarchy)
            {

                g.GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }
    }

    void OnMouseDown()
    {


    }

    bool _IsRelease = false;
    void OnMouseUp()
    {

        float DragSpeed = Vector3.Distance(QueBall.transform.position, transform.position); //ForceMulti

        Debug.Log(DragSpeed);
        if (DragSpeed > ForceLimit)
        {
            Direction = Direction.normalized * ForceLimit;
        }
        gameObject.GetComponent<Rigidbody>().velocity = Direction * DragSpeed;

        _IsRelease = true;
    }

    void LateUpdate()
    {

    }

    void FixedUpdate()
    {


    }
    void Update()
    {

    }



    void OnEnable()
    {
        sldForce.value = 0;
        TargetBallPause();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "WorldBall")
        {
            //other.gameObject.GetComponent<Rigidbody>().velocity = Direction * DragSpeed;
            if (_IsRelease)
            {
                other.gameObject.GetComponent<CueBall>().AddForce(gameObject.GetComponent<Rigidbody>().velocity);
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.SetActive(false);
                TargetBallPause();
            }

            //Debug.Log(gameObject.GetComponent<Rigidbody>().velocity * DragSpeed);
        }
    }

    private void LookAtCue()
    {
        Vector3 targetPoint = QueBall.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void OnMouseDrag()
    {
        _IsRelease = false;
        Vector3 pos = GlobalUtil.GetMouseWorldPos(transform);
        //Changes the force to be applied
        //mousePreviousLocation = pos;
        pos.y = transform.position.y;
        Direction = QueBall.transform.position - transform.position;
        float _dis = Vector3.Distance(QueBall.transform.position, transform.position);
        transform.position = pos;
        sldForce.value = _dis - ForceSliderOffset;
        LookAtCue();
    }
}
