// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("pkP4hDPrEVv7t7V7KygpPFdt2+IrDpM4PSkHdPekxvn3ycRn+TtHv7qn7GnHLyFprNmdXA6e6eVWbbNMc19E9n8m9IRUR/FIC1ix8dTNCzVb6WpJW2ZtYkHtI+2cZmpqam5raGOHwb2e5xDffZCvW2DCIB0xOHDkyeK7YZ8kOrzWRuzMkWtWpUTd3hg6LhxxWXJx9HR40EvBlj/r252rxBbDtxr6pesXXDGkDBz69UR1e0gWIOaKHjjLX+Md83y7T75h3xcqnzvpamRrW+lqYWnpampr9sUiPrLrXbDZOorK1iA13H44v0XVj1qKwkFr/uycE9OsiIWXf7E1mzFO3kTHNlRcJ7Ds1XOxS70x3jglu2ZBC+eScpmU/TdKm0C14mloamtq");
        private static int[] order = new int[] { 7,6,12,11,7,12,8,12,10,12,10,11,13,13,14 };
        private static int key = 107;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
