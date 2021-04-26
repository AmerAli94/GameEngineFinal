using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class Win : MonoBehaviour
{

    private Collider WinCollider;

    void Start()
    {
        WinCollider = GetComponent<Collider>();
        Cursor.visible = true;

    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collided");
        if (gameObject.CompareTag("Player")) ;
            StartCoroutine(LoadWin());
        
    }

    IEnumerator LoadWin()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene(4);
    }

    public void OnClickRestart()
    {
        SceneManager.LoadScene(0);
    }
}
