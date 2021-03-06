﻿using System;
using System.Data.Entity;
using System.Reflection;

using Moq;
using NUnit.Framework;

using WhenItsDone.Data.Contracts;
using WhenItsDone.Data.Repositories;
using WhenItsDone.Models.Contracts;

namespace WhenItsDone.Data.Tests.RepositoriesTests.AsyncGenericRepositoryTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ShouldThrowArgumentNullExceptionWithCorrectMessage_WhenIWhenItsDoneDbContextParameterIsNull()
        {
            IWhenItsDoneDbContext invalidDbContext = null;

            Assert.That(
                () => new GenericAsyncRepository<IDbModel>(invalidDbContext),
                Throws.InstanceOf<ArgumentNullException>().With.Message.Contains("DbContext"));
        }

        [Test]
        public void ShouldInvoke_DbContextSetMethodOnce()
        {
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);

            var asyncGenericRepository = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            mockDbContext.Verify(mock => mock.Set<IDbModel>(), Times.Once);
        }

        [Test]
        public void ShouldThrowArgumentExceptionWithCorrectMessage_WhenDbContextDoesNotContainADbSetOfTheCorrectType()
        {
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns<DbSet<IDbModel>>(null);

            Assert.That(
                () => new GenericAsyncRepository<IDbModel>(mockDbContext.Object),
                Throws.InstanceOf<ArgumentException>().With.Message.Contains("DbContext does not contain DbSet"));
        }

        [Test]
        public void ShouldNotThrow_WhenParametersAreCorrect()
        {
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);

            var asyncGenericRepository = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            Assert.That(asyncGenericRepository, Is.Not.Null);
        }

        [Test]
        public void ShouldCreateAnObjectWhichImplementsIAsyncRepository()
        {
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);

            var asyncGenericRepository = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            Assert.That(asyncGenericRepository, Is.InstanceOf<IAsyncRepository<IDbModel>>());
        }

        [Test]
        public void ShouldSetCorrectValueToPrivateFieldDbContext_WhenParametersAreCorrect()
        {
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);

            var actualAsyncGenericRepositoryInstace = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            var fieldName = "dbContext";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbContextField = actualAsyncGenericRepositoryInstace.GetType().GetField(fieldName, bindingFlags);
            var dbContextFieldValue = dbContextField.GetValue(actualAsyncGenericRepositoryInstace);

            Assert.That(dbContextFieldValue, Is.Not.Null.And.EqualTo(mockDbContext.Object));
        }

        [Test]
        public void ShouldSetCorrectValueToPrivateFieldDbSet_WhenParametersAreCorrect()
        {
            var fakeDbSet = new Mock<DbSet<IDbModel>>();
            var mockDbContext = new Mock<IWhenItsDoneDbContext>();
            mockDbContext.Setup(mock => mock.Set<IDbModel>()).Returns(fakeDbSet.Object);

            var actualAsyncGenericRepositoryInstace = new GenericAsyncRepository<IDbModel>(mockDbContext.Object);

            var fieldName = "dbSet";
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Instance;
            var dbSetField = actualAsyncGenericRepositoryInstace.GetType().GetField(fieldName, bindingFlags);
            var dbSetFieldValue = dbSetField.GetValue(actualAsyncGenericRepositoryInstace);

            Assert.That(dbSetFieldValue, Is.Not.Null.And.EqualTo(fakeDbSet.Object));
        }
    }
}
