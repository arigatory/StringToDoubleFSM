using System;
using System.Collections.Generic;

namespace StringToDoubleLol
{
    public class Process
    {
        public Double Value { get; set; }
        class StateTransition
        {
            readonly ProcessState CurrentState;
            readonly Symbol Symbol;
            

            public StateTransition(ProcessState currentState, Symbol symbol)
            {
                CurrentState = currentState;
                Symbol = symbol;
            }

            public override int GetHashCode()
            {
                return 17 + 31 * CurrentState.GetHashCode() + 31 * Symbol.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                StateTransition other = obj as StateTransition;
                return other != null && this.CurrentState == other.CurrentState && this.Symbol == other.Symbol;
            }

        }

        Dictionary<StateTransition, ProcessState> transitions;
        public ProcessState CurrentState { get; set; }

        public Process()
        {
            CurrentState = ProcessState.Start;
            transitions = new Dictionary<StateTransition, ProcessState>
            {
                { new StateTransition(ProcessState.Start, Symbol.Sign), ProcessState.SignCheck },
                { new StateTransition(ProcessState.Start, Symbol.Digit), ProcessState.FirstPart },

                { new StateTransition(ProcessState.SignCheck, Symbol.Digit), ProcessState.FirstPart },

                { new StateTransition(ProcessState.FirstPart, Symbol.Digit), ProcessState.FirstPart },
                { new StateTransition(ProcessState.FirstPart, Symbol.Point), ProcessState.Point },
                { new StateTransition(ProcessState.FirstPart, Symbol.EndOfWord), ProcessState.Finish },

                { new StateTransition(ProcessState.Point, Symbol.Digit), ProcessState.LastPart },

                { new StateTransition(ProcessState.LastPart, Symbol.Digit), ProcessState.LastPart },
                { new StateTransition(ProcessState.LastPart, Symbol.EndOfWord), ProcessState.Finish },
            };
        }

        public ProcessState GetNext(Symbol symbol)
        {
            StateTransition transition = new StateTransition(CurrentState, symbol);
            ProcessState nextState;
            if (!transitions.TryGetValue(transition, out nextState))
                throw new Exception("Неверный символ в строке: " + CurrentState + " -> " + symbol);
            return nextState;
        }

        public ProcessState MoveNext(Symbol symbol)
        {
            CurrentState = GetNext(symbol);
            return CurrentState;
        }
    }
}
