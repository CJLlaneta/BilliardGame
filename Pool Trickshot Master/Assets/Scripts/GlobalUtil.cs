using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GlobalUtil
{
    public static int level = 0;
    public static Vector3 CueDefaultPosition = Vector3.zero;
    public static Vector3 GetMouseWorldPos(Transform SelectedObject)
    {
        Vector3 mousepoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(SelectedObject.position).z);
        return Camera.main.ScreenToWorldPoint(mousepoint);
    }


}
