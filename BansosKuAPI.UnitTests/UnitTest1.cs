using BansosKuAPI.Controllers;
using BansosKuAPI.Interface;
using BansosKuAPI.Model;
using BansosKuAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;

namespace BansosKuAPI.UnitTests
{
    [TestFixture]
    public class AuthRepositoryTests
    {
        private IAuthRepository _authRepository;

        [SetUp]
        public void Setup()
        {
            _authRepository = new AuthRepository();
        }

        [Test]
        public void AddUser_ValidUser_ReturnsUserId()
        {
            // Arrange
            User user = new User()
            {
                Id = 1,
                Fullname = "John Doe",
                NIK = "1234567890",
                Password = "password",
                Role = "User",
                Alamat = "Jl. Contoh No. 123",
                FotoKTP = "ktp.jpg",
                Pendapatan = "1000000",
                FotoRumah = "rumah.jpg"
            };

            // Act
            int userId = _authRepository.AddUser(user);

            // Assert
            Assert.AreEqual(1, userId);
        }

        [Test]
        public void Authentication_CorrectCredentials_ReturnsTrue()
        {
            // Arrange
            User user = new User()
            {
                Id = 1,
                Fullname = "John Doe",
                NIK = "1234567890",
                Password = "password",
                Role = "User",
                Alamat = "Jl. Contoh No. 123",
                FotoKTP = "ktp.jpg",
                Pendapatan = "1000000",
                FotoRumah = "rumah.jpg"
            };
            _authRepository.AddUser(user);

            // Act
            bool isAuthenticated = _authRepository.Authentication("1234567890", "password");

            // Assert
            Assert.IsTrue(isAuthenticated);
        }

        [Test]
        public void DeleteUser_ValidUser_ReturnsTrue()
        {
            // Arrange
            User user = new User()
            {
                Id = 1,
                Fullname = "John Doe",
                NIK = "1234567890",
                Password = "password",
                Role = "User",
                Alamat = "Jl. Contoh No. 123",
                FotoKTP = "ktp.jpg",
                Pendapatan = "1000000",
                FotoRumah = "rumah.jpg"
            };
            _authRepository.AddUser(user);

            // Act
            bool isDeleted = _authRepository.DeleteUser(user);

            // Assert
            Assert.IsTrue(isDeleted);
        }

        [Test]
        public void GetUserById_ExistingId_ReturnsUser()
        {
            // Arrange
            User user = new User()
            {
                Id = 1,
                Fullname = "John Doe",
                NIK = "1234567890",
                Password = "password",
                Role = "User",
                Alamat = "Jl. Contoh No. 123",
                FotoKTP = "ktp.jpg",
                Pendapatan = "1000000",
                FotoRumah = "rumah.jpg"
            };
            _authRepository.AddUser(user);

            // Act
            User retrievedUser = _authRepository.GetUserById(1);

            // Assert
            Assert.AreEqual(user, retrievedUser);
        }

        [Test]
        public void GetUsers_EmptyRepository_ReturnsEmptyCollection()
        {
            // Act
            ICollection<User> users = _authRepository.GetUsers();

            // Assert
            Assert.IsEmpty(users);
        }
    }
}