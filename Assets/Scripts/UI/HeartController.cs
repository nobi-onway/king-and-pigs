using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HeartController : MonoBehaviour
{
    [SerializeField] Transform _placeHeart;
    [SerializeField] GameObject _heartPrefab;
    [SerializeField] List<GameObject> _listHeart;
    [SerializeField] HealthController _healthController;


    private void Start()
    {

        _healthController.OnHealthChange += (currentHealth) =>
        {
                SetHeart(currentHealth);           
        };
        InitHeart(3);
    }
    public void InitHeart(int _countHeart)
    {
        for (int i = 0; i < _countHeart; i++)
        {
            GameObject _heartOBJ = Instantiate(_heartPrefab, _placeHeart);
            _listHeart.Add(_heartOBJ);
        }       
    }

    public void SetHeart(int currentHealth)
    {
        DisableAllHeart();
       for (int i = 0; i < currentHealth; i++)
        {
            _listHeart[i].SetActive(true);
        }
    }

    private void DisableAllHeart()
    {
        for (int i = 0; i < _listHeart.Count; i++)
        {
            _listHeart[i].SetActive(false);
        }
    }
}
