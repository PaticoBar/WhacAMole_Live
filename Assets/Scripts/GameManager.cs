/****************************************************
    文件：GameManager.cs
    作者：Patico.Deng
    邮箱：1402027354@qq.com
    日期：2022/1/28 19:0:59
    功能：游戏管理器
*****************************************************/

using BilibiliUtilities.Live;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    public int RoomID;

    public AudioSource audioSource;
    public AudioClip getHit;
    public AudioClip getPoint;

    public HoleManager holeManager;
    public Hammer hammer;
    public CameraScr cameraScr;
    public TimerSvc timerSvc;

    private float shakeTime;
    private float shakeFullTime;

    public Queue<string> nameList = new Queue<string>();

    private string user = String.Empty;

    private bool gameOver;

    private bool isShake;
    public bool IsShake { get => isShake; set => isShake = value; }

    private bool isStop;
    public bool IsStop { get => isStop; set => isStop = value; }

    private int point;
    public int Point { get => point; set => point = value; }

    // Start is called before the first frame update
    void Start()
    {
        timerSvc.InitSys();
        holeManager.Init();
        hammer.Init();
        cameraScr.CameraInit();
        ConnectLiveRoom(RoomID);
        Init();
        nameList.Clear();
        IsStop = false;
        gameOver = true;
    }

    private void Init()
    {
        IsStop = true;
        fullTime = 400;
        time = fullTime;
        shakeFullTime = 10;
        shakeTime = shakeFullTime;
        fill.fillAmount = 1;
        Point = 0;
        endGame.gameObject.SetActive(false);
    }

    public async void ConnectLiveRoom(int id)
    {
        MessageHandle mh = new MessageHandle();
        LiveRoom room = new LiveRoom(id, mh);
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

    private void FixedUpdate()
    {
        if (IsStop == true)
        {
            if (time >= 0)
            {
                time -= Time.deltaTime * 8;
                ShowTime();
            }
            else
            {
                GameOver();
                time = fullTime;
            }
            ShowPoint();
        }
        else
        {
            GameOver();
            ShowPoint();
        }
    }

    public void PlayHitSound()
    {
        audioSource.clip = getHit;
        audioSource.Play();
    }

    public void PlayPointSound()
    {
        audioSource.clip = getPoint;
        audioSource.Play();
    }

    public void StringHandle(string str)
    {
        int a = 0;
        if (str=="11") 
        {
            a = 0;
        }
        else if (str=="12")
        {
            a = 1;
        }
        else if (str=="13")
        {
            a = 2;
        }
        else if (str == "21")
        {
            a = 3;
        }
        else if (str == "22")
        {
            a = 4;
        }
        else if (str == "23")
        {
            a = 5;
        }
        else if (str == "31")
        {
            a = 6;
        }
        else if (str == "32")
        {
            a = 7;
        }
        else if (str == "33")
        {
            a = 8;
        }
        else if (str=="结束")
        {
            IsStop = false;
        }
        else if (str=="重来")
        {
            ResetGame();
        }
        hammer.MoveAndHit(a);
    }

    public void GetName(string str)
    {
        nameList.Enqueue(str);
    }

    public void SetName()
    {
        if (nameList.Count>0)
        {
            user = nameList.Dequeue();
        }
    }

    public void UserHandle(string content,string userame)
    {
        if (content == "加入")
        {
            GetName(userame);
        }

        if (isStop==false&&gameOver==true)
        {
            SetName();
            ResetGame();
        }

        SetUserControll(content, userame);
    }

    private void SetUserControll(string content,string name)
    {
        if (name==user&&gameOver==false)
        {
            IsStop = true;           
            ShowName(user);
            StringHandle(content);
        }
    }

    private void ShowName(string name)
    {
        hammer.ShowName(name);
    }

    private void CamShake()
    {
        cameraScr.CamShake();
    }

    private void CamResetPos()
    {
        cameraScr.CamResetPos();
    }

    public void SetCamShake()
    {
        timerSvc.AddTimeTask((int tid) =>
        {
            CamShake();
        },0.1f,PETimeUnit.Second,5);
        timerSvc.AddTimeTask((int tid) =>
        {
            CamResetPos();
        }, 0.15f, PETimeUnit.Second, 5);
    }

    private void ResetGame()
    {
        Init();
        for (int i = 0; i < holeManager.holeDic.Count; i++)
        {
            holeManager.holeDic[i].GetChild(0).gameObject.SetActive(false);
        }
        gameOver = false;
    }

    #region UI
    public Text text;
    public Image fill;
    public Transform endGame;
    public Text endTxt;
    private float time;
    private float fullTime;

    private void ShowPoint()
    {
        text.text = Point.ToString();
    }

    private void ShowTime() 
    {
        fill.fillAmount = time / fullTime;
    }

    public void GameOver()
    {
        endGame.gameObject.SetActive(true);
        endTxt.text = "获得" + Point.ToString() + "分";
        isStop = false;
        gameOver = true;
    }
    #endregion
}
