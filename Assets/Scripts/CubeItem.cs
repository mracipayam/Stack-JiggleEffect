using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeItem : MonoBehaviour
{

    private MeshRenderer meshRenderer;

    public MeshRenderer MeshRenderer => meshRenderer;
    
    private Rigidbody rigidbody;

    public Rigidbody Rigidbody => rigidbody;
    
    private HingeJoint joint;

    public HingeJoint Joint => joint;


    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        InitComponents();
    }

    private void InitComponents()
    {
        rigidbody = GetComponent<Rigidbody>();
        joint = GetComponent<HingeJoint>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    
}
