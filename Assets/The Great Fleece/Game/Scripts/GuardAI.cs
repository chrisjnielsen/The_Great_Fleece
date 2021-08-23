using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{

    public List<Transform> wayPoints;
    private NavMeshAgent _agent;
    private int _currentTarget = 0;
    private bool _reverseCount = false;
    private bool _targetReached = false;
    private Animator _anim;
    public bool coinToss = false;
    public Vector3 coinPos;


    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (wayPoints.Count > 0 && wayPoints[_currentTarget] != null && coinToss ==false)
        {
            _agent.SetDestination(wayPoints[_currentTarget].position);        
            float distance = Vector3.Distance(transform.position, wayPoints[_currentTarget].position);

            if (distance < 1 && (_currentTarget ==0 || _currentTarget == wayPoints.Count-1))
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", false);
                }
                
            }
            else
            {
                if (_anim != null)
                {
                    _anim.SetBool("Walk", true);
                }
                
            }

            if (distance < 1f && _targetReached == false)
            {
                if (wayPoints.Count < 2)
                {
                    return;
                }
                if (_currentTarget==0 || _currentTarget == wayPoints.Count - 1)
                {
                    _targetReached = true;
                    StartCoroutine(WaitBeforeMoving());
                }
                else
                {
                   
                    if (_reverseCount == true)
                    {
                        _currentTarget--;
                        if (_currentTarget <= 0)
                        {
                            _reverseCount = false;
                            _currentTarget = 0;
                        }
                    }
                    else
                    {
                        _currentTarget++;
                    }
                }
            }
        }
        else
        {
            //chasing coin
            float distance = Vector3.Distance(transform.position, coinPos);
            if (distance < 3f)
            {
                _anim.SetBool("Walk", false);
            }
        }
    }

    IEnumerator WaitBeforeMoving()
    {
        if (_currentTarget == 0)
        {
            yield return new WaitForSeconds(Random.Range(2f, 6f));
        }
        else if (_currentTarget == wayPoints.Count-1)
        {
            yield return new WaitForSeconds(Random.Range(2f, 6f));
        }

        if (_reverseCount == true)
        {
            _currentTarget--;
            if (_currentTarget == 0)
            {
                _reverseCount = false;
            }
        }
        else if (_reverseCount == false)
        {
            _currentTarget++;
            if (_currentTarget == wayPoints.Count)
            {
                _reverseCount = true;
                _currentTarget--;
            }
        }
        _targetReached = false;
    }

}
