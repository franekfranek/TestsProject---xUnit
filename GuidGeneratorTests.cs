using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace TestProject
{
    // independent class withou using collections, 2 diffrent instances of 
    // classs GuidGenerator will be created
    // both test cases will write 2 difrent guids
    //public class GuidGeneratorTestsOne
    //{
    //    private readonly GuidGenerator _guidGenerator;
    //    private readonly ITestOutputHelper _output;
    //    public GuidGeneratorTestsOne(ITestOutputHelper output)
    //    {
    //        _output = output;
    //        _guidGenerator = new GuidGenerator();
    //    }

    //    [Fact]
    //    public void GuidTest1()
    //    {
    //        var guid = _guidGenerator.RandomGuid;
    //        _output.WriteLine($"The guid was: {guid}");
    //    }

    //    [Fact]
    //    public void GuidTest2()
    //    {
    //        var guid = _guidGenerator.RandomGuid;
    //        _output.WriteLine($"The guid was: {guid}");
    //    }
    //}


    // independent class withou using collections, the same instance of GuidGenerator will be used for both cases
    // that means one instance is used for test cases
    // both test cases will write same guids

    //public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator> { }
    //public class GuidGeneratorTestsOne : IClassFixture<GuidGenerator>
    //{
    //    private readonly GuidGenerator _guidGenerator;
    //    private readonly ITestOutputHelper _output;
    //    public GuidGeneratorTestsOne(ITestOutputHelper output, GuidGenerator guid)
    //    {
    //        _output = output;
    //        _guidGenerator = guid;
    //    }

    //    [Fact]
    //    public void GuidTest1()
    //    {
    //        var guid = _guidGenerator.RandomGuid;
    //        _output.WriteLine($"The guid was: {guid}");
    //    }
        
    //    [Fact]
    //    public void GuidTest2()
    //    {
    //        var guid = _guidGenerator.RandomGuid;
    //        _output.WriteLine($"The guid was: {guid}");
    //    }
    
    //every class using this definition will used the same SHARED CONTEXT
    [CollectionDefinition("Guid generator")] // 2nd parameter can disable parallelization to run the method one after another
    public class GuidGeneratorDefinition : ICollectionFixture<GuidGenerator> { }

    [Collection("Guid generator")]
    public class GuidGeneratorTestsOne 
    {
        private readonly GuidGenerator _guidGenerator;
        private readonly ITestOutputHelper _output;
        public GuidGeneratorTestsOne(ITestOutputHelper output, GuidGenerator guid)
        {
            _output = output;
            _guidGenerator = guid;
        }

        [Fact]
        public void GuidTest1()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was: {guid}");
        }
        
        [Fact]
        public void GuidTest2()
        {
            var guid = _guidGenerator.RandomGuid;
            _output.WriteLine($"The guid was: {guid}");
        }

        // it disposed used class AUTOMATICALLY can be used for db disposal 
        // needs IDisposable Iterface
        //public void Dispose()
        //{
        //    _output.WriteLine($"The class was: disposed");

        //}
    }
    public class GuidGeneratorTestsTwo
    {

    }
}
