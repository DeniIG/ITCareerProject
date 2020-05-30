using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Diagnostics;
using Moq;
using MovieApp.Data;
using MovieApp.Data.Entities;
using MovieApp.Services;
using MovieApp.Web.Controllers;
using MovieApp.Web.Models.Actors;
using NUnit.Framework;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MovieApp.Tests
{
    [TestFixture]
    public class ActorControllerTests
    {
        [Test]
        public void CreateNewActor()
        {
            //Arange
            var mockActorSevice = new Mock<IActorService>();
            var mockContext = new Mock<MovieDbContext>();
            var mockSighInManager = new Mock<SignInManager<ApplicationUser>>();
            var createActorModel = new CreateActorModel();
            createActorModel.Name = "Ana";
            createActorModel.Born = new DateTime(2000, 5, 13);

          // ActorController actorController = new ActorController();

            //Act
          //  var actorCreate = (object)(actorController.Create(createActorModel));

            //Assert 
           // Assert.IsNotNull(actorCreate);
        }
    }
}
