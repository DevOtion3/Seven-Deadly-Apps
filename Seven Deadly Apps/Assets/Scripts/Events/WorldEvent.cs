using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Similar to SpookyEvent however this class simply sends a unity message/event to a predetermined gameobject such as a boss, gives a simple way to send events to gameobjects
*/

public class WorldEvent : MonoBehaviour{
    public bool onlyTriggerOnce;
    public WorldEventData[] messages;

    bool hasBeenTriggered;

    void OnTriggerEnter(Collider collider){
        if(!hasBeenTriggered && onlyTriggerOnce || !onlyTriggerOnce){
            Debug.Log("Triggered");
            foreach(WorldEventData eventData in messages){
                eventData.target.SendMessage(eventData.messageName, eventData.messageData);
            }

            hasBeenTriggered = true;            
        }
    }
    
    [System.Serializable] public class WorldEventData{
        public GameObject target;
        public string messageName;
        public string messageData;
    }
}
