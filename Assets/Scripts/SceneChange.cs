using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeSecene1()
    {
        SceneManager.LoadScene(0);
    }
    public void ChangeSecene2()
    {
        SceneManager.LoadScene(1);
    }
    public void ChangeSecene3()
    {
        SceneManager.LoadScene(2);
    }
}
