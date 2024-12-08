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
    public NPCNoseBleedingState noseBleedingState { get; private set; }
    public NPCHealedState healedState { get; private set; }
    #endregion

    //Todo:当NPC状态改变时，头顶气泡改变
    //Todo:NPC碰撞体 idle动画（在原地溜达） 生病动画（脑袋晕） 治愈动画（躺倒）
    public bool isShocked = false;
    public bool isHeatStroked = false;
    public bool isTickBited = false;
    public bool isAsthma = false;
    public bool isChoked = false;
    public bool isBleeding = false;
    public bool isConvulsiveSeizure = false;
    public bool isNoseBleeding = false;
    public bool isTwisted = false;
    public bool isDiabetic = false;
    public bool isHealed = false;

    public GameObject Bubble;
    public BubbleSpriteSO BubbleSpritePool;

    public float SickTime = 0f;
    public float HealTime = 0f;

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
        bleedingState = new NPCBleedingState(stateMachine, this, "Bleeding");
        CSState = new NPCConvulsiveSeizureState(stateMachine, this, "CS");
        twistState = new NPCTwistState(stateMachine, this, "twist");
        diabeticState = new NPCDiabeticState(stateMachine, this, "diabetic");
        noseBleedingState = new NPCNoseBleedingState(stateMachine, this, "noseBleeding");
        healedState = new NPCHealedState(stateMachine, this, "Healed");
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

        if (CheckIfSick() == false)
        {
            SickTime += Time.deltaTime;
        }
        if (isHealed == false)
        {
            HealTime += Time.deltaTime;
        }

    }

    public virtual void AssignLastAnimName(string _animBoolName) => lastAnimBoolName = _animBoolName;

    public void Interact()
    {
        Debug.Log("Interact!");
        if (CheckIfSick())//Only Sick people can be saved
        {
            //Todo:根据npc身上的标记触发相应的视频/Quiz
            if (GameManager.Instance == null)
            {
                Debug.Log("Please start with Begin Scene");
            }
            else if (GameManager.Instance.GameMode == 0)//if tutorial then video
            {
                NPCController.Instance.StartSavingVideo(CheckSickType());
                NPCController.Instance.isBeingSaved = this;
            }
            else if (GameManager.Instance.GameMode >= 0)//if gamemode then quiz
            {
                NPCController.Instance.StartSavingQuiz(CheckSickType());
                NPCController.Instance.isBeingSaved = this;
            }
        }
      
    }

    public bool CheckIfSick()
    {
        bool ifSick = isAsthma || isBleeding || isChoked || isConvulsiveSeizure || isDiabetic || isHeatStroked || isNoseBleeding || isShocked || isTickBited || isTwisted;
        if (isHealed)
        {
            ifSick = false;
        }
        return ifSick;
    }

    public int CheckSickType()
    {
        int SickType = -1;

        if (isTickBited)
            SickType = 0;
        else if (isAsthma)
            SickType = 1;
        else if (isHeatStroked)
            SickType = 2;
        else if (isShocked)
            SickType = 3;
        else if (isChoked)
            SickType = 4;
        else if (isBleeding)
            SickType = 5;
        else if (isConvulsiveSeizure)
            SickType = 6;
        else if (isNoseBleeding)
            SickType = 7;
        else if (isTwisted)
            SickType = 8;
        else if (isDiabetic)
            SickType = 9;

        return SickType;
    }

    public void BubbleSpawn()
    {
        int SickType = CheckSickType();

        // 计算生成位置（相对于当前物体的位置偏移）
        Vector3 spawnPosition = transform.position + new Vector3(0, 3, 0);

        // 实例化Prefab并设置为当前物体的子物体
        GameObject child = Instantiate(Bubble, spawnPosition, Quaternion.identity, transform);

        child.GetComponent<SpriteRenderer>().sprite = BubbleSpritePool.BubbleSprites[SickType]; 
    }

    public void BubbleVanish()
    {
        Transform bubbleTransform = transform.Find("Bubble(Clone)");

        // 检查是否找到子物体
        if (bubbleTransform != null)
        {
            // 销毁子物体
            Destroy(bubbleTransform.gameObject);
            Debug.Log("已销毁子物体 'Bubble'");
        }
    }

    public void NPCHealed()
    {

        float AddedScore;
        AddedScore = 100f - (HealTime - SickTime); 
        ScoreManager.Instance.score += AddedScore;
        ScoreManager.Instance.totalWaitingTime += HealTime - SickTime;

        isTickBited = false;
        isAsthma = false;
        isHeatStroked = false;
        isShocked = false;
        isChoked = false;
        isBleeding = false;
        isConvulsiveSeizure = false;
        isNoseBleeding = false;
        isTwisted = false;
        isDiabetic = false;

        isHealed = true;
    }

}
