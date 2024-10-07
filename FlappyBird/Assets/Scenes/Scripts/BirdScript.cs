using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BirdScript : MonoBehaviour
{

    public Rigidbody2D myRigidbody;
    public float flapStrength = 10;
    public LogicManagerScript logic;
    public bool birdIsAlive = true;

    public AudioSource TriggerBird;
    public AudioClip SoundBird;
    public float VolumeBird = 1;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && birdIsAlive == true) 
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        if(transform.position.y > 14 || transform.position.y < -14)
        {
            logic.gameOver();
            birdIsAlive = false;
            TriggerBird.PlayOneShot(SoundBird, VolumeBird);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        TriggerBird.PlayOneShot(SoundBird, VolumeBird);
        Destroy(gameObject);
    }
}
