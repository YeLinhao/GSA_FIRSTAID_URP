using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public Animator anim { get; private set; }
    public CapsuleCollider cd { get; private set; }
    public Rigidbody rb { get; private set; }
    #endregion

    // [Header("CollisionInfo")]
    // [SerializeField] public Transform groundCheck;
    // [SerializeField] public Transform wallCheck;
    // [SerializeField] protected LayerMask whatIsGround;
    // [SerializeField] protected LayerMask whatIsWall;
    [SerializeField] public float InteractRange;
    [SerializeField] public Transform collCenter;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        cd = GetComponent<CapsuleCollider>();
    }

    protected virtual void Update()
    {

    }


}
