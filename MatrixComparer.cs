using System;
using System.Collections.Generic;

namespace Detecting_Similarities
{
    public class MatrixComparer : IEqualityComparer<Matrix>
    {
        public bool Equals(Matrix x, Matrix y)
        {
            if (Object.ReferenceEquals(x, y)) return true;

            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;

            return x.Row == y.Row && x.Column == y.Column && x.Value == y.Value;
        }

        public int GetHashCode(Matrix mat)
        {
            if (Object.ReferenceEquals(mat, null)) return 0;

            int hashRowName = mat.Row == null ? 0 : mat.Row.GetHashCode();
            int hashColumnName = mat.Column == null ? 0 : mat.Column.GetHashCode();

            int hashValue = mat.Value.GetHashCode();

            return hashRowName ^ hashColumnName ^ hashValue;
        }
    }
}
