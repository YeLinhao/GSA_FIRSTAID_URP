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
    }

    public override void Update()
    {
        base.Update();
        if (npcBase.isShocked == true)
        {
            stateMachine.ChangeState(npcBase.shockedState);
        }
        else if (npcBase.isHeatStroked == true)
        {
            stateMachine.ChangeState(npcBase.heatStrokeState);
        }
        else if (npcBase.isTickBited == true)
        {
            stateMachine.ChangeState(npcBase.tickBiteState);
        }
        else if (npcBase.isAsthma == true)
        {
            stateMachine.ChangeState(npcBase.asthmaState);
        }
        else if (npcBase.isChoked == true)
        {
            stateMachine.ChangeState(npcBase.chokeState);
        }
        else if (npcBase.isBleeding == true)
        {
            stateMachine.ChangeState(npcBase.bleedingState);
        }
        else if (npcBase.isConvulsiveSeizure == true)
        {
            stateMachine.ChangeState(npcBase.CSState);
        }
        else if (npcBase.isNoseBleeding == true)
        {
            stateMachine.ChangeState(npcBase.noseBleedingState);
        }
        else if (npcBase.isTwisted == true)
        {
            stateMachine.ChangeState(npcBase.twistState);
        }
        else if (npcBase.isDiabetic == true)
        {
            stateMachine.ChangeState(npcBase.diabeticState);
        }
    }
    
    public override void Exit()
    {
        base.Exit();
    }

}
