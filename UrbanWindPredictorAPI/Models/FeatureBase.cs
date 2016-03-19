using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrbanWindPredictorAPI.Models
{
    public class FeatureBase
    {
        public double multiplyValue { get; set; }
        public double powerValue { get; set; }

        public FeatureBase(Bias DbBias)
        {
            this.powerValue = 1;
            this.multiplyValue = DbBias.value;
        }

        public FeatureBase(Feature DbFeature)
        {
            this.multiplyValue = DbFeature.multiValue;
            this.powerValue = DbFeature.powValue;
        }

        public static double getPrediction(FeatureBase[] features)
        {

            double result = 0;

            foreach (var feature in features)
            {
                //accumulate features --  needs sigmoid-- use matrix math library when it inported.
                result += Math.Pow((feature.multiplyValue * 1) , feature.powerValue);
            }


            return 0.0;
        }


    }

}