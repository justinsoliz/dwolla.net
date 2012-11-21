using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Dwolla.Tests.Helpers
{
    public static class ShouldExtenstions
    {
        public static void ShouldBeTrue(this bool actualValue)
        {
            Assert.IsTrue(actualValue);
        }

        public static void ShouldBeFalse(this bool actualValue)
        {
            Assert.IsFalse(actualValue);
        }

        public static void ShouldEqual(this string actualValue, string expectedValue)
        {
            Assert.AreEqual(expectedValue, actualValue);
        }

        public static void ShouldEqual<T>(this T actualValue, T expectedValue)
        {
            try { Assert.AreEqual(expectedValue, actualValue); }

            catch (Exception)
            {
                FindDifferingProperties(actualValue, expectedValue);
                throw;
            }
        }

        public static void ShouldEqual<T>(this T actualValue, T expectedValue, string message)
        {
            try { Assert.AreEqual(expectedValue, actualValue, message); }

            catch (Exception)
            {
                FindDifferingProperties(actualValue, expectedValue);
                throw;
            }
        }

        private static void FindDifferingProperties<T>(T firstObject, T secondObject)
        {
            foreach (var property in firstObject.GetType().GetProperties())
            {
                var propertyVal = property.GetValue(firstObject, null);

                var otherPropertyVal = secondObject.GetType()
                    .GetProperty(property.Name).GetValue(secondObject, null);

                if (!Equals(propertyVal, otherPropertyVal))
                {
                    Console.WriteLine("Objects have different values for '{0}' field", property.Name);
                    Console.WriteLine("First Object Value: {0}", propertyVal);
                    Console.WriteLine("Second Object Value: {0}", otherPropertyVal);
                }

            }
        }



        public static void ShouldNotEqual<T>(this T actualValue, T expectedValue)
        {
            Assert.AreNotEqual(expectedValue, actualValue);
        }

        public static void ShouldNotEqual<T>(this T actualValue, T expectedValue, string message)
        {
            Assert.AreNotEqual(expectedValue, actualValue, message);
        }

        public static void ShouldBeGreaterThan(this int actualValue, int expectedValue)
        {
            Assert.IsTrue(actualValue > expectedValue);
        }

        public static void ShouldBeGreaterThan(this int actualValue, int expectedValue, string message)
        {
            Assert.IsTrue(actualValue > expectedValue, message);
        }

        public static void ShouldBeNull<T>(this T actualValue)
        {
            Assert.IsNull(actualValue);
        }

        public static void ShouldNotBeNull<T>(this T actualValue)
        {
            Assert.AreNotEqual(actualValue, null);
        }

        public static void ShouldBeOfType<T1, T2>(this T1 actualValue, T2 expectedValue)
        {
            Assert.AreEqual(actualValue.GetType(), expectedValue);
        }

        // Collections
        public static void ShouldBeEmpty<T>(this List<T> actualValue)
        {
            Assert.IsEmpty(actualValue);
        }

        public static void ShouldContain(this string actualValue, string expectedValue)
        {
            Assert.IsTrue(actualValue.Contains(expectedValue));
        }

        public static void ShouldNotContain(this string actualValue, string expectedValue)
        {
            Assert.IsFalse(actualValue.Contains(expectedValue));
        }

        public static void ShouldContain<T>(this List<T> actualValue, T expectedValue)
        {
            Assert.Contains(expectedValue, actualValue);
        }

        public static void ShouldNotContain<T>(this List<T> actualValue, T expectedValue)
        {
            Assert.IsFalse(actualValue.Contains(expectedValue));
        }
    }
}
