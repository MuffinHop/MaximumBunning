using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DestructionVisual : MonoBehaviour
{
    [SerializeField] private Sprite[] _destructionSprites;
    [SerializeField] private Points _points;
    [SerializeField] private String[] _courageText;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    private int _pointsBefore;
    private Image _image;
    void Start()
    {
        _image = GetComponent<Image>();
    }

    private void HideText()
    {
        _textMeshPro.text = "";
    }
    void Update()
    {
        _textMeshPro.rectTransform.rotation =Quaternion.Euler(new Vector3(0f,0f, Mathf.Sin(Time.time*3f) * 3f + Mathf.Sin(Time.time) * 10f));
        if (_points.GetScore() < 200)
        {
            _image.sprite = _destructionSprites[0];
        } else if (_points.GetScore() < 900)
        {
            _image.sprite = _destructionSprites[1];
            if (_pointsBefore > 800)
            {
                _textMeshPro.text = _courageText[0].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 1900)
        {
            _image.sprite = _destructionSprites[2];
            if (_pointsBefore > 1800)
            {
                _textMeshPro.text = _courageText[1].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 2900)
        {
            _image.sprite = _destructionSprites[3];
            if (_pointsBefore > 2800)
            {
                _textMeshPro.text = _courageText[2].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 3900)
        {
            _image.sprite = _destructionSprites[4];
            if (_pointsBefore > 3800)
            {
                _textMeshPro.text = _courageText[3].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 4900)
        {
            _image.sprite = _destructionSprites[5];
            if (_pointsBefore > 4800)
            {
                _textMeshPro.text = _courageText[4].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 5900)
        {
            _image.sprite = _destructionSprites[6];
            if (_pointsBefore > 5800)
            {
                _textMeshPro.text = _courageText[5].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 6900)
        {
            _image.sprite = _destructionSprites[7];
            if (_pointsBefore > 6800)
            {
                _textMeshPro.text = _courageText[6].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 7900)
        {
            _image.sprite = _destructionSprites[8];
            if (_pointsBefore > 7800)
            {
                _textMeshPro.text = _courageText[7].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 8900)
        {
            _image.sprite = _destructionSprites[9];
            if (_pointsBefore > 8800)
            {
                _textMeshPro.text = _courageText[8].ToUpper();
                Invoke("HideText", 2f);
            }
        } else if (_points.GetScore() < 9900)
        {
            _image.sprite = _destructionSprites[10];
            if (_pointsBefore > 9800)
            {
                _textMeshPro.text = _courageText[9].ToUpper();
                Invoke("HideText", 2f);
            }
        }
        else
        {
            _image.sprite = _destructionSprites[11];
            
            BunController.DONE = true;
        }

        _pointsBefore = _points.GetScore();
    }
}
