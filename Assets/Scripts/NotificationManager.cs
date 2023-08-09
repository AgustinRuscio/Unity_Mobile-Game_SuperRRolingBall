using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;


public class NotificationManager : MonoBehaviour
{
    public static NotificationManager Instance { get; private set; }
    AndroidNotificationChannel notifChannel;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }            
        else Destroy(this);

        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        AndroidNotificationCenter.CancelAllScheduledNotifications();

        notifChannel = new AndroidNotificationChannel()
        {
            Id = "reminder_notif_ch",
            Name = "Reminder Notification",
            Description = "Disturb the User",
            Importance = Importance.High

        };

        AndroidNotificationCenter.RegisterNotificationChannel(notifChannel);

        DisplayNotification("Te extrañamos!", "Volve a jugar con nosotros", DateTime.Now.AddDays(3));



    }

   
   


    public int DisplayNotification(string tittle, string text, DateTime fireTime)
    {
        var notification = new AndroidNotification();
        notification.Title = tittle;
        notification.Text = text;
        notification.SmallIcon = ""; // falta poner los iconos en proyectr settings - mobile notifications
        notification.LargeIcon= "";
        notification.FireTime = fireTime; //cambiar a horas para unn juego normal, ponemos seconds para testeo de este.

        return AndroidNotificationCenter.SendNotification(notification, notifChannel.Id);

    }

    public void CancelNotification(int id)
    {
        AndroidNotificationCenter.CancelScheduledNotification(id);
    }
}
