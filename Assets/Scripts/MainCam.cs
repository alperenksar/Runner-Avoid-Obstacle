using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCam : MonoBehaviour
{
    private PlayerController playerScript;
    public AudioSource mySound;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        mySound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.GameOver == true)
        {
            mySound.Stop();
        }
    }
}
