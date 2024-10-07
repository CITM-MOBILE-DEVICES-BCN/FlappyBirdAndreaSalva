using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicManagerScript logic;
    public AudioSource Trigger;
    public AudioClip Sound;
    public float Volume = 1;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.addScore();
        Trigger.PlayOneShot(Sound, Volume);
    }
}
