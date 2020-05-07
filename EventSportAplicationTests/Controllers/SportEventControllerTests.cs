using Microsoft.VisualStudio.TestTools.UnitTesting;
using EventSportAplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportEvent.Controllers;
using NSubstitute;
using SportEvent.Core;
using SportEvent.Core.Output;

namespace EventSportAplication.Controllers.Tests
{
    [TestClass()]
    public class SportEventControllerTests
    {
        [TestMethod()]
        public void ViewAllDataTest()
        {
            //Arrange
            var sportEventBussinesLayer = NSubstitute.Substitute.For<ISportEventBussinesLayer>();
            var controller = new SportEventController(sportEventBussinesLayer);
            //Actual
            controller.ViewAllData();
            //Assert
            sportEventBussinesLayer.Received(1).GetActiveAllEvents();
        }

        [TestMethod()]
        public void CreateTestWhenEventDateLowerThanToday()
        {
            //Arrange
            var sportEventBussinesLayer = NSubstitute.Substitute.For<ISportEventBussinesLayer>();
            var controller = new SportEventController(sportEventBussinesLayer);
            //var dt = new SportEventOutput();
            //sportEventBussinesLayer.FindUser(Arg.Any<String>()).Returns(dt);

            //Actual
            var @event = new Event();
            @event.Date = DateTime.Now.AddDays(1);
            controller.Create(@event);

            // Assert
            sportEventBussinesLayer.Received(1).InsertUser(Arg.Any<Event>());

        }

        [TestMethod()]
        public void EditTest()
        {
            //Arrange
            var sportEventBussinesLayer = Substitute.For<ISportEventBussinesLayer>();
            var controller = new SportEventController(sportEventBussinesLayer);
            //Act
            var @event = new SportEventOutput();
            @event.Date = DateTime.Today.AddDays(1);
            controller.Edit("EVT-0001", @event);
            //Assert
            sportEventBussinesLayer.Received(1).UpdateUser(Arg.Any<String>(), Arg.Any<SportEventOutput>());
            //.Fail();
        }
    }
}