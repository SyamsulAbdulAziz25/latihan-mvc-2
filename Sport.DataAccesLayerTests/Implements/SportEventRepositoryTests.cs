using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SportEvent.Core;
using SportEvent.DataAccesLayer.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportEvent.DataAccesLayer.Implements.Tests
{
    [TestClass()]
    public class SportEventRepositoryTests
    {
        //[TestMethod()]
        //public void MakeIdEventTest()
        //{
        //    //Arrange
        //    var sportEventRepository = NSubstitute.Substitute.For<ISportEventRepository>();
        //    var sportEvent = new SportEventRepository();
        //    //Act
        //    String dataEvent = sportEvent.MakeIdEvent();
        //    Event ev = new Event();
        //    //Assert
        //    Assert.Fail();
        //}

        [TestMethod()]
        public void InsertTest()
        {
            //Arrange
            var repository = NSubstitute.Substitute.For<IRepository<Event>>();
            var sportEvent = NSubstitute.Substitute.ForPartsOf<SportEventRepository>(repository);
            //Act
            Event ev = new Event();
            sportEvent.Insert(ev);

            //Assert
            sportEvent.Received(1).MakeIdEvent();
            repository.Received(1).Add(Arg.Is<Event>(n => n.State_Delete != "IsDeleted"));
        }

        [TestMethod()]
        public void FindEventSuccessTest()
        {
            //Arrange
            var repository = NSubstitute.Substitute.For<IRepository<Event>>();
            repository.GetAll().Returns(new List<Event>()
            {
                new Event()
                {
                    Id="EVT-001"
                }
            }.AsQueryable());
            var sportEvent = NSubstitute.Substitute.ForPartsOf<SportEventRepository>(repository);
            //Act
            sportEvent.FindEvent("EVT-001");

            //Assert
            repository.Received(1).GetAll();
        }

        [TestMethod()]
        public void MakeIdEventTest()
        {
            //Arrange
            var repository = NSubstitute.Substitute.For<IRepository<Event>>();
            var sportEvent = NSubstitute.Substitute.ForPartsOf<SportEventRepository>(repository);
            //Act
            var @event= sportEvent.MakeIdEvent();
            //Assert
            repository.Received(1).GetAll();
            Assert.IsTrue(@event!=null);
        }
    }
}