using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class UiEventsHandler : MonoBehaviour
{
    public static readonly string OnVotingSettingsUpdatedEvent = "VotingSettingUpdated";
    public static readonly string OnGoalSettingsUpdatedEvent = "GoalSettingsUpdated";
    public static readonly string OnGoalBarVisibilityToggled = "GoalProgressVisibilityUpdated";
    public static readonly string OnEffectsSettingsUpdatedEvent = "EffectsSettingUpdateEvent";

    public static UiEventsHandler Instance { get; private set; }
     
    private readonly Dictionary<string, UnityAction> m_UiEventDelegates = new Dictionary<string, UnityAction>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);
    }

    public void Subscribe(string eventName, UnityAction action)
    {
        if (m_UiEventDelegates.ContainsKey(eventName)){
            m_UiEventDelegates[eventName] += action;
        }
        else { 
            m_UiEventDelegates.Add(eventName, action); 
        }
    }

    public void Unsubscribe(string eventName, UnityAction action)
    {
        if (!m_UiEventDelegates.ContainsKey(eventName)) return;
        m_UiEventDelegates[eventName] -= action;
    }

    public void InvokeUiEvent(string eventName)
    {
        if (!m_UiEventDelegates.ContainsKey(eventName)) return;
        m_UiEventDelegates[eventName].Invoke();
    }
}
