using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoreEvent : UnityEvent<int>
{
}
public class Points : MonoBehaviour
{
    public ScoreEvent ScorePoints;
    private int _targetScore;
    private int _score;
    private TextMeshProUGUI _textMeshPro;

    public int GetScore()
    {
        return _score;    
    }
    void Start()
    {
        _textMeshPro = transform.GetComponent<TextMeshProUGUI>();
        ScorePoints.AddListener(Score);
        _score = 0;
    }

    void Score(int points)
    {
        _targetScore += points;
    }

    void Update()
    {
        if (_targetScore > _score)
        {
            _score += 5;
            transform.localScale = new Vector3(1f + (Time.frameCount % 4) / 8f,1f + (Time.frameCount % 4) / 8f,1f);
        }
        else
        {
            transform.localScale = new Vector3(1f,1f,1f);
        }
        _textMeshPro.text = _score.ToString();
    }
}
