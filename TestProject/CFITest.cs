using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CFI_App.Controllers;
using CFI_App.Models;
using System.Collections.Generic;
using TypeMock;
using System.Linq;
using System.Data.Entity;
using CFI_Web_Application.Controllers;
using System.Data;

namespace TestProject
{

    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestLINQ()
        {

            List<Subjects> test = new List<Subjects> {
                new Subjects{ CRN = 1234, Room = "B.B01" },
                new Subjects{ CRN = 0000, Room = "B.B02" },
                new Subjects{ CRN = 9999, Room = "B.B01" }};

            var queryResult = from s in test
                              where s.CRN == 1234
                          select new { s.CRN, s.Room };

            Assert.AreEqual(1, queryResult.Count());
        }

        [TestMethod]
        public void CreateDatabaseContext()
        {
            DatabaseContext db = new DatabaseContext();
            Assert.IsNotNull(db);
        }

    }
}
