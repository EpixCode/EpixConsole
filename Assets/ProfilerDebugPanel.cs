using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ProfilerDebugPanel : DebugPanel
{
    //UI
    Vector2 infoScroll = Vector2.zero;

    public ProfilerDebugPanel():base()
    {
        Name = "Profiler";
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
                        GUILayout.Label("TotalAllocatedMemory: " + Profiler.GetTotalAllocatedMemory().ToString(), "label");
                        GUILayout.Label("TotalReservedMemory: " + Profiler.GetTotalReservedMemory().ToString(), "label");
                        GUILayout.Label("TotalUnusedReservedMemory: " + Profiler.GetTotalUnusedReservedMemory().ToString(), "label");
                        GUILayout.Label("TotalUnusedReservedMemory: " + Profiler.GetTotalUnusedReservedMemory().ToString(), "label");
                        GUILayout.Label("MonoHeapSize: " + Profiler.GetMonoHeapSize().ToString(), "label");
                        GUILayout.Label("MonoUsedSize: " + Profiler.GetMonoUsedSize().ToString(), "label");
                        GUILayout.Label("usedHeapSize: " + Profiler.usedHeapSize.ToString(), "label");
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
        //TODO
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
