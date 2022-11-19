using AubilousTouch.Core.Interfaces.Repositories;
using AubilousTouch.Intra.Context;
using AubilousTouch.Intra.Repositories;
using AubilousTouch.Core.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AubilousTouch.Test.IntegratedTests
{
    public class EmployeeRepositoryTest
    {
        public IEmployeeRepository _repository;

        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<AubilousTouchDbContext>();
            optionsBuilder.UseSqlServer(TestConstants.Settings.ConnectionString);

            var context = new AubilousTouchDbContext(optionsBuilder.Options);

            _repository = new EmployeeRepository(context);
        }

        [Test]
        public async Task EmployeeRepository_When_ValidModel_Should_Create_Record_On_Add()
        {
            //Arrange
            var Employee = new Employee()
            {
                Address = "123 street",
                AdmissionDate = DateTime.Now,
                AubayId = "I1234",
                BirthDate = DateTime.Now,
                CessationDate = DateTime.Now.AddMonths(-12),
                HasChildren = true,
                IsActive = true,
                MobilePhone = "+351 987 572 392",
                Nationality = "Portuguese",
                PreferredCommunicationLanguage = "Arabic",
                Role = "Developer",
                TaxNumber = "399473823",
            };

            //Act Assert
            Assert.DoesNotThrowAsync(async () => await _repository.AddAsync(Employee));

        }


    }
}
