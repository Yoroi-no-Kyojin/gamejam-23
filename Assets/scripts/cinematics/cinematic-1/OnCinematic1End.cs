using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCinematic1End : OnCinematicEndListener
{
    public override void Listen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("world");
    }
}
