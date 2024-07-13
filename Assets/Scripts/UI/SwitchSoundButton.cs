using UnityEngine;
using UnityEngine.UI;

public class SwitchSoundButton : MonoBehaviour
{
    private Button _switchSoundButton;
    [SerializeField]
    private Image _imagge;
    [SerializeField]
    private Sprite _soundOpenSprite;
    [SerializeField]
    private Sprite _soundCloseSprite;

    private void Start()
    {
        _switchSoundButton = GetComponent<Button>();

        UpdateSprite();

        _switchSoundButton.onClick.AddListener(() =>
        {
            bool isSoundOpened = SfxManager.Instance.IsOpenSound;
            SfxManager.Instance.IsOpenSound = !isSoundOpened;

            UpdateSprite();
        });
    }

    private void UpdateSprite()
    {
        _imagge.sprite = SfxManager.Instance.IsOpenSound ? _soundOpenSprite : _soundCloseSprite;
    }
}
