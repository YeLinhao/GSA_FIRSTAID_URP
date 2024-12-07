using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTickBiteState : NPCState
{
    public NPCTickBiteState(NPCStateMachine _stateMachine, NPC _npcBase, string _animBoolName) : base(_stateMachine, _npcBase, _animBoolName)
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
        if (npcBase.isHealed)
        {
            stateMachine.ChangeState(npcBase.healedState);
        }
    }
}
