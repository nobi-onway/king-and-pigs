using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Transform _placeHeart;
    [SerializeField] private HeartController _heartController;
    public HealthController HealthController { get; set; }

    private List<HeartController> _listHeart;
    private int _currentHeart => _listHeart.FindAll(heart => heart.IsActive).Count;

    public void Init(int health)
    {
        ResetHeartList();

        _listHeart = new List<HeartController>();

        for (int i = 0; i < health; i++)
        {
            HeartController heartController = Instantiate(_heartController.gameObject, _placeHeart).GetComponent<HeartController>();
            heartController.IsActive = true;

            _listHeart.Add(heartController);
        }

        HealthController.OnHealthChange += SetHeart;
    }

    private void ResetHeartList()
    {
        for(int i = 0; i < _placeHeart.childCount; i++)
        {
            Destroy(_placeHeart.GetChild(i).gameObject);
        }
    }

    private void SetHeart(int currentHealth)
    {
       if(currentHealth < _currentHeart) DisableHearts(currentHealth);
       if (currentHealth > _currentHeart) EnableHearts(currentHealth);
    }

    private void DisableHearts(int health)
    {
        int count = health < 0 ? 0 : health;

        for (int i = _currentHeart - 1; i >= count; i--)
        {
            _listHeart[i].IsActive = false;
        }
    }

    private void EnableHearts(int health)
    {
        for(int i = _currentHeart - 1; i <= health; i++)
        {
            _listHeart[i].IsActive = true;
        }
    }
}
