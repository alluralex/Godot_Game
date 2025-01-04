using Godot;
using System;
using Сохранялкагодота.Mechanics;

public partial class CardStates : Node
{
    public enum State
    {
        BASE,
        CLICKED,
        DRAGGING,
        AIMING,
        RELEASED
    }

    [Signal]
    public delegate void TransitionRequestedEventHandler(CardStates from, State to);

    [Export]
    public State CurrentState { get; set; }

    public Cardui CardUI { get; set; }

    public virtual void Enter()
    {
        // Действия при входе в состояние
    }

    public virtual void Exit()
    {
        // Действия при выходе из состояния
    }

    public virtual void OnInput(InputEvent @event)
    {
        // Обработка ввода
    }

    public virtual void OnGuiInput(InputEvent @event)
    {
        // Обработка GUI-ввода
    }

    public virtual void OnMouseEntered()
    {
        // Действия при наведении мыши
    }

    public virtual void OnMouseExited()
    {
        // Действия при уходе мыши
    }
}
