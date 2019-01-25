using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.DataContext
{
    public class TeamPlayerInitializer : DropCreateDatabaseIfModelChanges<TeamPlayerContext>
    {
        protected override void Seed(TeamPlayerContext context)
        {
            var teams = new List<Team>
            {
                new Team {Name="Котятки", Country="Россия"},
                new Team {Name="Собачки", Country="США"},
                new Team {Name="Львята", Country="Япония"},
            };

            teams.ForEach(t => context.Teams.Add(t));
            context.SaveChanges();

            var players = new List<Player>
            {
                new Player { Surname="Васильев", Name="Станислав", Age=27, TeamId=1},
                new Player { Surname="Ираков", Name="Николай", Age=29, TeamId=1},
                new Player { Surname="Гущин", Name="Олег", Age=32, TeamId=1},
                new Player { Surname="Стасьев", Name="Евгений", Age=30, TeamId=1},

                new Player { Surname="Стукачев", Name="Алексей", Age=34, TeamId=2},
                new Player { Surname="Пилотов", Name="Юрий", Age=28, TeamId=2},

                new Player { Surname="Удилин", Name="Александр", Age=33, TeamId=3},
                new Player { Surname="Животов", Name="Дмитрий", Age=38, TeamId=3},
                new Player { Surname="Лимонов", Name="Павел", Age=29, TeamId=3},
            };

            players.ForEach(p => context.Players.Add(p));
            context.SaveChanges();
        }
    }
}