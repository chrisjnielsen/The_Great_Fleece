using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameOverScene;

    public Animator anim;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.enabled = false;
            MeshRenderer render = GetComponent<MeshRenderer>();
            Color color = new Color(0.6f, .1f, .1f, .3f);
            render.material.SetColor("_TintColor", color);
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1f);
        _gameOverScene.gameObject.SetActive(true);
    }
}
