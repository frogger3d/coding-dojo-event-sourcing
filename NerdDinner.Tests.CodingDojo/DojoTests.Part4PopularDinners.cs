﻿using System.Collections;
using NerdDinner.Events;
using NerdDinner.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NerdDinner.Controllers;

namespace NerdDinner.Tests.CodingDojo {
    partial class DojoTests {
        [Test]
        public void GetPopularDinners_Is_Populated_From_PopularDinners_ReadModel() {
            PopulatePopularDinnerReadModelForDinner(dinnerId:1, rsvpCount:10);
            PopulatePopularDinnerReadModelForDinner(dinnerId:3, rsvpCount:5);
            PopulatePopularDinnerReadModelForDinner(dinnerId:4, rsvpCount:15);

            var dinners = GetMostPopularDinners();

            var mostPopular = dinners.First();

            Assert.AreEqual(4,mostPopular.DinnerID,"Not the expected dinner");
            Assert.AreEqual(15, mostPopular.RSVPCount, "RSVP count is wrong");

            var secondPopular = dinners.Skip(1).First();

            Assert.AreEqual(1,secondPopular.DinnerID,"Not the expected dinner");
            Assert.AreEqual(10, secondPopular.RSVPCount, "RSVP count is wrong");
        }

        private ICollection<JsonDinner> GetMostPopularDinners() {
            var result = CreateSearchControllerAs("freek").GetMostPopularDinners(10);

            var model = GetDataFromJsonResult<ICollection<JsonDinner>>(result);
            return model;
        }

        private void PopulatePopularDinnerReadModelForDinner(int dinnerId, int rsvpCount)
        {
            var ctx = new NerdDinners();
            var pop = PopularDinnerFromDinner(ctx.Dinners.Find(dinnerId));

            pop.RSVPCount = rsvpCount;
            ctx.PopularDinners.Add(pop);

            ctx.SaveChanges();
        }

        private PopularDinner PopularDinnerFromDinner(Dinner dinner)
        {
            var result = new PopularDinner();
            foreach(var prop in typeof(Dinner).GetProperties()) {
                var propOnPopularDinner = typeof(PopularDinner).GetProperties().FirstOrDefault(p => p.Name == prop.Name);
                if(propOnPopularDinner==null) {
                    continue; 
                }
                propOnPopularDinner.SetValue(result,prop.GetValue(dinner,null),null);
            }

            return result;
        }
    }
}
