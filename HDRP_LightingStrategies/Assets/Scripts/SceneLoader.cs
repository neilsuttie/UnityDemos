﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string _sceneName;
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
