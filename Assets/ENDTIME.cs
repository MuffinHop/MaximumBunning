using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ENDTIME : MonoBehaviour
{
    void Update()
    {
        if (Time.timeSinceLevelLoad > 15f)
        {
            SceneManager.LoadScene("Assets/Scenes/Title Screen.unity");
        }
    }
}
