using System;
using System.Collections.Generic;
using System.Text;

namespace AlexLeeDevExercises.UnitTests
{
    public class IsPalindromeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Tests for isPalindrome function
        [Test]
        public void IsPalindrome_ReturnsFalseIfNotNumberPalindrome()
        {
            var word = "122155555";
            var result = Helpers.IsPalindrome(word);
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsPalindrome_ReturnsTrueIfNumberIsPalindrome()
        {
            var word = "1221";
            var result = Helpers.IsPalindrome(word);
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_ReturnsTrueIfStringIsPalindrome()
        {
            var word = "racecar";
            var result = Helpers.IsPalindrome(word);
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_ReturnsFalseIfStringIsNotPalindrome()
        {
            var word = "hello";
            var result = Helpers.IsPalindrome(word);
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsPalindrome_ReturnsTrueIfStringIsPalindromeIgnoringCase()
        {
            var word = "RaceCar";
            var result = Helpers.IsPalindrome(word);
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_ReturnsTrueIfStringIsEmpty()
        {
            var word = "";
            var result = Helpers.IsPalindrome(word);
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsPalindrome_ReturnsTrueIfStringIsSingleCharacter()
        {
            var word = "a";
            var result = Helpers.IsPalindrome(word);
            Assert.That(result, Is.True);
        }
    }
}
