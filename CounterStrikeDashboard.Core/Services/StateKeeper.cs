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
            _sessions.Add(new Session());
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

        public void RemovePlayer(string name, string uniqueIdentifier)
        {
            if (uniqueIdentifier == "BOT")
                CurrentMap.Players.Single(x => x.Name == uniqueIdentifier).Connected = false;
            else
                CurrentMap.Players.Single(x => x.UniqueIdentifier == uniqueIdentifier).Connected = false;
        }

        public void ChangePlayerName(string oldName, string newName, string uniqueIdentifier)
        {
            if (uniqueIdentifier == "BOT")
                CurrentMap.Players.Single(x => x.Name == oldName).Name = newName;
            else
                CurrentMap.Players.Single(x => x.UniqueIdentifier == uniqueIdentifier).Name = newName;
        }

        public void ApplyKill(string killerName, string killerUId, string deadPersonUId, string deadPersonName)
        {
            if (killerUId == "BOT")
                CurrentMap.Players.Single(x => x.Name == killerName).Kills++;
            else
                CurrentMap.Players.Single(x => x.UniqueIdentifier == killerUId).Kills++;

            if (deadPersonUId == "BOT")
                CurrentMap.Players.Single(x => x.Name == deadPersonName).Deaths++;
            else
                CurrentMap.Players.Single(x => x.UniqueIdentifier == deadPersonUId).Deaths++;            
        }

        public void EndRound(string winnerTeam)
        {
            CurrentMap.Teams.Single(x => x.Team == winnerTeam).Score++;
        }

        public void EndMap()
        {
            CurrentMap.Active = false;
        }

        public void JoinTeam(string playerString, string teamString)
        {
            CurrentMap.Players.Single(x => x.UniqueIdentifier == playerString).Team = teamString;
        }

        public void PrintScores()
        {
            Console.Clear();

            Console.WriteLine("SCORES:");
            Console.WriteLine();
            Console.WriteLine();

            foreach (var session in _sessions)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("-------- SESSION --------");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Session started: {0}", session.Started);

                foreach (var map in session.Maps)
                {
                    Console.WriteLine("Map: {0}", map.MapName);
                    Console.WriteLine("Started: {0}", map.Start);
                    Console.WriteLine();
                    Console.WriteLine("CT: {0}, T: {1}", map.Teams.Single(x => x.Team == "CT").Score, map.Teams.Single(x => x.Team == "T").Score);
                    Console.WriteLine("----------");
                    Console.WriteLine("-- CT's --");
                    foreach (var player in map.Players.Where(x => x.Team == "CT"))
                    {
                        Console.WriteLine("{0} - {1} kills - {2} deaths", player.Name, player.Kills, player.Deaths);
                    }

                    Console.WriteLine("--- T's --");
                    foreach (var player in map.Players.Where(x => x.Team == "T"))
                    {
                        Console.WriteLine("{0} - {1} kills - {2} deaths", player.Name, player.Kills, player.Deaths);
                    }
                }
            }
        }
    }
}
