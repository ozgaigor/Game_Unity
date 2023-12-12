using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private bool levelComplete = false;
    private AudioSource finishSound;

    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        int collectedApples = ItemCollector.Apples;
        if (collision.gameObject.name == "Player" && !levelComplete && collectedApples >=5)
        {
            finishSound.Play();
            levelComplete = true;
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}