using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class PlatformInfoDebugPanel : DebugPanel
{
    PlatformInfo info;

    //UI
    Vector2 infoScroll = Vector2.zero;

    public PlatformInfoDebugPanel():base()
    {
        Name = "Info";
    }

    protected override void OnDispose()
    {

    }

    protected override void OnDraw()
    {
        GUILayout.BeginArea(new Rect(0, 40, Screen.width, Screen.height / 2));
        {
            infoScroll = GUILayout.BeginScrollView(infoScroll, "Label", GUILayout.Width(Screen.width));
            {
                    GUILayout.BeginVertical(GUILayout.Width(Screen.width - 4));
                    {
                        GUILayout.Label(info.Report, "label");
                    }
                    GUILayout.EndVertical();
            }
            GUI.EndScrollView();
        }
        GUILayout.EndArea();
    }

    protected override void OnUpdate()
    {
        //TODO
    }

    protected override void OnInit()
    {
        info = new PlatformInfo();
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
}
