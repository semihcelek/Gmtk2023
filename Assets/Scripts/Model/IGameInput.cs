﻿using System;

namespace SemihCelek.Gmtk2023.Model
{
    public interface IGameInput
    {
        float HorizontalInput { get; }
        float VerticalInput { get; }

        event Action<bool> OnPrimaryExecute;
        event Action<bool> OnSecondaryExecute;
    }
}