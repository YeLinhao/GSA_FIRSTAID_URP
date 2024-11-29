using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Entity
{
    #region StateMachine
    public NPCStateMachine stateMachine {  get; private set; }
    public string lastAnimBoolName { get; private set; }
    #endregion

    public GameObject Quiz;

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new NPCStateMachine();
    }

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        // stateMachine.currentState.Update();
    }

    public virtual void AssignLastAnimName(string _animBoolName) => lastAnimBoolName = _animBoolName;

    public void Interact(){
        Quiz.SetActive(true);
    }
}
