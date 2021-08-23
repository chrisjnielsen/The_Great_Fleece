using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCard : MonoBehaviour
{
    [SerializeField]
    private GameObject _sleepingGuardCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _sleepingGuardCutscene.gameObject.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }

}
