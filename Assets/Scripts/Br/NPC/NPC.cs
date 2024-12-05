using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : Entity
{
    #region StateMachine
    public NPCStateMachine stateMachine {  get; private set; }
    public string lastAnimBoolName { get; private set; }
    public NPCIdleState idleState { get; private set; }
    public NPCShockedState shockedState { get; private set; }
    public NPCComaState comaState { get; private set; }
    #endregion

    public bool isShocked = false;
    public bool isHeated = false;

    public GameObject Quiz;
    public GameObject Video;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new NPCStateMachine();
        idleState = new NPCIdleState(stateMachine, this, "Idle");
        shockedState = new NPCShockedState(stateMachine, this, "Shocked");
        comaState = new NPCComaState(stateMachine, this, "Coma");
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
