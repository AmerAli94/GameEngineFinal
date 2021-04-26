using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Change : MonoBehaviour
{
    private Collider platformcollider;

     void Start()
    {
        platformcollider = GetComponent<Collider>();

    }

    private void OnTriggerEnter(Collider col)
    {
       
        if (gameObject.CompareTag("Player")) ;
        StartCoroutine(ChangeLevel2());
    }

    IEnumerator ChangeLevel2()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(2);

    }
}
