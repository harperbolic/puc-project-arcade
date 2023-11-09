using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource src;
    public AudioClip shoot, die, hurt;

    public void
    {
	src.clip = shoot;
	src.Play();
    }

    public void
    {
	src.clip = die;
	src.Play();
    }

    public void
    {
	src.clip = hurt;
	src.Play();
    }
}
