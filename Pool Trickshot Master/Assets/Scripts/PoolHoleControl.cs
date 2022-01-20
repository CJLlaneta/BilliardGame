using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolHoleControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "TargetBall")
        {
            other.gameObject.SetActive(false);
        }
        else if (other.transform.tag == "WorldBall")
        {
            other.transform.position = GlobalUtil.CueDefaultPosition;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
