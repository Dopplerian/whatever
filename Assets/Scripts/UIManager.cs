using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class UIManager : MonoBehaviour
{
    [Tooltip("The greeting prompt Game Object to show when onboarding begins.")]
    [SerializeField]
    GameObject m_GreetingPrompt;

    public GameObject greetingPrompt
    {
        get => m_GreetingPrompt;
        set => m_GreetingPrompt = value;
    }

    [Tooltip("The greeting prompt Game Object to show when onboarding begins.")]
    [SerializeField]
    GameObject m_ShootButton;

    public GameObject shootButton
    {
        get => m_ShootButton;
        set => m_ShootButton = value;
    }

    void Update()
    {

    }

    public void StartCoaching()
    {
        m_GreetingPrompt.SetActive(false);
        m_ShootButton.SetActive(true);
        // m_SurfaceUI.SetActive(true);
    }
}
