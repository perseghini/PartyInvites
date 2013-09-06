using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PartyInvites.Models;
using PartyInvites.Models.Repository;
using PartyInvites.Presenters;
using PartyInvites.Presenters.Results;

namespace PartyInvites.Tests
{
    [TestClass]
    public class RsvpPresenterTests
    {
        private class MockRepository : IRepository
        {
            private readonly List<GuestResponse> _mockData = new List<GuestResponse>
                                                                 {
                                                                     new GuestResponse
                                                                         {Name = "Person1", WillAttend = true},
                                                                     new GuestResponse
                                                                         {Name = "Person2", WillAttend = false},
                                                                 };

            public IEnumerable<GuestResponse> GetAllResponses()
            {
                return _mockData;
            }

            public void AddResponse(GuestResponse response)
            {
                _mockData.Add(response);
            }
        }

        [TestMethod]
        public void Adds_Object_To_Repository()
        {
            // Arrange
            IRepository repo = new MockRepository();
            IPresenter<GuestResponse> target = new RsvpPresenter { Repository = repo };
            GuestResponse dataObject =
                new GuestResponse { Name = "TEST", WillAttend = true };
            // Act
            IResult result = target.GetResult(dataObject);
            // Assert
            Assert.AreEqual(repo.GetAllResponses().Count(), 3);
            Assert.AreEqual(repo.GetAllResponses().Last().Name, "TEST");
            Assert.AreEqual(repo.GetAllResponses().Last().WillAttend, true);
        }

        [TestMethod]
        public void Handles_WillAttend_Values()
        {
            // Arrange
            IRepository repo = new MockRepository();
            IPresenter<GuestResponse> target = new RsvpPresenter { Repository = repo };
            bool?[] values = { true, false };
            // Act & Assert
            foreach (bool? testValue in values)
            {
                GuestResponse dataObject =
                    new GuestResponse { Name = "TEST", WillAttend = testValue };
                IResult result = target.GetResult(dataObject);
                Assert.IsInstanceOfType(result, typeof(RedirectResult));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Handles_WillAttend_Null_Values()
        {
            // Arrange
            IRepository repo = new MockRepository();
            IPresenter<GuestResponse> target = new RsvpPresenter { Repository = repo };
            // Act
            GuestResponse dataObject
                = new GuestResponse { Name = "TEST", WillAttend = null };
            IResult result = target.GetResult(dataObject);
        }
    }
}