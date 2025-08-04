using UnityEngine;
using UnityEngine.Events;

public class ButtonGroup : MonoBehaviour
{
    [Header("Event Callback")]
    [Space(4f)]
    public UnityEvent onMove;
    public UnityEvent onReturned;

    [Header("Debug Information")]
    public int count;
    
    public void Press()
    {
        onMove.Invoke();
    }

    public void Release()
    {
        onReturned.Invoke();
    }
}