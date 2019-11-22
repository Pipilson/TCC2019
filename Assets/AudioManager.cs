﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Seguido esse tutorial: https://www.youtube.com/watch?v=o381sP1G5bA */
public class AudioManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string jumpSound, fallSound;

    public void JumpSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(jumpSound);
    }

    public void FallSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(fallSound);
    }
}