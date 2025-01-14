using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Controllers;
using MyProject.Models;
using NUnit.Framework;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MyProject.Tests.Controllers

{

    [TestFixture]

    public class ProjectControllerTests

    {

        private ProjectController _projectController;

        [SetUp]

        public void Setup()

        {

            _projectController = new ProjectController();

        }

        [Test]

        public void Index_ReturnsViewResult()

        {

            // Act

            var result = _projectController.Index() as ViewResult;

            // Assert

            Assert.IsNotNull(result);

            Assert.AreEqual("", result.ViewName);

        }

        [Test]

        public void EmployeeLogin_InvalidModel_ReturnsViewResultWithModelError()

        {

            // Arrange

            var invalidModel = new EmployeeDetails { EmpID = 0, Password = "invalid" };

            _projectController.ModelState.AddModelError("key", "error message");

            // Act

            var result = _projectController.EmployeeLogin(invalidModel) as ViewResult;

            // Assert

            Assert.IsNotNull(result);

            Assert.AreEqual("", result.ViewName);

            Assert.IsFalse(_projectController.ModelState.IsValid);

        }

        [Test]

        public void EmployeeLogins_InvalidModel_ReturnsViewResultWithModelError()

        {

            // Arrange

            var invalidModel = new EmployeeDetails { EmpID = 0, Password = "" };

            _projectController.ModelState.AddModelError("key", "error message");

            // Act

            var result = _projectController.EmployeeLogin(invalidModel) as ViewResult;

            // Assert

            Assert.IsNotNull(result);

            Assert.AreEqual("", result.ViewName);

            Assert.IsFalse(_projectController.ModelState.IsValid);

        }

        [Test]

        public void ManagerLogin_InvalidModel_ReturnsViewResultWithModelError()

        {

            // Arrange

            var invalidModel = new ManagerLogin { ManagerID = 0, Password = "invalid" };

            _projectController.ModelState.AddModelError("key", "error message");

            // Act

            var result = _projectController.ManagerLogin(invalidModel) as ViewResult;

            // Assert

            Assert.IsNotNull(result);

            Assert.AreEqual("", result.ViewName);

            Assert.IsFalse(_projectController.ModelState.IsValid);

        }

        [Test]

        public void ManagerLogins_InvalidModel_ReturnsViewResultWithModelError()

        {

            // Arrange

            var invalidModel = new ManagerLogin { ManagerID = 0, Password = "" };

            _projectController.ModelState.AddModelError("key", "error message");

            // Act

            var result = _projectController.ManagerLogin(invalidModel) as ViewResult;

            // Assert

            Assert.IsNotNull(result);

            Assert.AreEqual("", result.ViewName);

            Assert.IsFalse(_projectController.ModelState.IsValid);

        }

        [TearDown]

        public void TearDown()

        {

            // To Clean up any resources

        }

    }

}
