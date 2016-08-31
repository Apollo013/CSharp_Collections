using CSharpCollections.Models;
using System.Collections.Generic;

namespace CSharpCollections.EqualityComparers
{
    /// <summary>
    /// See 'GenericHashSetCollectionWithEqualityComparer' for implementation
    /// </summary>
    public class FrenchOpenWinnersComparer : IEqualityComparer<Winner>
    {
        public bool Equals(Winner x, Winner y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Winner obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
