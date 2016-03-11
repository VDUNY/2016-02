using System;
using System.Windows.Input;
using Model;

namespace ViewModel
{
    public class ViewModelChild : ViewModelBase
    {
        Hardware m_model = new Hardware();

        public ViewModelChild()
        {
            // Action delegate encapsulates a method that has no parameters and returns void.
            // Predicate delegate represents a method that defines a set of criteria and determines whether
            // the specified object meets those criteria.
            // Convenience in that we do not have to declare our own delegates in code.
            m_cmdGetCurrentTime = new RelayCommand(
                GetCurrentTime, param => CanGetCurrentTimeCommand);
        }

        private string m_currentTime = "Not initialized";
        RelayCommand m_cmdGetCurrentTime = null;
        private bool m_CanGetCurrentTimeCommand = true;

        public string CurrentTime
        {
            get
            {
                return m_currentTime;
            }
            set
            {
                m_currentTime = value;
                RaisePropertyChanged("CurrentTime");
            }
        }

        /*
         Choosing btwn Properties and Methods
         In general, methods represent actions and properties represent data.
         Properties are meant to be used like fields and should not be computationally complex 
         or have side effects.
         * 
        */
        public ICommand GetCurrentTimeCommand
        {
            get
            {
                return m_cmdGetCurrentTime;
            }
            set
            {
                m_cmdGetCurrentTime = (RelayCommand)value;

            }
        }

        // matches bool Predicate()
        public bool CanGetCurrentTimeCommand
        {
            get
            {
                return m_CanGetCurrentTimeCommand;
            }
            set
            {
                m_CanGetCurrentTimeCommand = value;
            }
        }

        // matches void Action(object)
        private void GetCurrentTime(object state)
        {
            CurrentTime = state.ToString() + " " + m_model.CurrentTime;
        }
    }
}
