using CounterStrikeDashboard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CounterStrikeDashboard.Core.Services
{
    public class StateKeeper
    {
        public StateKeeper()
        {
            _sessions = new List<Session>();
        }

        List<Session> _sessions;

        public Session CurrentSession
        {
            get { return _sessions.First(); }
        }

        public Map CurrentMap
        {
            get { return CurrentSession.Maps.First(x => x.Active); }
        }

        public void StartNewSession()
        {
            _sessions.Add(new Session());
        }

        public void StartNewMap(string mapName)
        {
            CurrentSession.Maps.Insert(0, new Map()
            {
                Active = true,
                MapName = mapName,
                Start = DateTime.Now
            });
        }

        public void AddPlayer(string name, string uniqueIdentifier)
        {
            CurrentMap.Players.Add(new PlayerTuple()
            {
                Name = name,
                UniqueIdentifier = uniqueIdentifier,
                Connected = true
            });
        }

        public void RemovePlayer(string uniqueIdentifier)
        {
            CurrentMap.Players.Single(x => x.UniqueIdentifier == uniqueIdentifier).Connected = false;
        }

        public void ChangePlayerName(string oldName, string newName, string uniqueIdentifier)
        {
            CurrentMap.Players.Single(x => x.UniqueIdentifier == uniqueIdentifier).Name = newName;
        }

        public void ApplyKill(string killerUId, string deadPersonUId)
        {
            CurrentMap.Players.Single(x => x.UniqueIdentifier == killerUId).Kills++;
            CurrentMap.Players.Single(x => x.UniqueIdentifier == deadPersonUId).Deaths++;
        }

        public void EndMap(string winnerTeam)
        {
            CurrentMap.Teams.Single(x => x.Team == winnerTeam).Score++;
            CurrentMap.Active = false;
        }
    }
}
