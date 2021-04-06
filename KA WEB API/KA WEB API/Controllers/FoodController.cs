﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KA_WEB_API;
using KA_WEB_API.Models;

namespace KA_WEB_API.Controllers
{
    public class FoodController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Food
        public IQueryable<Food> GetFood()
        {
            return db.Food;
        }

        // GET: api/Food/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult GetFood(int id)
        {
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            return Ok(food);
        }

        // PUT: api/Food/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFood(int id, Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != food.FoodID)
            {
                return BadRequest();
            }

            db.Entry(food).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Food
        [ResponseType(typeof(Food))]
        public IHttpActionResult PostFood(Food food)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Food.Add(food);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = food.FoodID }, food);
        }

        // DELETE: api/Food/5
        [ResponseType(typeof(Food))]
        public IHttpActionResult DeleteFood(int id)
        {
            Food food = db.Food.Find(id);
            if (food == null)
            {
                return NotFound();
            }

            db.Food.Remove(food);
            db.SaveChanges();

            return Ok(food);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FoodExists(int id)
        {
            return db.Food.Count(e => e.FoodID == id) > 0;
        }
    }
}