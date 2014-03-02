using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DebugConsole : MonoBehaviour
{
    private static DebugConsole console;
    
    public static DebugConsole Init ()
    {
        if (!Application.isPlaying)
            return null;
        if (!console) {
            console = (DebugConsole)GameObject.FindObjectOfType (typeof(DebugConsole));
        }
        if (!console) {
            GameObject go = new GameObject ("Console");
            go.hideFlags = HideFlags.HideAndDontSave;
            console = go.AddComponent<DebugConsole> ();
        }
        if (!console) {
            return null;
        }
        return console;
    }
    
    public static void Destroy ()
    {
        if (!Application.isPlaying)
            return;
        if (console) {
            Destroy (console.gameObject);
        }
    }
    
    Vector2 consoleScroll = Vector2.zero;
    List<ConsoleMessage> messages = new List<ConsoleMessage> ();
    
    void Start ()
    {
        Application.RegisterLogCallbackThreaded (HandleLog);
    }
    
    void OnGUI ()
    {
        if (console) {
            ConsoleGUI ();
        }
    }
    
    [System.Serializable]
    private class ConsoleMessage
    {
        public string logString;
        public string stackTrace;
        public LogType type;
        
        public ConsoleMessage (string logString, string stackTrace, LogType type)
        {
            this.logString = logString;
            this.stackTrace = stackTrace;
            this.type = type;
        }
    }
    
    void HandleLog (string logString, string stackTrace, LogType type)
    {
        messages.Add (new ConsoleMessage (logString, stackTrace, type));
    }
    
    void ConsoleGUI ()
    {   
        GUILayout.BeginArea (new Rect (0, 0, Screen.width, Screen.height / 2));
        {
            consoleScroll = GUILayout.BeginScrollView (consoleScroll, "textfield", GUILayout.Width (Screen.width));
            {
                foreach (var m in messages) {
                    GUILayout.BeginHorizontal (GUILayout.Width (Screen.width - 4));
                    {
                        if (m.type == LogType.Error || m.type == LogType.Exception) {
                            GUI.color = Color.red;
                        } else if (m.type == LogType.Warning) {
                            GUI.color = Color.yellow;
                        } else {
                            GUI.color = Color.white;
                        }
                        GUILayout.TextField (m.logString, "label");
                    }
                    GUILayout.EndHorizontal ();
                }
            }
            GUI.EndScrollView ();
            
            //          if (Event.current.type == EventType.Repaint) {
            //              Rect last = GUILayoutUtility.GetLastRect ();
            //              if (last == null)
            //                  return;
            //              consoleScroll.y = last.height;
            //          }
        }
        GUILayout.EndArea ();
    }
    
}