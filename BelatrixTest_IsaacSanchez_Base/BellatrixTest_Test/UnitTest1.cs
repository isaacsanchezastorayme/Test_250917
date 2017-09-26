using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BelatrixTest.Business;

namespace BellatrixTest_Test
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// =============================================================================================================================
        /// Autor: Isaac Ismael Sanchez Astorayme - Belatrix Test
        /// File: UnitTest1.cs
        /// Date Created: 25/09/17
        /// Date Modified: 
        /// Description: To implement unit test.
        /// =============================================================================================================================
        /// </summary>
        [TestMethod]       
        public void combineArrayStringWithSpaceTest()
        {
            BusinessRulesTwo target = new BusinessRulesTwo(); // TODO: Initialize to an appropriate value
            string[] stringArray = null; // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = target.combineArrayStringWithSpace(stringArray);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
