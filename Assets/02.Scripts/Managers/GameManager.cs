using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletoneBase<GameManager>
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int totalScore =0;


    public Vector2 startPos = new Vector3(-8f, 0, -10f);
    [CanBeNull] public Transform checkPoint;
    //TODO : 체크포인트 지나쳤는지 저장.
    
    
    
    public override void Init()
    {
        
    }

    public void OnScoreUp()
    {
        totalScore++;
        ScoreUIUpdate();
    }

    private void ScoreUIUpdate()
    { 
        _scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        _scoreText.text = totalScore.ToString();
    }
}
