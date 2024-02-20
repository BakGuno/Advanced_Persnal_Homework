using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    [Header("이동 위치, 대기시간, 이동시간")]
    [SerializeField] private Vector3 _targetPos;
    [SerializeField] private float _waitTime;
    [SerializeField] private float _durationTime;
    private WaitForSeconds _wait;
    private bool isDone = false;
    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _wait = new WaitForSeconds(_waitTime);
        StartCoroutine(nameof(Drop));
    }
    
    IEnumerator Drop() {
        
        yield return _wait;
        while (!isDone)
        {
            _rectTransform.DOAnchorPos(_targetPos, _durationTime).SetEase(Ease.OutQuad).OnComplete(()=>
            {
                isDone = true;
            });
            yield return null;
        }
    }
}
