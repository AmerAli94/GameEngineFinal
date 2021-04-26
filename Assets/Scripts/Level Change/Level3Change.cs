using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3Change : MonoBehaviour
{
    private Collider platform2collider;

     void Start()
    {
        platform2collider = GetComponent<Collider>();

    }

    private void OnTriggerEnter(Collider col)
    {
       
        if (gameObject.CompareTag("Player")) ;
        StartCoroutine(ChangeLevel3());
    }

    IEnumerator ChangeLevel3()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(3);

    }
}
