using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MvvmCross.Plugins.Sqlite;
using WeeBet.Core.Contracts.Repository;
using WeeBet.Core.Models;
using WeeBet.Core.Services;
using WeeBet.Core.Contracts;
using MvvmCross.Platform;
using MvvmCross.Test.Core;
using WeeBet.Core.UnitTests.Bootstrap;
using WeeBet.Core.ViewModels;

namespace WeeBet.Core.UnitTests.Repository
{
    [TestClass]
    public class FavouriteCompetitionRepositoryTest : MvxIoCSupportingTest
    {
      
        [TestMethod]
        public void TestInsertFavouriteCompetition()
        {
            base.Setup();
            ShowCompetitionsViewModel vm = Mvx.IocConstruct<ShowCompetitionsViewModel>();
                
            //FavouriteCompetitionRepository repo = Mvx.IocConstruct<FavouriteCompetitionRepository>(); 
            Competition c = new Competition() { Id = 1, Name = "Super Liga" };

        }

        
    }
}
