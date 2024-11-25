using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShockedState : NPCState
{
    public NPCShockedState(NPCStateMachine _stateMachine, NPC _npcBase, string _animBoolName) : base(_stateMachine, _npcBase, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override void Update()
    {
        base.Update();
    }
}
