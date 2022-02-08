using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TimerSvc: MonoBehaviour
{
    public static TimerSvc Instance=null;

    private PETimer pt;

    public void InitSys()
    {
        Instance = this;
        pt = new PETimer();
        
        //pt.SetLog((string info) =>
        //{
        //    PECommon.Log(info);
        //});
    }

    private void Update()
    {
        pt.Update();
    }

    public int AddTimeTask(Action<int> callback,double delay,PETimeUnit timeunit=PETimeUnit.Millisecond,int count=1)
    {
        return pt.AddTimeTask(callback, delay, timeunit, count);
    }

    public double GetNowTime()
    {
        return pt.GetMillisecondsTime();
    }

    public void DelTask(int tid)
    {
        pt.DeleteTimeTask(tid);
    }
}
