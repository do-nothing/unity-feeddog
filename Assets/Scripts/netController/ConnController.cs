using LitJson;
using Microwise.Guide.NetConn;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnController
{

    private Messenger messenger;
    private ProcessMessage messageHandler;

    public void init(AppInfo appInfo)
    {
        messenger = UdpMessenger.getInstance("127.0.0.1", 5556, appInfo);

        messenger.addMessageListener(messageHandler);
    }

    public void close()
    {
        messenger.destroy();
    }

    public void addMessageListener(ProcessMessage processMessage)
    {
        messageHandler = processMessage;
    }

}
