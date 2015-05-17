using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectiveIntelligence.Core
{
    public class Similarity<TEntity, TItem> : ISimilarity<TEntity, TItem>
    {
        private IEnumerable<TItem> GetCommonItems(IReadOnlyDictionary<TEntity, Dictionary<TItem, double>> preferences, TEntity entity1, TEntity entity2)
        {
            return preferences[entity1].Where(pref => preferences[entity2].ContainsKey(pref.Key)).Select(pair => pair.Key);
        }

        public double GetSimilarityByEuclideanDistance(Dictionary<TEntity, Dictionary<TItem, double>> preferences,
    TEntity entity1, TEntity entity2)
        {
            if (preferences == null)
            {
                throw new ArgumentNullException("preferences");
            }

            if (entity1 == null)
            {
                throw new ArgumentNullException("entity1");
            }

            if (entity2 == null)
            {
                throw new ArgumentNullException("entity2");
            }

            if (!preferences.ContainsKey(entity1) || !preferences.ContainsKey(entity2))
            {
                return 0;
            }

            var similarities = GetCommonItems(preferences, entity1, entity2).ToArray();
            if (!similarities.Any())
            {
                return 0;
            }

            var sumOfSquares = similarities.Select(sim => Math.Pow(preferences[entity1][sim] - preferences[entity2][sim], 2)).Sum();
            return 1/(1 + Math.Sqrt(sumOfSquares));
        }

        public double GetPearsonCorrelation(Dictionary<TEntity, Dictionary<TItem, double>> preferences, TEntity entity1, TEntity entity2)
        {
            if (preferences == null)
            {
                throw new ArgumentNullException("preferences");
            }

            if (entity1 == null)
            {
                throw new ArgumentNullException("entity1");
            }

            if (entity2 == null)
            {
                throw new ArgumentNullException("entity2");
            }

            if (!preferences.ContainsKey(entity1) || !preferences.ContainsKey(entity2))
            {
                return 0;
            }

            var similarities = GetCommonItems(preferences, entity1, entity2).ToArray();
            if (!similarities.Any())
            {
                return 0;
            }
            var similaritiesCount = similarities.Count();

            // Add up all the preferences
            var sum1 = similarities.Select(sim => preferences[entity1][sim]).Sum();
            var sum2 = similarities.Select(sim => preferences[entity2][sim]).Sum();


            // Sum up the squares
            var sumOfSquares1 = similarities.Select(sim => Math.Pow(preferences[entity1][sim], 2)).Sum();
            var sumOfSquares2 = similarities.Select(sim => Math.Pow(preferences[entity2][sim], 2)).Sum();


            // Sum up the products
            var sumOfProducts = similarities.Select(sim => preferences[entity1][sim]*preferences[entity2][sim]).Sum();

            // Calculate Pearson Correlation Coefficient
            var numerator = sumOfProducts - (sum1*sum2)/similaritiesCount;
            var denominator =
                Math.Sqrt((sumOfSquares1 - Math.Pow(sum1, 2)/similaritiesCount)*
                          (sumOfSquares2 - Math.Pow(sum2, 2)/similaritiesCount));

            if (denominator == 0)
            {
                return 0;
            }

            return numerator/denominator;
        }

        public SortedDictionary<double, TEntity> TopMatches(Dictionary<TEntity, Dictionary<TItem, double>> preferences, TEntity entity,
            int limit, Func<Dictionary<TEntity, Dictionary<TItem, double>>, TEntity, TEntity, double> metricFunc)
        {
            var result = new SortedDictionary<double, TEntity>(new DescendingCompare<double>());
            foreach (var currentEntity in preferences.Select(currentEntityItems => currentEntityItems.Key).Where(currentEntity => !currentEntity.Equals(entity)).Where(currentEntity => result.Count < limit))
            {
                result.Add(metricFunc(preferences, entity, currentEntity), currentEntity);
            }
            return result;
        }
    }

    public class DescendingCompare<T> : Comparer<T> where T : IComparable<T>
    {
        public override int Compare(T x, T y)
        {
            return y == null ? 1 : y.CompareTo(x);
        }
    } 
}
