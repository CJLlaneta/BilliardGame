using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostGameController : MonoBehaviour
{
    public GameObject PostPanel;

    public Text txtBallCount;
    public Text txtlvl;

    public List<GameObject> lstTargetBall = new List<GameObject>();

    void Start()
    {
        PostPanel.SetActive(false);
        // lstTargetBall.AddRange(GameObject.FindGameObjectsWithTag("TargetBall"));
        int _pool = 0;
        if (GlobalUtil.level == 0)
        {
            _pool = 1;
        }
        else if (GlobalUtil.level == 1)
        {
            _pool = 3;
        }
        else if (GlobalUtil.level == 2)
        {
            _pool = 6;
        }
        else if (GlobalUtil.level == 3)
        {
            _pool = 10;
        }
        else
        {
            GlobalUtil.level = 4;
            _pool = 15;
        }

        //  _pool = _pool + GlobalUtil.level;
        txtlvl.text = "LEVEL " + GlobalUtil.level;
        //  Debug.Log(_pool);
        for (int a = lstTargetBall.Count - 1; a >= 0; a--)
        {
            if (a >= _pool)
            {

                lstTargetBall[a].SetActive(false);
                lstTargetBall.RemoveAt(a);
            }
        }

    }
    public void ChangeLevel(int lvl)
    {
        GlobalUtil.level += lvl;
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsTargetBallGone())
        {
            //Game Conditions;
            PostPanel.SetActive(true);
        }
        UpdateBallCount();
    }

    void UpdateBallCount()
    {
        int _cnt = 0;
        foreach (GameObject g in lstTargetBall)
        {
            if (g.activeInHierarchy)
            {
                _cnt += 1;
            }
        }
        txtBallCount.text = "Ball : " + _cnt + "/" + lstTargetBall.Count.ToString();
    }

    private bool IsTargetBallGone()
    {
        bool _ret = true;
        foreach (GameObject g in lstTargetBall)
        {
            if (g.activeInHierarchy)
            {
                return false;
            }
        }
        return _ret;
    }
    void Update()
    {

    }
}
