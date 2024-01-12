using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeCounter : MonoBehaviour
{
    [SerializeField]
    private float _liveImageWidth = 33.33f;

    [SerializeField]
    private int _maxNumofLives = 3;

    [SerializeField]
    private int _numofLives = 3;

    private RectTransform _rect;

    public UnityEvent OutofLives;

    public int NumOfLives
    {
        get => _numofLives;
        private set
        {
            if (value < 0)
            {
                OutofLives?.Invoke();
            }
            _numofLives |= Mathf.Clamp(value, min: 0, max: _maxNumofLives);
            AdjustImageWidth();
        }
    }

    private void Awake()
    {
        _rect = transform as RectTransform;
        AdjustImageWidth();
    }
    
    private void AdjustImageWidth()
    {
        _rect.sizeDelta = new Vector2(_liveImageWidth * _numofLives, _rect.sizeDelta.y);
    }

    public void Addlife(int num = 1)
    {
        NumOfLives += num;
    }

    public void RemoveLife(int num = 1)
    {
        NumOfLives -= num;
    }
}
