using System;
using System.IO;
using System.Linq;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solink.AddIn.Helpers.Test
{
    [TestClass]
    public class AddInFacadeTest
    {
        [TestMethod]
        public void RebuildPipeLineReturnsWarnings()
        {
            var randomFileName = Path.GetRandomFileName();
            var pipeline = Path.Combine(Path.GetTempPath(), randomFileName);
            var pipelineDirectoryInfo = new DirectoryInfo(pipeline);
            pipelineDirectoryInfo.Create();
            CreatePipeLine(pipelineDirectoryInfo);

            var addinfacade = new AddInFacade(pipelineDirectoryInfo);
            Assert.IsTrue(addinfacade.RebuildWarnings.Any());
            var firstwarning = string.Format(
                "There were no add-in bases found in \"{0}\"",
                Path.Combine(pipelineDirectoryInfo.FullName, "AddInViews"));
            Assert.AreEqual(firstwarning, addinfacade.RebuildWarnings.First());
        }

        private static void CreatePipeLine(DirectoryInfo root)
        {
            root.CreateSubdirectory("HostSideAdapters");
            root.CreateSubdirectory("Contracts");
            root.CreateSubdirectory("AddInViews");
            root.CreateSubdirectory("AddInSideAdapters");
            root.CreateSubdirectory("AddIns");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MissingPipelineFolderThrows()
        {
            var addinfacade = new AddInFacade();
        }
    }
}
