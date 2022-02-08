/****************************************************
    文件：Camera.cs
    作者：Patico.Deng
    邮箱：1402027354@qq.com
    日期：2022/1/28 23:25:52
    功能：相机抖动
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScr : MonoBehaviour
{
    public bool isShake;
    public Vector3 pos;

    public void CameraInit()
    {
        isShake = false;
        pos = transform.position;
    }

    public void CamShake()
    {
        float x = Random.Range(-0.1f, 0.1f);
        float y = Random.Range(-0.1f, 0.1f);

        //transform.position = Vector3.Lerp(pos,new Vector3(x,y,0),0.01f);       
        transform.position = pos + new Vector3(x, y, 0);
        //transform.position = pos;
    }

    public void CamResetPos()
    {
        transform.position = pos;
    }
}
