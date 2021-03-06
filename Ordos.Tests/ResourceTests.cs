﻿using System.IO;
using System.Linq;
using Xunit;

namespace Ordos.Tests
{
    public class ResourceTests
    {
        [Fact]
        public void TestResourceFileExists()
        {
            var filename = "./Resources/Single1.CFG";
            Assert.True(File.Exists(filename));
        }

        [Fact]
        public void TestGetResourceFileContent()
        {
            var filename = "./Resources/Single1.CFG";
            Assert.True(File.ReadAllLines(filename).Count()>0);
        }
    }
}
