using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.DataContext;
using WebApp.Models;

namespace WebApp.DataAccess
{
    public class PlayerAccess
    {
        private static TeamPlayerContext db = new TeamPlayerContext();

        public static List<Player> getAllPlayers()
        {
            return db.Players.ToList();
        }

        public static void Insert(Player pl)
        {
            db.Players.Add(pl);
            db.SaveChanges();
        }

        public static void Remove(int id)
        {
            var player = db.Players.Where(p => p.Id == id).FirstOrDefault();
            if (player == null) return;

            db.Players.Remove(player);
            db.SaveChanges();
        }

        public static void Update(Player pl)
        {
            var player = db.Players.Find(pl.Id);
            if (player == null) return;

            player.Surname = pl.Surname;
            player.Name = pl.Name;
            player.Age = pl.Age;
            player.TeamId = pl.TeamId;

            //db.Entry(pl).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static List<Player> getPlayersFromTeam(int? idTeam)
        {
            return db.Players.Where(p => p.Team.Id == idTeam).ToList();
        }

        public static Player Find(int? id)
        {
            return db.Players.Find(id);
        }
    }
}