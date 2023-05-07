using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public delegate void EventMethod(params object[] parameters);

    public static Dictionary<EventEnum, EventMethod> EventsContainer = new Dictionary<EventEnum, EventMethod>();

    public static void Subscribe(EventEnum eventName, EventMethod observer)
    {
        if (!EventsContainer.ContainsKey(eventName))
            EventsContainer.Add(eventName, observer);
        else
            EventsContainer[eventName] += observer;
    }

    public static void Unsubscribe(EventEnum eventName, EventMethod observer)
    {
        if (!EventsContainer.ContainsKey(eventName)) return;

        EventsContainer[eventName] -= observer;
    }

    public static void Trigger(EventEnum eventName)
    {
        Trigger(eventName, null);
    }

    public static void Trigger(EventEnum eventName, params object[] parameters)
    {
        if (!EventsContainer.ContainsKey(eventName)) return;

        EventsContainer[eventName](parameters);
    }
}