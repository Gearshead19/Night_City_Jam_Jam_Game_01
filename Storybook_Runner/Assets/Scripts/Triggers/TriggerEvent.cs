using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerEvent : MonoBehaviour
{

    [SerializeField]
    private UnityEvent triggerThis;


    public void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            triggerThis.Invoke();
        }
    }
}
