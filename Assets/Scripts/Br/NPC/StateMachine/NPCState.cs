using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCState
{
    protected NPCStateMachine stateMachine;
    protected NPC npcBase;
    protected Rigidbody rb;

    private string animBoolName;

    public NPCState(NPCStateMachine _stateMachine, NPC _npcBase, string _animBoolName)
    {
        this.stateMachine = _stateMachine;
        this.npcBase = _npcBase;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {

    }

    public virtual void Enter()
    {
        rb = npcBase.rb;
        npcBase.anim.SetBool(animBoolName, true);
    }

    public virtual void Exit()
    {
        npcBase.anim.SetBool(animBoolName, false);
        npcBase.AssignLastAnimName(animBoolName);
    }
}
