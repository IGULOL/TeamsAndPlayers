using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.DataContext;
using WebApp.Models;

namespace WebApp.DataAccess
{
    public class TeamAccess
    {
        private static TeamPlayerContext db = new TeamPlayerContext();

        public static List<Team> getAllTeams()
        {
            return db.Teams.ToList();
        }

        public static void Insert(Team tm)
        {
            db.Teams.Add(tm);
            db.SaveChanges();
        }

        public static void Remove(int id)
        {
            var team = db.Teams.Where(tm => tm.Id == id).FirstOrDefault();
            if (team == null) return;

            db.Teams.Remove(team);
            db.SaveChanges();
        }

        public static void Update(Team tm)
        {
            var team = db.Teams.Find(tm.Id);
            if (team == null) return;

            team.Name = tm.Name;
            team.Country = tm.Country;

            //db.Entry(tm).State = EntityState.Modified;
            db.SaveChanges();
        }

        public static Team Find(int? id)
        {
            return db.Teams.Find(id);
        }
    }
}