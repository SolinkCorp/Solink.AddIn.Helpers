using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solink.AddIn.Helpers.Test
{
    public interface IThingWithDependency
    {
        void SomeMethodWithExternalDependency(AssertFailedException exception);
    }
}