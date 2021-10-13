using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource AudSrc;

    // Start is called before the first frame update
    void Start()
    {
        AudSrc = this.GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        PlayerMove.damageTaken += PlaySound;
    }

    private void OnDisable()
    {
        PlayerMove.damageTaken -= PlaySound;
    }

    private void PlaySound()
    {
        AudSrc.Play();
    }
}
