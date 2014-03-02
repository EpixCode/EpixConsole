using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
    string output = "";
    string stack = "";
	// Use this for initialization
	void Start () {
        DebugConsole.Init();
        Application.RegisterLogCallback(HandleLog);
        Debug.Log("Testing");
	}
	
	// Update is called once per frame
	void Update () {
        Debug.LogError("Kev : " + output + " / " + stack);
	}

    private void HandleLog(string logString, string stackTrace, LogType type) 
    {
        output = logString;
        stack = stackTrace;
        //Application.RegisterLogCallback(null);
        
    }
}
