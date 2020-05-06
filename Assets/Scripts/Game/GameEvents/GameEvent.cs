using System;
using UnityEngine;
using Utils;

namespace Game.GameEvents
{
    public class GameEvent
    {
        private event Action _levelAction;
        public GameEventType LevelEventType;
        
        public GameEvent(GameEventType levelEventType)
        {
            LevelEventType = levelEventType;
        }

        public void Invoke()
        {
            _levelAction.SafeInvoke();
        }

        public void Subscribe(Action action)
        {
            _levelAction += action;
        }
    }

    public enum GameEventType
    {
        CHECKPOINT,
        FINISHED,
        FAIL
    }
}
