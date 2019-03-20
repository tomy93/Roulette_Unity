using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DoInSeconds : MonoBehaviour
{
    [SerializeField] private bool workOnEnable;
    [SerializeField] private float seconds;
    [SerializeField] private UnityEvent onSeconds;

    private void OnEnable()
    {
        if (workOnEnable)
        {
            StartCoroutine(DoThis());
        }
    }

    private IEnumerator DoThis()
    {
        yield return new WaitForSeconds(seconds);
        if (onSeconds != null)
        {
            onSeconds.Invoke();
        }
    }
}
