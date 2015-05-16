using System;
using System.Collections.Generic;
using CollectiveIntelligence.Core.Obsolete;
using NUnit.Framework;

namespace CollectiveIntelligence.Core.Tests
{
    [TestFixture]
    public class SimilarityMetricsTests
    {
        [Test]
        public void Generic_Should_Return_Correct_Euclidean_Distance_When_Entities_Have_Common_Preferences()
        {
            const string entity1 = "Lisa Rose";
            const string entity2 = "Gene Seymour";

            var entity1Preferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0},
                {"Superman Returns", 3.5},
                {"You, Me and Dupree", 2.5},
                {"The Night Listener", 3.0}
            };
            var entity2Preferences = new Dictionary<string, double>            
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 1.5},
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5},
                {"The Night Listener", 3.0}
            };

            var preferences = new Dictionary<string, Dictionary<string, double>>
            {
                {entity1, entity1Preferences},
                {entity2, entity2Preferences}
            };
            var sim = new Similarity<string, string>();
            var result = sim.GetSimilarity(preferences, entity1, entity2,
                sim.GetSimilarityByEuclideanDistance);

            Assert.AreEqual(result, 0.29429805508554946);
        }

        [Test]
        public void Generic_Should_Return_Zero_Euclidean_Distance_When_Entities_Have_No_Preferences_In_Common()
        {
            const string entity1 = "Lisa Rose";
            const string entity2 = "Gene Seymour";

            var entity1Preferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0}
            };
            var entity2Preferences = new Dictionary<string, double>            
            {
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5},
                {"The Night Listener", 3.0}
            };

            var preferences = new Dictionary<string, Dictionary<string, double>>
            {
                {entity1, entity1Preferences},
                {entity2, entity2Preferences}
            };
            var sim = new Similarity<string, string>();
            var result = sim.GetSimilarity(preferences, entity1, entity2, sim.GetSimilarityByEuclideanDistance);

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void Generic_Should_Return_Correct_Pearson_Correlation_When_People_Have_Common_Preferences()
        {
            const string entity1 = "Lisa Rose";
            const string entity2 = "Gene Seymour";

            var entity1Preferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0},
                {"Superman Returns", 3.5},
                {"You, Me and Dupree", 2.5},
                {"The Night Listener", 3.0}
            };
            var entity2Preferences = new Dictionary<string, double>            
            {
                {"Lady in the Water", 3},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 1.5},
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5},
                {"The Night Listener", 3.0}
            };

            var preferences = new Dictionary<string, Dictionary<string, double>>
            {
                {entity1, entity1Preferences},
                {entity2, entity2Preferences}
            };
            var sim = new Similarity<string, string>();
            var result = sim.GetSimilarity(preferences, entity1, entity2, sim.GetPearsonCorrelation);

            Assert.AreEqual(Math.Round(result, 12), 0.396059017191);
        }

        [Test]
        public void Generic_Should_Return_Zero_Pearson_Correlation_When_People_Have_Common_Preferences()
        {
            const string entity1 = "Lisa Rose";
            const string entity2 = "Gene Seymour";

            var entity1Preferences = new Dictionary<string, double>
            {
                {"Lady in the Water", 2.5},
                {"Snakes on a Plane", 3.5},
                {"Just My Luck", 3.0}
            };
            var entity2Preferences = new Dictionary<string, double>            
            {
                {"Superman Returns", 5},
                {"You, Me and Dupree", 3.5},
                {"The Night Listener", 3.0}
            };

            var preferences = new Dictionary<string, Dictionary<string, double>>
            {
                {entity1, entity1Preferences},
                {entity2, entity2Preferences}
            };

            var sim = new Similarity<string, string>();
            var result = sim.GetSimilarity(preferences, entity1, entity2, sim.GetPearsonCorrelation);

            Assert.AreEqual(result, 0);
        }
    }

    [TestFixture]
    public class SimilarityGeneralTests
    {
        
    }


}
