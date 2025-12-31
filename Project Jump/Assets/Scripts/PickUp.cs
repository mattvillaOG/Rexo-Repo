using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    public int scoreToGive;

    private ScoreManager theScoreManager;

    private AudioSource eatingSound;

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();

        eatingSound = GameObject.Find("EatingSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Rexo.JJ")
        {
            theScoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);

            if (eatingSound.isPlaying)
            {
                eatingSound.Stop();
                eatingSound.Play();
            }
            else
            {

                eatingSound.Play();
            }
        }
    }
}
