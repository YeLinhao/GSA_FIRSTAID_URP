using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NPC : Entity
{
    #region StateMachine
    public NPCStateMachine stateMachine {  get; private set; }
    public string lastAnimBoolName { get; private set; }
    public NPCIdleState idleState { get; private set; }
    public NPCShockedState shockedState { get; private set; }
    public NPCHeatStrokeState heatStrokeState { get; private set; }
    public NPCTickBiteState tickBiteState { get; private set; }
    public NPCAsthmaState asthmaState { get; private set; }
    public NPCChokeState chokeState { get; private set; }
    public NPCBleedingState bleedingState { get; private set; }
    public NPCConvulsiveSeizureState CSState { get; private set; }
    public NPCTwistState twistState { get; private set; }
    public NPCDiabeticState diabeticState { get; private set; }
    #endregion

    //Todo:当NPC状态改变时，头顶气泡改变
    //Todo:NPC碰撞体 idle动画（在原地溜达） 生病动画（脑袋晕） 治愈动画（躺倒）
    public bool isShocked = false;
    public bool isHeatStroked = false;
    public bool isTickBited = false;
    public bool isAsthma = false;
    public bool isChocked = false;
    public bool isBleeding = false;
    public bool isConvulsiveSeizure = false;
    public bool isNoseBleeding = false;
    public bool isTwisted = false;
    public bool isDiabetic = false;
    public bool isHealed = false;

    public GameObject Quiz;
    public GameObject Video;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new NPCStateMachine();
        idleState = new NPCIdleState(stateMachine, this, "Idle");
        shockedState = new NPCShockedState(stateMachine, this, "Shocked");
        heatStrokeState = new NPCHeatStrokeState(stateMachine, this, "HeatStroke");
        tickBiteState = new NPCTickBiteState(stateMachine, this, "TickBite");
        asthmaState = new NPCAsthmaState(stateMachine, this, "Asthma");
        chokeState = new NPCChokeState(stateMachine, this, "Choke");
        bleedingState = new NPCBleedingState(stateMachine, this, "Bleeidng");
        CSState = new NPCConvulsiveSeizureState(stateMachine, this, "CS");
        twistState = new NPCTwistState(stateMachine, this, "twist");
        diabeticState = new NPCDiabeticState(stateMachine, this, "diabetic");
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    public virtual void AssignLastAnimName(string _animBoolName) => lastAnimBoolName = _animBoolName;

    public void Interact(){
        Debug.Log("Interact!");
        //Todo:根据npc身上的标记触发相应的视频/Quiz
        if(GameManager.Instance == null)
        {
            Debug.Log("Please start with Begin Scene");
        }
        else if(GameManager.Instance.GameMode == 0)
        {
            Debug.Log("Video!");
            Video.SetActive(true);
            NPCController.Instance.isBeingSaved = this;
        }
       else if (GameManager.Instance.GameMode >= 0)
        {
            Quiz.SetActive(true);   
            NPCController.Instance.isBeingSaved = this;
        }

        
    }
}
