using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    NavMeshAgent agent;
    Rigidbody rigid;
    float rotatedAng;
    float preAngles ;
    Animator animator;
    float velocity;

    public float RotatedAng { 
        get => rotatedAng;
        set
        {
            rotatedAng = value;
            if (value > 0.4f)
            {
                rotatedAng = 0.4f;
            }
            else if(value < -0.4f)
            {
                rotatedAng = -0.4f;
            }
            
        }
    }

    public float Velocity { 
        get => velocity;
        set
        {
            velocity = value;
            if (value > 3.4f)
            {
                velocity = 3.4f;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
        if (Time.frameCount > 0)
        {
            //print(120 * Time.deltaTime);s
            RotatedAng = preAngles - transform.rotation.eulerAngles.y;

            animator.SetFloat("rotateAngle", RotatedAng);
            Velocity = agent.velocity.magnitude;
            animator.SetFloat("velocity", velocity);
        }

        preAngles = transform.rotation.eulerAngles.y;


    }
}
