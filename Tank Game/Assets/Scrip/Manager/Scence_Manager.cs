using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Scence_Manager : MonoBehaviour
{
    protected    string nameScence;

    public void loadScence(string cc)
    {
        SceneManager.LoadScene(cc);
    }
}
