using bArtTest.Context;
using bArtTest.Controllers;
using bArtTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void api_get_account_test()
        {
            //Arrage
            var options = new DbContextOptionsBuilder<MVCContext>()
                .UseInMemoryDatabase(databaseName: "bArtTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            MVCContext context = new MVCContext(options);
            this.Seed(context);

            ApiController contoller = new ApiController(context);

            //Act
            JsonResult result = null;
            try
            {
                result = (JsonResult)contoller.accounts("a");
            }
            catch (Exception ex)
            {
                Assert.True(false);
                return;
            }


            //Assert
            Assert.True(result.Value != null && ((Account)result.Value).name == "a");
            context.Database.EnsureDeleted();

        }

        [Fact]
        public void api_contacts_account_test()
        {
            //Arrage
            var options = new DbContextOptionsBuilder<MVCContext>()
                .UseInMemoryDatabase(databaseName: "bArtTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            MVCContext context = new MVCContext(options);
            this.Seed(context);

            ApiController contoller = new ApiController(context);

            //Act
            JsonResult result = null;
            try
            {
                result = (JsonResult)contoller.contacts("a");
            } catch (Exception ex)
            {
                Assert.True(false);
                return;
            }

            //Assert
            Assert.True(result.Value != null && ((List<Contact>)result.Value)[0].email == "aaa@mail.com");
            context.Database.EnsureDeleted();

        }

        [Fact]
        public void api_get_incident_test()
        {
            //Arrage
            var options = new DbContextOptionsBuilder<MVCContext>()
                .UseInMemoryDatabase(databaseName: "bArtTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            MVCContext context = new MVCContext(options);
            this.Seed(context);

            ApiController contoller = new ApiController(context);

            //Act
            JsonResult result = null;
            try
            {
                result = (JsonResult)contoller.incidents("a");
            }
            catch (Exception ex)
            {
                Assert.True(false);
                return;
            }


            //Assert
            Assert.True(result.Value != null && ((Incident)result.Value).name == "test");
            context.Database.EnsureDeleted();

        }

        [Fact]
        public void api_add_incident_test()
        {
            //Arrage
            var options = new DbContextOptionsBuilder<MVCContext>()
                .UseInMemoryDatabase(databaseName: "bArtTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            MVCContext context = new MVCContext(options);

            ApiController contoller = new ApiController(context);

            CUModel data = new CUModel {
                account = "b", email = "ccc@mail.com",
                first_name = "John", last_name = "last_name", description = "TEST" };

            //Act
            StatusCodeResult result = (StatusCodeResult)contoller.createincident(data);

            //Assert
            Assert.True(result.StatusCode == 200);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void api_edit_incident_test()
        {
            //Arrage
            var options = new DbContextOptionsBuilder<MVCContext>()
                .UseInMemoryDatabase(databaseName: "bArtTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            MVCContext context = new MVCContext(options);
            this.Seed(context);

            ApiController contoller = new ApiController(context);

            CUModel data = new CUModel
            {
                account = "a",
                description = "EDIT"
            };

            //Act
            StatusCodeResult result = (StatusCodeResult)contoller.editincident(data);

            //Assert
            Assert.True(result.StatusCode == 200);
            context.Database.EnsureDeleted();

        }

        [Fact]
        public void api_add_contact_test()
        {
            //Arrage
            var options = new DbContextOptionsBuilder<MVCContext>()
                .UseInMemoryDatabase(databaseName: "bArtTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            MVCContext context = new MVCContext(options);
            this.Seed(context);

            ApiController contoller = new ApiController(context);

            CUModel data = new CUModel
            {
                account = "a",
                email = "ccc@mail.com",
                first_name = "John",
                last_name = "Adamson",
            };

            //Act
            StatusCodeResult result = (StatusCodeResult)contoller.addcontact(data);

            //Assert
            Assert.True(result.StatusCode == 200);
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void api_edit_contact_test()
        {
            //Arrage
            var options = new DbContextOptionsBuilder<MVCContext>()
                .UseInMemoryDatabase(databaseName: "bArtTest")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;

            MVCContext context = new MVCContext(options);
            this.Seed(context);

            ApiController contoller = new ApiController(context);

            CUModel data = new CUModel
            {
                email = "aaa@mail.com",
                first_name = "John",
                last_name = "Adamson",
            };

            //Act
            StatusCodeResult result = (StatusCodeResult)contoller.editcontact(data);

            //Assert
            Assert.True(result.StatusCode == 200);
            context.Database.EnsureDeleted();

        }

        private void Seed(MVCContext context)
        {
            Incident incident = new Incident { name = "test", description = "TEST INCIDENT" };
            Account account = new Account { name = "a", id = 1, incident= incident, Incidentname = "test" };
            Contact contact = new Contact { account = account, Accountid = 1, 
                firts_name = "first_name", last_name="last_name", email="aaa@mail.com", id = 1 };

            context.Incidents.Add(incident);
            context.Accounts.Add(account);
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
    }
}