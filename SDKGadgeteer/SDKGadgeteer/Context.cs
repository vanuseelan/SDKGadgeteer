using System;
using System.Collections;
using Microsoft.SPOT;

namespace SDKGadgeteer
{
    public class Context
    {
        private State _startState;
        private ErrorState _errorState;
        private State _currentState;
        private Queue _precedentStates;
        private bool _isBack = false;

        public Context(State startState, ErrorState errorState)
        {
            _startState = startState;
            _errorState = errorState;
            _precedentStates = new Queue();
        }

        public State CurrentState
        {
            get { return _currentState; }
            set {
               /* try
                {*/
                if (_currentState != null)
                {
                    _currentState.Exit();
                    if (!_isBack)
                    {
                        _precedentStates.Enqueue(_currentState);
                        _isBack = false;
                    }
                }

                    if (value != null)
                    {
                        _currentState = value;
                        _currentState.Entry();
                    }
               /* }
                catch (Exception ex)
                {
                    _errorState.Error = ex;
                    CurrentState = _errorState;
                }*/
            }
        }

        public void Start()
        {
            CurrentState = _startState;
        }
        public void GoStart()
        {
            Start();
        }
        public void GoBack()
        {
            if (_precedentStates.Count > 0)
            {
                CurrentState = (State)_precedentStates.Dequeue();
                _isBack = true;
            }
        }

    }
}
