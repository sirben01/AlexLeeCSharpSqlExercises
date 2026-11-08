
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Xml.Serialization;

namespace AlexLeeDevExercises.UnitTests
{
    public class PrintInterleavedOutputTests
    {
        [SetUp]
        public void Setup()
        {
        }


        //Tests for PrintInterleavedOutput function
        [Test]
        public void PrintInterleavedOutput_InterleavesCharactersCorrectlySameLength()
        {
            var str1 = "abc";
            var str2 = "123";
            var result = Helpers.PrintInterleavedOutput(str1, str2);

            Assert.That(result, Is.EqualTo("a1b2c3"));
        }
        [Test]
        public void PrintInterleavedOutput_InterleavesCharactersCorrectlyOneLargeLength()
        {
            var str1 = "abc";
            var str2 = "12345";
            var result = Helpers.PrintInterleavedOutput(str1, str2);

            Assert.That(result, Is.EqualTo("a1b2c345"));
        }
        [Test]
        public void PrintInterleavedOutput_InterleavesCharactersCorrectlyOneSmallLength()
        {
            var str1 = "abcdef";
            var str2 = "12";
            var result = Helpers.PrintInterleavedOutput(str1, str2);
            Assert.That(result, Is.EqualTo("a1b2cdef"));
        }
        [Test]
        public void PrintInterleavedOutput_InterleavesCharactersCorrectlyEmptyString()
        {
            var str1 = "";
            var str2 = "123";
            var result = Helpers.PrintInterleavedOutput(str1, str2);
            Assert.That(result, Is.EqualTo("123"));
        }
        [Test]
        public void PrintInterleavedOutput_InterleavesCharactersCorrectlyNullString()
        {
            string str1 = null;
            var str2 = "123";
            var result = Helpers.PrintInterleavedOutput(str1, str2);
            Assert.That(result, Is.EqualTo("123"));
        }
        [Test]
        public void PrintInterleavedOutput_InterleavesCharactersCorrectlyBothNullStrings()
        {
            string str1 = null;
            string str2 = null;
            var result = Helpers.PrintInterleavedOutput(str1, str2);
            Assert.That(result, Is.EqualTo(""));
        }
        [Test]
        public void PrintInterleavedOutput_InterleavesCharactersCorrectlyBothEmptyStrings()
        {
            var str1 = "";
            var str2 = "";
            var result = Helpers.PrintInterleavedOutput(str1, str2);
            Assert.That(result, Is.EqualTo(""));
        }
      



        
    }
}
