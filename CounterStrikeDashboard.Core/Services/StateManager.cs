using CounterStrikeDashboard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services
{
    public class StateManager
    {
        public StateManager()
        {
            _sessions = new List<Session>();
        }

        List<Session> _sessions;

        public Session CurrentSession
        {
            get { return _sessions.First(); }
        }

        public Round CurrentRound
        {
            get { return CurrentSession.Rounds.First(); }
        }

        public void StartNewSession()
        {
            _sessions.Add(new Session());
        }

        public void StartNewRound()
        {
            CurrentSession.Rounds.Add(new Round());
        }

        public void ApplyKill(string killer)
        {
            var score = CurrentRound.Scores.First(x => x.Player.Name.Equals(killer));
            score.Kills++;
        }
    }
}
