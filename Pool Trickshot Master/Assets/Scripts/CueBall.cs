using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlayerCue;
    public GameObject Stick;
    Rigidbody rgbody;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnEnable()
    {
        _IsShoot = false;
        if (rgbody == null)
        {
            rgbody = gameObject.GetComponent<Rigidbody>();
        }


    }
    bool _IsShoot = false;
    public void AddForce(Vector3 velocity)
    {
        _IsShoot = true;
        rgbody.velocity = velocity;
    }

    void FixedUpdate()
    {
        //Debug.Log(rgbody.velocity.magnitude);
        if (_IsShoot)
        {
            if (rgbody.velocity.magnitude <= 0.35f)
            {
                PlayerCue.transform.position = transform.position;
                PlayerCue.SetActive(true);
                Stick.SetActive(false);
                gameObject.SetActive(false);
                rgbody.velocity = Vector3.zero;
            }
        }
        else
        {
            rgbody.velocity = Vector3.zero;
        }

    }
}
