using BansosKuAPI.Controllers;
using BansosKuAPI.Interface;
using BansosKuAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit.Sdk;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;
using CollectionAssert = NUnit.Framework.CollectionAssert;

namespace BansosKuAPI.Tests
{
    public class BansosControllerTests
    {
        private readonly Mock<IBansosRepository> _mockBansosRepository;
        private readonly Mock<IAuthRepository> _mockAuthRepository;
        private readonly BansosController _controller;

        public BansosControllerTests()
        {
            _mockBansosRepository = new Mock<IBansosRepository>();
            _mockAuthRepository = new Mock<IAuthRepository>();
            _controller = new BansosController(_mockBansosRepository.Object, _mockAuthRepository.Object);
        }

        [Test]
        public void GetBansos_ReturnsOkResult()
        {
            // Arrange
            var bansosList = new List<Bansos>();
            _mockBansosRepository.Setup(repo => repo.GetBansos()).Returns(bansosList);

            // Act
            var result = _controller.GetBansos();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var model = okResult.Value as IEnumerable<Bansos>;
            Assert.IsNotNull(model);
            CollectionAssert.AreEqual(bansosList, model);
        }

        [Test]
        public void GetBansosById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var bansosList = new List<Bansos>();
            _mockBansosRepository.Setup(repo => repo.GetBansos()).Returns(bansosList);

            // Act
            var result = _controller.GetBansos();

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var model = okResult.Value as IEnumerable<Bansos>;
            Assert.IsNotNull(model);
            CollectionAssert.AreEqual(bansosList, model);

        }

        [Test]
        public void GetBansosById_WithInvalidId_ReturnsBadRequest()
        {
            // Arrange
            int invalidId = 1;
            _mockBansosRepository.Setup(repo => repo.GetBansosById(invalidId)).Returns((Bansos)null);

            // Act
            var result = _controller.GetBansosById(invalidId);

            // Assert
            Assert.NotNull(result);

            var badRequestResult = result as BadRequestResult;
            Assert.NotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);
        }

        [Test]
        public void DeleteBansos_WithValidId_ReturnsOkResult()
        {
            // Arrange
            var bansos = new Bansos();
            _mockBansosRepository.Setup(repo => repo.GetBansosById(It.IsAny<int>())).Returns(bansos);

            // Act
            var result = _controller.DeleteBansos(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var value = okResult.Value as bool?;
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Value);
        }

        [Test]
        public void DeleteBansos_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var bansos = new Bansos();
            _mockBansosRepository.Setup(repo => repo.GetBansosById(It.IsAny<int>())).Returns(bansos);

            // Act
            var result = _controller.DeleteBansos(1);

            // Assert
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            var value = okResult.Value as bool?;
            Assert.IsNotNull(value);
            Assert.IsTrue(value.Value);
        }

    }
}
