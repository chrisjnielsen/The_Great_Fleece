using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    //ability to detect Darren when caught in eye
    //void ontriggerenter
    //check collider hits Darren, tag of "Player"
    //enable game over cutscene, get reference to object and set active
    [SerializeField]
    private GameObject _gameOverCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _gameOverCutscene.gameObject.SetActive(true);
        }
    }
}
