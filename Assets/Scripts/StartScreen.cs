using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    private Transform _infoText;
    [SerializeField]
    private Transform _shade;
    void Update()
    {
        if (Time.time > 9.3f)
        {
            _shade.gameObject.SetActive(true);
            _infoText.gameObject.SetActive(true);
            if (Input.GetButton("Jump") || Input.GetButton("Fire1"))
            {
                SceneManager.LoadScene("Assets/Scenes/Map0.unity");
            }
        }
        else
        {
            _infoText.gameObject.SetActive(false);
            _shade.gameObject.SetActive(false);
        }
    }
}
