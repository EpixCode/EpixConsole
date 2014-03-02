using UnityEngine;
using System.Collections;
using System;

public abstract class DebugPanel : IDisposable 
{
    protected EDebugPanelState state;
    public string Name { get; protected set; }

    public DebugPanel()
    {
        ChangeState(EDebugPanelState.Not_Initialized);
    }

    public void Dispose()
    {
        ChangeState(EDebugPanelState.Not_Initialized);
        //TODO

        OnDispose();
    }

    public void Draw()
    {
        if (state != EDebugPanelState.Activated) { return; }

        OnDraw();
    }

    public void Update()
    {
        if (state != EDebugPanelState.Activated) { return; }

        OnUpdate();
    }

    public void Init()
    {
        if (state != EDebugPanelState.Not_Initialized) { return; }

        ChangeState(EDebugPanelState.Initialized);
        OnInit();
    }

    public void Activate()
    {
        if (state != EDebugPanelState.Initialized) { return; }

        ChangeState(EDebugPanelState.Activated);
        OnActivate();
    }

    public void Deactivate()
    {
        if (state != EDebugPanelState.Activated) { return; }

        ChangeState(EDebugPanelState.Initialized);
        OnDeactivate();
    }

    protected void ChangeState(EDebugPanelState newState)
    {
        if (newState == state) { return; }

        state = newState;
    }

    protected abstract void OnDraw();
    protected abstract void OnUpdate();
    protected abstract void OnInit();
    protected abstract void OnActivate();
    protected abstract void OnDeactivate();
    protected abstract void OnDispose();

    public abstract string Dump();
}
