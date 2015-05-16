using System.Collections.Generic;
using CollectiveIntelligence.Core.Obsolete;
using NUnit.Framework;

namespace CollectiveIntelligence.Core.Tests.Obsolete
{
    public class SimilarityObsoleteEuclideanDistanceTests
    {
        [Test]
        public void Should_Return_Correct_Euclidean_Distance_When_People_Have_Common_Preferences()
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
            // (2.5-3)^2 + (0)^2 + (3-1.5)^2 + (3.5-5)^2 + (2.5-3.5)^2 + (0)^2
            // 0.5^2 + 1.5^2 + 1.5^2 + 1
            // 0.25 + 2.25 + 2.25 + 1
            // 5.75

            var preferences = new Similarity.Preferences(list);
            var result = Similarity.GetEuclideanDistance(preferences, person1, person2);

            Assert.AreEqual(result, 0.29429805508554946);
        }

        [Test]
        public void Should_Return_Zero_Euclidean_Distance_When_People_Have_No_Preferences_In_Common()
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
                new Similarity.Preference(person2, "Just My Luck", 1.5),
                new Similarity.Preference(person2, "Superman Returns", 5),
                new Similarity.Preference(person2, "You, Me and Dupree", 3.5),
                new Similarity.Preference(person2, "The Night Listener", 3.0)
            };

            var preferences = new Similarity.Preferences(list);
            var result = Similarity.GetEuclideanDistance(preferences, person1, person2);

            Assert.AreEqual(result, 0);
        }
    }
}