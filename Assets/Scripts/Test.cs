/****************************************************
    文件：Test.cs
    作者：Patico.Deng
    邮箱：1402027354@qq.com
    日期：2022/1/28 14:54:15
    功能：test
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BilibiliUtilities.Live;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectLiveRoom();
    }

    public async void ConnectLiveRoom()
    {
        MessageHandle mh = new MessageHandle();
        LiveRoom room = new LiveRoom(7917437, mh);
        if (await room.ConnectAsync())
        {
            Debug.Log("连接成功，开始获取直播弹幕");
            await room.ReadMessageLoop();
        }
        else
        {
            Debug.Log("连接失败");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
