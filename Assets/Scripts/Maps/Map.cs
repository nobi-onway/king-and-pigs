using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterPosition
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private GameObject _character;
    public GameObject Character => _character;

    public void SetUpPosition()
    {
        _character.transform.position = _transform.position;
    }
}

public class Map : MonoBehaviour
{
    [SerializeField]
    private List<CharacterPosition> _characterPositionList;

    private bool _isActive;
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            gameObject.SetActive(value);
        }
    }

    private void Start()
    {
        LoadCharacters();
    }

    private void LoadCharacters()
    {
        for(int i = 0; i < _characterPositionList.Count; i++)
        {
            CharacterPosition characterPosition = _characterPositionList[i];
            Instantiate(characterPosition.Character);
            characterPosition.SetUpPosition();
        }
    }
}
