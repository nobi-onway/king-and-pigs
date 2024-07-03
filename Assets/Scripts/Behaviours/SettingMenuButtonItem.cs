using UnityEngine;
using UnityEngine.UI;

public class SettingMenuButtonItem : MonoBehaviour
{
    [HideInInspector] public Image _img;
    [HideInInspector] public Transform _trans;

    private void Awake()
    {
        _img = GetComponent<Image>();
        _trans = transform;
    }
}
