using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private List<CubeItem> cubeItems = new List<CubeItem>();
    [SerializeField] private CubeItem _cubePrefab;
    private float Yposition;
    
    void Start()
    {
        CreateCubes();
        StackWithJoint(_cubePrefab,cubeItems[cubeItems.Count-1]);
        StackWithJoint(_cubePrefab,cubeItems[cubeItems.Count-1]);
        StackWithJoint(_cubePrefab,cubeItems[cubeItems.Count-1]);
    }

    
    private void CreateCubes()
    {
        for (int i = 0; i < 6; i++)
        {
            var gameObject = Instantiate(_cubePrefab, transform);
            cubeItems.Add(gameObject);
            gameObject.transform.localPosition = new Vector3(0, Yposition, 0);
            Yposition += 1.1f;
        }

        for (int i = 0; i < cubeItems.Count - 1; i++)
        {  
            cubeItems[i].Joint.connectedBody = cubeItems[i + 1].Rigidbody;
        }

        for (int i = 1; i < cubeItems.Count; i++)
        {
            cubeItems[i].Rigidbody.isKinematic = false;
        }

        Destroy(cubeItems[cubeItems.Count - 1].Joint);
    }
    
    [ContextMenu("Create Cubes")]
    private void StackWithJoint(CubeItem cubeItem,CubeItem previousCube)
    {
        var createdObject = Instantiate(cubeItem, transform.position,Quaternion.identity);
        
        createdObject.transform.localPosition = new Vector3(previousCube.gameObject.transform.position.x, previousCube.gameObject.transform.position.y + 1.1f, previousCube.gameObject.transform.position.z);
        createdObject.GetComponent<MeshRenderer>().material.color = Color.blue;
        var previousJoint = previousCube.AddComponent<HingeJoint>();
        previousJoint.useSpring = true;
        JointSpring jointSpring = new JointSpring();
        jointSpring.spring = 5000f;
        jointSpring.damper = 800;
        previousJoint.spring = jointSpring;
        previousJoint.enableCollision = true;
        previousJoint.massScale = 4;
        previousJoint.connectedMassScale = 10;
        var rb = createdObject.GetComponent<Rigidbody>();
        previousJoint.connectedBody = rb;
        rb.isKinematic = false;
        cubeItems.Add(createdObject);
        Destroy(cubeItems[cubeItems.Count - 1].Joint);
        
    }

    

    
    
}
