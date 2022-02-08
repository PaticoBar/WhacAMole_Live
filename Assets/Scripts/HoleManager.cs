/****************************************************
    文件：HoleManager.cs
    作者：Patico.Deng
    邮箱：1402027354@qq.com
    日期：2022/1/28 18:48:27
    功能：地洞管理器
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    public Sprite MoleHit;
    public Sprite Mole;
    public Dictionary<int, Transform> holeDic = new Dictionary<int, Transform>();
    private int hideNum;
    public int HideNum { get => hideNum; set => hideNum = value; }

    public void Init()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<Mole>().mole = transform.GetChild(i).GetChild(0).GetComponent<SpriteRenderer>();
            transform.GetChild(i).GetComponent<Mole>().isHide = true;
            holeDic.Add(i, transform.GetChild(i));
            transform.GetChild(i).GetComponent<Mole>().mole.gameObject.gameObject.SetActive(false);
        }
        InvokeRepeating("RandomHoleNum", 0, 0.8f);
    }

    public void GetHit(int i)
    {
        Transform hit = holeDic[i];
        Mole hitmole = hit.GetComponent<Mole>();
        if (hit.GetChild(0).gameObject.activeSelf==true)
        {
            hitmole.GetHit(MoleHit,Mole);
        }
    }

    public void RandomHoleNum()
    {
        if (GameManager.Instance.IsStop)
        {
            int i = Random.Range(0, 9);
            if (holeDic[i].GetChild(0).gameObject.activeSelf == false)
            {
                holeDic[i].GetChild(0).gameObject.SetActive(true);
            }
        }
    }

}
