using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCChokeState : NPCState
{
    public NPCChokeState(NPCStateMachine _stateMachine, NPC _npcBase, string _animBoolName) : base(_stateMachine, _npcBase, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        base.npcBase.BubbleSpawn();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
