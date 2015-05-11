using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CollectiveIntelligence.Core.Tests
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            var person2 = new Similarity.Person()
            {
                Name = "Lisa Rose"
            };
            var person1 = new Similarity.Person()
            {
                Name = "Gene Seymour"
            };
            var list = new List<Similarity.Preference>
            {
                new Similarity.Preference(person1, "Lady in the Water", 2.5),
                new Similarity.Preference(person1, "Snakes on a Plane", 3.5),
                new Similarity.Preference(person1, "Just My Luck", 3.0),
                new Similarity.Preference(person1, "Superman Returns", 3.5),
                new Similarity.Preference(person1, "You, Me and Dupree", 2.5),
                new Similarity.Preference(person1, "The Night Listener", 3.0),
                new Similarity.Preference(person2, "Lady in the Water", 3.0),
                new Similarity.Preference(person2, "Snakes on a Plane", 3.5),
                new Similarity.Preference(person2, "Just My Luck", 1.5),
                new Similarity.Preference(person2, "Superman Returns", 5),
                new Similarity.Preference(person2, "You, Me and Dupree", 3.5),
                new Similarity.Preference(person2, "The Night Listener", 3.0)
            };

            Similarity.Preferences preferences = new Similarity.Preferences(list);
            var result = Similarity.GetEuclideanDistance(preferences, person1, person2);

            Assert.Equals(result, 0.148148148148);
        }
    }
}
