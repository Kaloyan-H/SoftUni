using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Teamwork_Projects
{
    class Team
    {
        public Team() { }
        public Team(string name, string creator)
        {
            this.Name = name;
            this.Creator = creator;
            this.Members = new List<string>();
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; }

        public void AddMember(string newMember)
        {
            this.Members.Add(newMember);
        }

        public override string ToString()
        {
            string output = $"{this.Name}\n" +
                $"- {this.Creator}";

            foreach (var member in this.Members)
            {
                output += $"\n-- {member}";
            }

            return output;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTeams = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);

                bool flag = false;

                foreach (var team in teams)
                {
                    if (team.Name == tokens[1])
                    {
                        Console.WriteLine($"Team {team.Name} was already created!");

                        flag = true;

                        break;
                    }
                    else if (team.Creator == tokens[0])
                    {
                        Console.WriteLine($"{team.Creator} cannot create another team!");

                        flag = true;

                        break;
                    }
                }

                if (flag == false)
                {
                    teams.Add(new Team(tokens[1], tokens[0]));

                    Console.WriteLine($"Team {tokens[1]} has been created by {tokens[0]}!");
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end of assignment")
                {
                    break;
                }

                string[] tokens = input
                    .Split("->", StringSplitOptions.RemoveEmptyEntries);

                bool teamExists = false;
                bool memberCantJoin = false;


                foreach (var team in teams)
                {
                    bool flag = false;

                    if (team.Creator == tokens[0])
                    {
                        Console.WriteLine($"Member {tokens[0]} cannot join team {team.Name}!");

                        flag = true;
                        memberCantJoin = true;
                    }
                    else
                    {
                        foreach (var member in team.Members)
                        {
                            if (member == tokens[0])
                            {
                                Console.WriteLine($"Member {tokens[0]} cannot join team {team.Name}!");

                                flag = true;
                                memberCantJoin = true;

                                break;
                            }
                        }
                    }

                    if (flag)
                    {
                        break;
                    }

                    if (team.Name == tokens[1])
                    {
                        teamExists = true;
                    }
                }

                if (memberCantJoin == true)
                {
                    continue;
                }
                if (memberCantJoin == false && teamExists == false)
                {
                    Console.WriteLine($"Team {tokens[1]} does not exist!");

                    continue;
                }

                foreach (var team in teams)
                {
                    if (team.Name == tokens[1])
                    {
                        team.AddMember(tokens[0]);
                        break;
                    }
                }
            }

            List<Team> disbandingTeams = new List<Team>();

            foreach (var team in teams)
            {
                if (team.Members.Count == 0)
                {
                    disbandingTeams.Add(team);
                }
            }

            foreach (var team in disbandingTeams)
            {
                if (teams.Contains(team))
                {
                    teams.Remove(team);
                }
            }

            teams = teams
                .OrderByDescending(team => team.Members.Count)
                .ToList();

            foreach (var team in teams)
            {
                Console.WriteLine(team.ToString());
            }

            disbandingTeams = disbandingTeams
                .OrderBy(team => team.Name)
                .ToList();

            Console.WriteLine("Teams to disband:");

            foreach (var team in disbandingTeams)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}
