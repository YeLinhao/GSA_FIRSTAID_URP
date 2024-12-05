using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : NPCState
{
    public NPCIdleState(NPCStateMachine _stateMachine, NPC _npcBase, string _animBoolName) : base(_stateMachine, _npcBase, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Now Idle");
    }

    public override void Update()
    {
        base.Update();
        if (npcBase.isShocked == true)
        {
            Debug.Log("One worker is Shocked!");
            stateMachine.ChangeState(npcBase.shockedState);
        }
    }
    
    public override void Exit()
    {
        base.Exit();
    }

}
