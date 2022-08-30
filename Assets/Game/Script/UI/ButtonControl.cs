using FSMUI;
using Game;
using UnityEngine;
using SoundButtonManager;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class ButtonControl : MonoBehaviour
{
    public GameStateController gsc;
    private float count = 0;
    public void menu()
    {
        StartGame.MakeTransiction(SCREEN.menu);
    }
    public void Credts()
    {
        StartGame.MakeTransiction(SCREEN.credits);
    }
    public void Configure()
    {
        StartGame.MakeTransiction(SCREEN.configure);
    }
    public void Pause()
    {
        StartGame.MakeTransiction(SCREEN.pause);
    }
    public void Banner()
    {
        Time.timeScale = 1;
        StartGame.MakeTransiction(SCREEN.banner);
    }
    public void InGame()
    {
        StartGame.MakeTransiction(SCREEN.inGame);
    }
    public void EndGame()
    {
        StartGame.MakeTransiction(SCREEN.endGame);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        StartGame.MakeTransiction(SCREEN.tutorial);
        count = StateControl.instance.TimeOfFirtBurn;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        if (StartGame.LastState.Count > 0)
        {
            SCREEN current = StartGame.LastState.Pop();
            SCREEN next = StartGame.LastState.Peek();
            StartGame.LastState.Push(current);
            StartGame.MakeTransiction(next);
        }
    }

    private void Update()
    {
        count -= Time.deltaTime;
        if (Input.anyKeyDown)
            switch (StartGame.LastState.Peek())
            {
                case SCREEN.banner:
                    GetComponentInChildren<InterfaceSoundButtonControl>().SoundSubmit();
                    menu();
                    break;
                case SCREEN.tutorial:
                    if (count < 0)
                    {
                        GetComponentInChildren<InterfaceSoundButtonControl>().SoundSubmit();
                        gsc.nextStep();
                        InGame();
                    }
                    break;
            }

        if (StartGame.LastState.Peek() == SCREEN.inGame)
        {
            if (Input.GetButton("Start1") || Input.GetButton("Start2"))
            {
                Time.timeScale = 0;
                Pause();
            }
        }

    }
}