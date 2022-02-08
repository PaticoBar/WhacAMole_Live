/****************************************************
    文件：Hammer.cs
    作者：Patico.Deng
    邮箱：1402027354@qq.com
    日期：2022/1/28 20:27:31
    功能：锤子脚本
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public Dictionary<int, Transform> pointDic = new Dictionary<int, Transform>();
    public Transform hammer;

    public void Init()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            pointDic.Add(i, transform.GetChild(i));
        }
    }

    public void MoveAndHit(int a)
    {
        if (GameManager.Instance.IsStop)
        {
            Transform target = pointDic[a];
            hammer.SetParent(target);
            hammer.localPosition = Vector3.zero;
            hammer.eulerAngles = new Vector3(0, 0, 90);
            GameManager.Instance.holeManager.GetHit(a);
            GameManager.Instance.PlayHitSound();
            GameManager.Instance.SetCamShake();
            Invoke("EulerBack", 0.4f);
        }
    }

    public void EulerBack()
    {
        hammer.eulerAngles = new Vector3(0, 0, 0);
    }

    public void ShowName(string name)
    {
        hammer.GetComponent<TextMesh>().text = name;
    }
}
