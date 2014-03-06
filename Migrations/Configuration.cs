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
                new User { Name = "Tim Guibord", EmailAddress = "timguibord@gmail.com", Company = "UC", Password = "password123"},
                new User { Name = "Bob Smith", EmailAddress = "bob@email.com", Company = "Big Bob's Carpet", Password = "password123"},
                new User { Name = "Dave Jones", EmailAddress = "dave@email.com", Company = "Famous Dave's BBQ", Password = "password123"},
                new User { Name = "John Doe", EmailAddress = "john@email.com", Company = "Apex SCT", Password = "password123"}
            };

            users.ForEach(s => context.Users.AddOrUpdate(p => p.EmailAddress, s));
            context.SaveChanges();

            var sessions = new List<Session>
            {
                new Session {Title = "Intro to Ruby", Description = "Basic Overview of Ruby Language", Location = "RecCenter 123", Time = DateTime.Parse("2014-03-03 5:00 PM"), Occupancy = 5},
                new Session {Title = "Intro to Rails", Description = "Basic Overview of Ruby on Rails Framework", Location = "Smith 456", Time = DateTime.Parse("2014-03-04 5:00 PM"), Occupancy = 6},
                new Session {Title = "Advance AngularJS", Description = "Learn advance AngularJS", Location = "TC 666", Time = DateTime.Parse("2014-03-06 5:00 PM"), Occupancy = 3},
                new Session {Title = "Begining C#", Description = "Learn the Basics of C#", Location = "Edwards 1111", Time = DateTime.Parse("2014-03-07 5:00 PM"), Occupancy = 4},
                new Session {Title = "Web Programming 1", Description = "Basic HTML and CSS", Location = "W. Charlton 555", Time = DateTime.Parse("2014-03-03 2:00 PM"), Occupancy = 5},
                new Session {Title = "Front End Web Dev", Description = "Learn basic JavaScript and Jquery", Location = "TC 222", Time = DateTime.Parse("2014-03-06 7:00 PM"), Occupancy = 6}
            };

            sessions.ForEach(s => context.Sessions.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var enrollments = new List<Enrollment>
            {
                new Enrollment {
                    UserID = users.Single(s => s.EmailAddress == "bob@email.com").UserID,
                    SessionID = sessions.Single(s => s.Title == "Intro to Ruby").SessionID
                },
                new Enrollment {
                    UserID = users.Single(s => s.EmailAddress == "bob@email.com").UserID,
                    SessionID = sessions.Single(s => s.Title == "Intro to Rails").SessionID
                },
                new Enrollment {
                    UserID = users.Single(s => s.EmailAddress == "bob@email.com").UserID,
                    SessionID = sessions.Single(s => s.Title == "Advance AngularJS").SessionID
                }
            };

            enrollments.ForEach(s => context.Enrollments.AddOrUpdate(p => p.EnrollmentID, s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role {
                    Name = "Admin"
                },

                new Role {
                    Name = "Attendee"
                }
            };

            roles.ForEach(s => context.Roles.AddOrUpdate(p => p.RoleID, s));
            context.SaveChanges();

            //var userRoles = new List<UserRole>
            //{
            //    new UserRole {
            //        UserID = users.Single(s => s.EmailAddress == "timguibord@gmail.com").UserID,
            //        RoleID = roles.Single(s => s.Name == "Admin").RoleID
            //    }
            //};

            //userRoles.ForEach(s => context.UserRoles.AddOrUpdate(p => p.UserRoleID, s));
            //context.SaveChanges();
        }
    }
}
