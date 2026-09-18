using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class court : MonoBehaviour
{
    public EventTrigger.TriggerEvent courtTrigger;

    private void OnCollisionEnter2D(Collision2D other)
    {
       BaseEventData eventData = new BaseEventData(EventSystem.current);
       courtTrigger.Invoke(eventData);
    }
}
