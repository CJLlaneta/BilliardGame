using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallPlayer : MonoBehaviour
{
    public GameObject QueballWorld;
    public GameObject Stick;

    public GameObject PanelCuePosition;
    public GameObject PanelAiming;

    void Start()
    {
        GlobalUtil.CueDefaultPosition = gameObject.transform.position;
        QueballWorld.SetActive(false);
        Stick.SetActive(false);
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
            PanelCuePosition.SetActive(false);
            PanelAiming.SetActive(true);
            Stick.SetActive(true);

        }
    }
    void OnEnable()
    {
        PanelAiming.SetActive(false);
        PanelCuePosition.SetActive(true);
    }
    void OnDisable()
    {

    }

    void Update()
    {
        InputKeyboard();
    }
    void OnMouseUp()
    {

    }
    void OnMouseDrag()
    {

        Vector3 pos = GlobalUtil.GetMouseWorldPos(transform);
        pos.y = transform.position.y;
        transform.position = pos;
    }
}
