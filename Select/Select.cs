namespace Select
{
    public static class Quick
    {
        public static T QuickSelect<T>(List<T> A, int n, int k)
        {
            if (n < 2)
                return A[0];
            int max = 0;
            for (int i = 1; i < n; i++)
                if (Convert.ToInt32(A[i]) > Convert.ToInt32(A[max]))
                    max = i;
            T temp;
            temp = A[n - 1];
            A[n - 1] = A[max];
            A[max] = temp;
            return QuickSelect(A, 0, n - 2, k);
        }
        private static T QuickSelect<T>(List<T> A, int first, int last, int k)
        {
            int lower = first + 1, upper = last;
            T temp;
            temp = A[first];
            A[first] = A[(first + last) / 2];
            A[(first + last) / 2] = temp;
            T bound = A[first];
            while (lower <= upper)
            {
                while (Convert.ToInt32(A[lower]) < Convert.ToInt32(bound))
                    lower++;
                while (Convert.ToInt32(bound) < Convert.ToInt32(A[upper]))
                    upper--;
                if (lower < upper)
                {
                    temp = A[lower];
                    A[lower] = A[upper];
                    A[upper] = temp;
                    lower++;
                    upper--;
                }
                else lower++;
            }
            temp = A[upper];
            A[upper] = A[first];
            A[first] = temp;
            if (upper == k)
                return A[upper];
            else if (k < upper)
                return QuickSelect(A, first, upper - 1, k);
            else
                return QuickSelect(A, upper + 1, last, k);
        }
    }

}