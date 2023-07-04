using System;

namespace SemihCelek.Gmtk2023.Model
{
    [Flags]
    public enum GameState
    {
        Idle = 0,
        Playing = 1,
        Locked = 2,
    }
}