using System;
using SemihCelek.Gmtk2023.Model;

namespace SemihCelek.Gmtk2023.AIModule.Controller
{
    public class AIInputController : IGameInput
    {
        public float HorizontalInput { get; }
        public float VerticalInput { get; }
        public event Action<bool> OnPrimaryExecute;
        public event Action<bool> OnSecondaryExecute;
    }
}