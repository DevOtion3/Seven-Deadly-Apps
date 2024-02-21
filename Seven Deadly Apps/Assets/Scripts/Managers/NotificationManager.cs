using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*
Used to manage the ui for the "notifications"
*/

public class NotificationManager : Singleton<NotificationManager>
{
    public TextMeshPro textBox;
    public Animation animator;

    public void SendNotification(string msg){
        textBox.text = msg;
        animator.Play("Notification Arrive");
    }
}
