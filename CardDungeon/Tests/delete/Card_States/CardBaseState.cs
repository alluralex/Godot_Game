using Godot;
using System;

public partial class CardBaseState : CardStates
{
    public override void Enter()
    {
        // Убедиться, что нода готова
        if (!CardUI.IsInsideTree())
        {
            CallDeferred(nameof(Enter));
            return;
        }

        // Вызвать событие смены родителя
        CardUI.EmitSignal(nameof(CardUI.Reparent), CardUI);

        // Установить цвет и состояние
        //CardUI.GetThemeColor().GetHashCode = Colors.WebGreen;
        //CardUI.State.Text = "BASE";

        // Сбросить pivot_offset
        CardUI.PivotOffset = Vector2.Zero;
    }

    public override void OnGuiInput(InputEvent @event)
    {
        if (@event.IsActionPressed("left_mouse"))
        {
            // Обновить pivot_offset
            CardUI.PivotOffset = CardUI.GetGlobalMousePosition() - CardUI.GlobalPosition;

            // Запросить переход состояния
            //EmitSignal(nameof(TransitionRequested), this, State.CLICKED);
        }
    }
}
