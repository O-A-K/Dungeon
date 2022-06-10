using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class OK_NavCharacterController : MonoBehaviour
{
    //Creates a variable for the navmesh agent on the PC and an animator so that we can tie movement to animations.
    private NavMeshAgent navMeshAgent;
    private Vector3 inputValue = Vector3.zero;
    public float speed = 0;

    void Awake()
    {
        //Grab the navmesh agent and animator attached to this game object
        navMeshAgent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
    }

    void OnEnable()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        CharMovement();
    }

    void CharMovement()
    {
        Vector3 newPosition = transform.position + inputValue * Time.deltaTime * speed;
        NavMeshHit hit;
        bool isValid = NavMesh.SamplePosition(newPosition, out hit, .3f, NavMesh.AllAreas);

        if(isValid)
        {
            if ((transform.position - hit.position).magnitude >= .02f)
            {
                navMeshAgent.destination = hit.position;

            }
        }
        
        //Set animator to idle
        //if (input.magnitude <=0)
        //{
        //    animator.SetFloat("Walk", 0f);
        //    return;
        //}
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input2D = context.ReadValue<Vector2>();
        inputValue.x = input2D.x;
        inputValue.z = input2D.y;
    }
    public void OnDisable()
    {
        //controls.gameplay.Disable();
    }
}
