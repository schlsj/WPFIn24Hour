using System.Collections.Generic;

namespace ContactManager.Model
{
    static class States
    {
        private static readonly List<string> Names;

        static States()
        {
            Names = new List<string>();
            Names.Add("Alabama");
            Names.Add("Alaska");
            Names.Add("Arizona");
            Names.Add("Arkansas");
            Names.Add("California");
        }

        public static IList<string> GetNames()
        {
            return Names;
        }
    }
}
