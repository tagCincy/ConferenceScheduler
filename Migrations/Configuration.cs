namespace ConferenceScheduler.Migrations
{
    using ConferenceScheduler.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ConferenceScheduler.Models.DAL.ConferenceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ConferenceScheduler.Models.DAL.ConferenceContext context)
        {
            var users = new List<User>
            {
                new User { Name = "Bob Smith", EmailAddress = "bob@email.com", Company = "Big Bob's Carpet", Password = "password123"},
                new User { Name = "Dave Jones", EmailAddress = "dave@email.com", Company = "Famous Dave's BBQ", Password = "password123"},
                new User { Name = "John Doe", EmailAddress = "john@email.com", Company = "Apex SCT", Password = "password123"}
            };

            users.ForEach(s => context.Users.AddOrUpdate(p => p.EmailAddress, s));
            context.SaveChanges();

            var sessions = new List<Session>
            {
                new Session {Title = "Intro to Ruby", Description = "Basic Overview of Ruby Language", Location = "RecCenter 123", Time = DateTime.Parse("2014-03-03 5:00 PM"), Occupancy = 50},
                new Session {Title = "Intro to Rails", Description = "Basic Overview of Ruby on Rails Framework", Location = "Smith 456", Time = DateTime.Parse("2014-03-04 5:00 PM"), Occupancy = 50},
                new Session {Title = "Advance AngularJS", Description = "Learn advance AngularJS", Location = "TC 666", Time = DateTime.Parse("2014-03-06 5:00 PM"), Occupancy = 50}
            };

            sessions.ForEach(s => context.Sessions.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();
        }
    }
}
