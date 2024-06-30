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

    private List<IController> _characterControllerList;

    private bool _isActive;
    public bool IsActive
    {
        get => _isActive;
        set
        {
            _isActive = value;
            gameObject.SetActive(value);

            if (_isActive) LoadCharacters();
            if (!_isActive) ResetCharacters();
        }
    }

    private void LoadCharacters()
    {
        _characterControllerList = new List<IController>();
        for(int i = 0; i < _characterPositionList.Count; i++)
        {
            CharacterPosition characterPosition = _characterPositionList[i];
            IController controllerClone = Instantiate(characterPosition.Character).GetComponent<IController>();

            controllerClone.Init();
            _characterControllerList.Add(controllerClone);
            characterPosition.SetUpPosition();
        }
    }

    private void ResetCharacters()
    {
        if (_characterControllerList == null) return;

        for (int i = 0; i < _characterControllerList.Count; i++)
        {
            IController controller = _characterControllerList[i];
            controller.Reset();
        }
    }

    public PlayerController GetPlayer()
    {
        PlayerController playerController = null;

        for (int i = 0; i < _characterControllerList.Count; i++)
        {
            playerController = _characterControllerList[i].MonoBehaviour.GetComponent<PlayerController>();

            if (playerController) break;
        }

        return playerController;
    }
}
