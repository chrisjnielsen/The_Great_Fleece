using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateActivation : MonoBehaviour
{
    //on trigger enter
    //check for darren
    //check game manager for key card
    //trigger win cutscene
    //else print out a message that you must have the key card

    [SerializeField]
    private GameObject _winCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.HasCard == true)
            {
                _winCutscene.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("You must have the key card!");
            }
        }
    }
}
