using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CardGame), typeof(InputManagerSystem), typeof(MainMenuBehaviour))]
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// Singeltone of the Game Manager.
    /// </summary>
    public static GameManager m_GameManager;
    private void Awake()
    {
        if (m_GameManager == null)
        {
            m_GameManager = this;
        }
        else
        {
            Destroy(m_GameManager);
            return;
        }
    }

    //-------------------------------------------
    //GAME MANAGER CODE
    //-------------------------------------------
    [HideInInspector] public CardGame m_Card_Game;
    [HideInInspector] public InputManagerSystem m_InputManagerSystem;
    [HideInInspector] public MainMenuBehaviour m_MainMenuBehaviour;
    //private JuegodeOstias m_Fight_Game; aqui va el juego de pegarse

    private void Start()
    {
        m_Card_Game = GetComponent<CardGame>();
        m_InputManagerSystem = GetComponent<InputManagerSystem>();
        m_MainMenuBehaviour = GetComponent<MainMenuBehaviour>();
    }

    /// <summary>
    /// Activate the next scene change.
    /// </summary>
    /// <param name="buildIndex"> Index of the scene wanted</param>
    private void f_NextSceneActivation(int buildIndex)
    {
        StartCoroutine(NextSceneAsync(buildIndex));
    }

    IEnumerator NextSceneAsync(int buildIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(buildIndex);
        operation.allowSceneActivation = false;
        while (!operation.isDone)
        {
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }


}
