using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class DebugMenu : MonoBehaviour 
{
    public static DebugMenu Instance {get; private set;}
    public List<DebugPanel> panelList;
    private DebugPanel currentPanel;

    public DebugMenu Init()
    {
        if (!Application.isPlaying)
        {
            return null;
        }
            
        if (!Instance)
        {
            Instance = (DebugMenu)GameObject.FindObjectOfType(typeof(DebugMenu));
        }

        if (!Instance)
        {
            GameObject go = new GameObject("_DebugMenu");
            go.hideFlags = HideFlags.HideAndDontSave;
            Instance = go.AddComponent<DebugMenu>();
            UnityEngine.GameObject.DontDestroyOnLoad(go);
        }

        if (!Instance)
        {
            return null;
        }

        PopulatePanelList();

        return Instance;
    }

    private void PopulatePanelList()
    {
        if (panelList != null)
        {
            foreach (DebugPanel panel in panelList)
            {
                panel.Dispose();
            }
            panelList.Clear();
        }

        panelList = new List<DebugPanel>();
        panelList.Add(new LogDebugPanel());
        panelList.Add(new PlatformInfoDebugPanel());
        panelList.Add(new ProfilerDebugPanel());

        foreach(DebugPanel panel in panelList)
        {
            panel.Init();
        }

        SetCurrentPanel(panelList[0]);
    }

    private void SetCurrentPanel(DebugPanel panel)
    {
        if (panel == currentPanel) { return; }

        if (currentPanel != null)
        {
            currentPanel.Deactivate();
        }
        currentPanel = panel;
        currentPanel.Activate();
    }

	void Start () 
    {
        Init();   
	}

    void OnGUI ()
    {
        GUI.BeginGroup(new Rect(0,0,Screen.width, 40));
        DrawTabs();
        GUI.EndGroup();

        GUI.BeginGroup(new Rect(0,40,Screen.width, Screen.height - 40));
        DrawCurrentPanel();
        GUI.EndGroup();
    }

    private void DrawTabs()
    {
        if (panelList.Count <= 0)
        {
            return;
        }

        int len = panelList.Count;
        DebugPanel pannelBuffer;
        float tabWidth = (Screen.width - 40) / len;

        for (int i = 0; i < len; i++)
        {
            pannelBuffer = panelList[i];

            Rect rect = new Rect(i * tabWidth, 0, tabWidth, 40);
            if(GUI.Button(rect, pannelBuffer.Name))
            {
                SetCurrentPanel(pannelBuffer);
            }
        }

        Rect closeRect = new Rect(Screen.width - 40, 0, 40, 40);
        if (GUI.Button(closeRect, "X"))
        {
            //SetCurrentPanel(pannelBuffer);
        }
    }

    private void DrawCurrentPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.Draw();
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        int randomInt = UnityEngine.Random.Range(0, 200);
        switch (randomInt)
        {
            case 0:
            {
                Debug.Log("LOG TYPE");
                break;
            }
            case 1:
            {
                Debug.LogWarning("LOG WARNING TYPE");
                break;
            }
            case 2:
            {
                Debug.LogError("LOG ERROR TYPE");
                break;
            }
            case 3:
            {
                Debug.LogException(new Exception("LOG EXCEPTION TYPE"));
                break;
            }
            default:
            {
                break;
            }
        }
	}
}