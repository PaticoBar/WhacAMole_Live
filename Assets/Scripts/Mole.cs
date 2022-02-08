/****************************************************
    文件：Mole.cs
    作者：Patico.Deng
    邮箱：1402027354@qq.com
    日期：2022/1/28 19:9:43
    功能：地鼠
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    public SpriteRenderer mole;
    public bool isHide;
    private float time;

    private void Update()
    {
        if (GameManager.Instance.IsStop)
        {
            time += Time.deltaTime * 4;
            if (time > 15)
            {
                time = 0;
                SetActive();
            }
        }
    }

    public void GetHit(Sprite sprite,Sprite normal)
    {
        mole.sprite = sprite;
        StartCoroutine(SetActive(true, mole.transform,normal));
        GameManager.Instance.Point+=100;
        GameManager.Instance.PlayPointSound();
    }

    IEnumerator SetActive(bool hide, Transform trans,Sprite sprite)
    {
        yield return new WaitForSeconds(1.2f);
        mole.sprite = sprite;
        trans.gameObject.SetActive(!hide);
        isHide = hide;
    }

    private void SetActive()
    {
        mole.gameObject.SetActive(false);
    }
}
