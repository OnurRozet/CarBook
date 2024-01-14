using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domanin.Entities
{
	public class Feature
	{
        public int FeatureId { get; set; }
        public int Name { get; set; }
        public List<CarFeature> CarFeatures { get; set; }
    }
}
