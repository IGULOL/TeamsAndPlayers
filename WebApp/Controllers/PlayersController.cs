using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp.DataAccess;
using WebApp.DataContext;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index()
        {
            return View(PlayerAccess.getAllPlayers());
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = PlayerAccess.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = PlayerAccess.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            ViewBag.TeamId = new SelectList(TeamAccess.getAllTeams(), "Id", "Name");
            return View();
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Player player = PlayerAccess.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }

            ViewBag.TeamId = new SelectList(TeamAccess.getAllTeams(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname,Name,Age,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                PlayerAccess.Insert(player);
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(TeamAccess.getAllTeams(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname,Name,Age,TeamId")] Player player)
        {
            if (ModelState.IsValid)
            {
                PlayerAccess.Update(player);
                return RedirectToAction("Index");
            }

            ViewBag.TeamId = new SelectList(TeamAccess.getAllTeams(), "Id", "Name", player.TeamId);
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerAccess.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
