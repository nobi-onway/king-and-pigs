using System.Collections;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private DialogName _dialog;
    [SerializeField]
    private float _delayTime;
    [SerializeField]
    private float _duration;

    private void Start()
    {
        StartCoroutine(Play(_dialog));
    }

    private IEnumerator Play(DialogName dialogName)
    {
        while(true)
        {
            string name = dialogName.ToString();
            _animator.Play($"{name}_in");
            yield return new WaitForSeconds(_duration);
            _animator.Play($"{name}_out");
            yield return new WaitForSeconds(_delayTime);
        }
    }
}

public enum DialogName { hello, idle, surprised, loser }
