using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public enum Difficulty 
    {
        Easy, Medium, Hard
    }

    public enum Event
    {
        Enter, Update, Exit
    }

    Difficulty difficultyName;
    protected Event stageOfEvent;
    protected GameObject dynamic;
    protected State nextState;

    public Difficulty DifficultyName { get => difficultyName; set => difficultyName = value; }

    public State(GameObject dynamicDifficulty)
    {
        dynamic = dynamicDifficulty;
    }

    public virtual void Enter()
    {
        stageOfEvent = Event.Update;
    }

    public virtual void Update()
    {
        stageOfEvent = Event.Update;
    }

    public virtual void Exit()
    {
        stageOfEvent = Event.Exit;
    }

    public State Process()
    {
        if (stageOfEvent == Event.Enter)
        {
            Enter();
        }

        if (stageOfEvent == Event.Update)
        {
            Update();
        }

        if (stageOfEvent == Event.Exit)
        {
            Exit();
            return nextState;
        }

        return this;
    }


}
