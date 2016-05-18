using DocumentFormat.OpenXml.Vml;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatTest.SignalR
{
    [HubName("ChatHub")]
    public class ChatHub : Hub
    {
        public string Hello()
        {
            return "hello";
        }
        public void SendMessag(string message)
        {
            Clients.Others.talk(message);
        }

        // 发送图片
        public void SendImage(string name, IEnumerable<ImageData> images)
        {
            foreach (var item in images ?? Enumerable.Empty<ImageData>())
            {
                if (String.IsNullOrEmpty(item.Picture)) continue;
                Clients.All.receiveImage(name, item.Picture); // 调用客户端receiveImage方法将图片进行显示
            }
        }
    }
}