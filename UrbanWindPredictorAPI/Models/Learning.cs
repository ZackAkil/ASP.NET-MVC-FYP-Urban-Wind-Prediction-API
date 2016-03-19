using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.SolverFoundation.Common;
using Microsoft.SolverFoundation.Solvers;

using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics;

namespace UrbanWindPredictorAPI.Models
{
    public static class Learning
    {
       private static Vector<Double> predictFunction(Matrix<Double> featureValues, Vector<Double> theta)
        {
            return sigmoidFunction(featureValues * theta);
        }

        private static Vector<Double> sigmoidFunction(Vector<Double> values)
        {
            var result = (1 / (values.Multiply(-1).PointwiseExp() + 1));
            Console.WriteLine(result);
            return result;
        }
    }
}