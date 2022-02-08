/****************************************************
    文件：MessageHandle.cs
    作者：Patico.Deng
    邮箱：1402027354@qq.com
    日期：2022/1/28 14:55:7
    功能：弹幕消息处理器
*****************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BilibiliUtilities.Live.Lib;
using System.Threading.Tasks;
using BilibiliUtilities.Live.Message;

public class MessageHandle : IMessageHandler
{
    Task IMessageHandler.AudiencesHandlerAsync(int audiences)
    {
        return null;
    }

    Task IMessageHandler.ComboEndMessageHandlerAsync(ComboEndMessage comboEndMessage)
    {
        return null;
    }

    Task IMessageHandler.DanmuMessageHandlerAsync(DanmuMessage danmuMessage)
    {
        string content = danmuMessage.Content;
        string name = danmuMessage.Username;
        GameManager.Instance.UserHandle(content, name);
        return null;
    }

    Task IMessageHandler.EntryEffectMessageHandlerAsync(EntryEffectMessage entryEffectMessage)
    {
        return null;
    }

    Task IMessageHandler.GiftMessageHandlerAsync(GiftMessage giftMessage)
    {
        return null;
    }

    Task IMessageHandler.GuardBuyMessageHandlerAsync(GuardBuyMessage guardBuyMessage)
    {
        return null;
    }

    Task IMessageHandler.InteractWordMessageHandlerAsync(InteractWordMessage message)
    {
        return null;
    }

    Task IMessageHandler.LiveStartMessageHandlerAsync(int roomId)
    {
        return null;
    }

    Task IMessageHandler.LiveStopMessageHandlerAsync(int roomId)
    {
        return null;
    }

    Task IMessageHandler.NoticeMessageHandlerAsync(NoticeMessage noticeMessage)
    {
        return null;
    }

    Task IMessageHandler.RoomUpdateMessageHandlerAsync(RoomUpdateMessage roomUpdateMessage)
    {
        return null;
    }

    Task IMessageHandler.UserToastMessageHandlerAsync(UserToastMessage userToastMessage)
    {
        return null;
    }

    Task IMessageHandler.WelcomeGuardMessageHandlerAsync(WelcomeGuardMessage welcomeGuardMessage)
    {
        return null;
    }

    Task IMessageHandler.WelcomeMessageHandlerAsync(WelcomeMessage welcomeMessage)
    {
        return null;
    }
}
