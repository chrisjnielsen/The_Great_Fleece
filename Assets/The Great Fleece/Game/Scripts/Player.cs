using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;

    private Animator anim;
    private Vector3 target;
    [SerializeField]
    private GameObject _coin;
    [SerializeField]
    private AudioClip _coinAudio;
    private bool _canThrowCoin = true;


    void Start()
    {
        agent = GetComponent < NavMeshAgent >();
        anim = GetComponentInChildren<Animator>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                agent.SetDestination(hitInfo.point);
                anim.SetBool("Walk", true);
                target = hitInfo.point;
            }
        }

        float dist = Vector3.Distance(transform.position, target);
        if (dist < 1.0f)
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetMouseButtonDown(1) && _canThrowCoin == true)
        {
            
            Ray rayOrigin = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            if (Physics.Raycast(rayOrigin, out hitInfo))
            {
                anim.SetTrigger("Throw");
                target = hitInfo.point;
                SendAItoCoinSpot(target);
                Instantiate(_coin, target, Quaternion.identity);
                AudioSource.PlayClipAtPoint(_coinAudio, target);
                _canThrowCoin = false;
            }
        }
    }

    void SendAItoCoinSpot(Vector3 coinpos)
    {
        GameObject[] guards = GameObject.FindGameObjectsWithTag("Guard1");
        //go through each guard
        foreach(var guard in guards)
        {
            NavMeshAgent currentAgent = guard.GetComponent<NavMeshAgent>();
            GuardAI currentGuard = guard.GetComponent<GuardAI>();
            Animator currentAnim = guard.GetComponent<Animator>();

            currentGuard.coinToss = true;
            currentAgent.SetDestination(coinpos);
            currentAnim.SetBool("Walk", true);
            currentGuard.coinPos = coinpos;
        }
    }
}
