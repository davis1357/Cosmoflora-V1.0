﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public void BackToSpace()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<Player>().enabled = true;
    }

    public void IntoPlanet()
    {
        SceneManager.LoadScene(1);
    }
}
