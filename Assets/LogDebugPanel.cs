using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LogDebugPanel : DebugPanel
{
    //Config
    private const int MAX_PASSIVE_LOG_BUFFER = 500;
    private const int MAX_ACTIVE_LOG_BUFFER = 100;

    //Reference Holder
    private List<LogMessage> activeLogQueue;
    private List<LogMessage> passiveLogQueue;
    private Dictionary<ELogType, bool> LogTypeFilterDict;
    private LogMessage selectedMessage;

    //UI
    Vector2 consoleScroll = Vector2.zero;
    Vector2 stackScroll = Vector2.zero;

    public LogDebugPanel():base()
    {
        Name = "Logger";
    }

    protected override void OnDispose()
    {
        Application.RegisterLogCallbackThreaded(null);
        if (activeLogQueue != null)
        {
            activeLogQueue.Clear();
            activeLogQueue = null;
        }
    }

    protected override void OnDraw()
    {
        GUILayout.BeginArea(new Rect(0, 40, Screen.width, Screen.height / 2));
        {
            consoleScroll = GUILayout.BeginScrollView(consoleScroll, "textfield", GUILayout.Width(Screen.width));
            {
                int len = activeLogQueue.Count;
                for(int i = len - 1; i >= 0; i--)
                {
                    LogMessage log = activeLogQueue[i];

                    GUILayout.BeginHorizontal(GUILayout.Width(Screen.width - 4));
                    {
                        GUI.color = log.LogType.Color;
                        if (GUILayout.Button(log.Message, "label"))
                        {
                            selectedMessage = log;
                        }
                    }
                    GUILayout.EndHorizontal();
                }
            }
            GUI.EndScrollView();
        }
        GUILayout.EndArea();

        if (selectedMessage != null)
        {
            GUILayout.BeginArea(new Rect(0, (Screen.height / 2) + 40, Screen.width, (Screen.height / 2) - 40));
            {
                stackScroll = GUILayout.BeginScrollView(stackScroll, "textfield", GUILayout.Width(Screen.width));
                {
                    GUILayout.TextField(selectedMessage.StackTrace, "label");
                }
                GUI.EndScrollView();
            }
            GUILayout.EndArea();
        }
    }

    protected override void OnUpdate()
    {
        //TODO
    }

    protected override void OnInit()
    {
        activeLogQueue = new List<LogMessage>();
        passiveLogQueue = new List<LogMessage>();
        LogTypeFilterDict = new Dictionary<ELogType, bool>();

        PopulateFilter();

        Application.RegisterLogCallbackThreaded(OnLog);
    }

    private void PopulateFilter()
    {
        List<ELogType> logTypeList = ELogType.GetList();
        LogTypeFilterDict.Clear();
        foreach (ELogType logType in logTypeList)
        {
            LogTypeFilterDict.Add(logType, true);
        }
    }

    protected override void OnActivate()
    {
        //TODO
    }

    protected override void OnDeactivate()
    {
        //TODO
    }

    public override string Dump()
    {
        throw new NotImplementedException();
    }

    private void OnLog(string logString, string stackTrace, LogType type)
    {
        ELogType logType = ELogType.GetLogType(type);
        LogMessage message = new LogMessage(logType, logString, stackTrace);
        
        passiveLogQueue.Add(message);

        if (passiveLogQueue.Count > MAX_PASSIVE_LOG_BUFFER)
        {
            passiveLogQueue.RemoveAt(0);
        }

        if (LogTypeFilterDict.ContainsKey(logType) && LogTypeFilterDict[logType])
        {
            activeLogQueue.Add(message);

            if (activeLogQueue.Count > MAX_ACTIVE_LOG_BUFFER)
            {
                activeLogQueue.RemoveAt(0);
            }
        }
    }

    private void ComputeFilter()
    {
        LogMessage messageBuffer;
        activeLogQueue.Clear();

        for (int i = passiveLogQueue.Count - 1; i >= 0; i--)
        {
            messageBuffer = passiveLogQueue[i];
            if (LogTypeFilterDict[messageBuffer.LogType])
            {
                activeLogQueue.Add(messageBuffer);

                if (activeLogQueue.Count >= MAX_ACTIVE_LOG_BUFFER)
                {
                    break;
                }
            }
        }

        activeLogQueue.Reverse();
    }
}
