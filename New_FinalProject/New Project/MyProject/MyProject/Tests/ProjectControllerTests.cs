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
            Assert.IsNotNull(result, "Index action should return a ViewResult.");
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName), $"Expected ViewName to be null or empty but was '{result?.ViewName}'");
        }

        [Test]
        public void EmployeeLogin_InvalidModel_ReturnsViewWithModelError()
        {
            // Arrange
            var invalidModel = new EmployeeDetails { EmpID = 0, Password = "invalid" };
            _projectController.ModelState.AddModelError("key", "Invalid model state");

            // Act
            var result = _projectController.EmployeeLogin(invalidModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result, "EmployeeLogin action should return a ViewResult.");
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName), $"Expected ViewName to be null or empty but was '{result?.ViewName}'");
            Assert.IsFalse(_projectController.ModelState.IsValid, "ModelState should be invalid.");
        }

        [Test]
        public void EmployeeLogin_ValidModel_RedirectsToEmployeeDashboard()
        {
            // Arrange
            var validModel = new EmployeeDetails { EmpID = 1, Password = "validPassword" };

            // Mock the repository to simulate a valid employee
            _projectController.ModelState.Clear();

            // Act
            var result = _projectController.EmployeeLogin(validModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result, "EmployeeLogin action should redirect on valid login.");
            Assert.AreEqual("EmployeeDashboard", result.RouteValues["action"]);
        }

        [Test]
        public void ManagerLogin_InvalidModel_ReturnsViewWithModelError()
        {
            // Arrange
            var invalidModel = new ManagerLogin { ManagerID = 0, Password = "invalid" };
            _projectController.ModelState.AddModelError("key", "Invalid model state");

            // Act
            var result = _projectController.ManagerLogin(invalidModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result, "ManagerLogin action should return a ViewResult.");
            Assert.IsTrue(string.IsNullOrEmpty(result.ViewName), $"Expected ViewName to be null or empty but was '{result?.ViewName}'");
            Assert.IsFalse(_projectController.ModelState.IsValid, "ModelState should be invalid.");
        }

        [Test]
        public void ManagerLogin_ValidModel_RedirectsToManagerDashboard()
        {
            // Arrange
            var validModel = new ManagerLogin { ManagerID = 1, Password = "validPassword" };

            // Mock the repository to simulate a valid manager
            _projectController.ModelState.Clear();

            // Act
            var result = _projectController.ManagerLogin(validModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result, "ManagerLogin action should redirect on valid login.");
            Assert.AreEqual("ManagerDashboard", result.RouteValues["action"]);
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up resources after each test
        }
    }
}
