using System.Reflection;
using System.Collections.Generic;

namespace Simkl.Api.Objects {
    public class SimklIds {
        public int simkl { get; set; }
        public int imdb { get; set; }
        public string slug { get; set; }

        /// <summary>
        /// Creates an MovieIds object given a dictionary
        /// </summary>
        public SimklIds (Dictionary<string, string> ProviderIds)
        {            
            foreach (KeyValuePair<string, string> id in ProviderIds) {
                PropertyInfo prop = GetType().GetProperty(id.Key.ToLower());
                if (prop.PropertyType == typeof(int?)) {
                    prop.SetValue(this, int.Parse(id.Value));
                } else if (prop.PropertyType == typeof(string)) {
                    prop.SetValue(this, id.Value);
                }
            }
        }
    }
}