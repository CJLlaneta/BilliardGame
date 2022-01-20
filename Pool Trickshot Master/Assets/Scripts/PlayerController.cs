using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    //public float walkSpeed = 5;

    public Camera Cam;
    public float rotationSpeed = 450;
    public float runSpeed = 8;
    public GameObject QueballWorld;
    public GameObject Stick;
    private CharacterController controller;
    private Quaternion targetRotation;

    private Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        QueballWorld.SetActive(false);
        Stick.SetActive(false);
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void Update()
    {
        MouseControls();
        InputKeyboard();
    }

    private void InputKeyboard()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            gameObject.SetActive(false);
            QueballWorld.transform.position = gameObject.transform.position;
            Stick.transform.position = transform.position - transform.forward * 2.1f;
            Stick.transform.LookAt(QueballWorld.transform.position);
            QueballWorld.SetActive(true);
            Stick.SetActive(true);
        }
    }

    private void MouseLook()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        }

    }

    private void MouseControls()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Cam.transform.position.y - transform.position.y));
        //targetRotation = Quaternion.LookRotation(mousePos - new Vector3(transform.position.x, 0, transform.position.z));
        //transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        MouseLook();
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 motion = input;
        motion *= (Mathf.Abs(input.x) == 1 && Mathf.Abs(input.z) == 1) ? .7f : 1;
        //  motion *= (Input.GetButton("Run")) ? runSpeed : walkSpeed;
        motion *= runSpeed;
        motion += Vector3.up * -8;
        controller.Move(motion * Time.deltaTime);
        //controller.Move(new Vector3(0, -1 * Time.deltaTime, 0));
    }


}
