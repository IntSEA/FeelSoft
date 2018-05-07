using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analytics;

namespace NaiveBayes
{
    interface INaiveBayes:IAnalityc
    {
       
        int[][] DataTestinputTraining { get; set; }
        int[] DataTestOutputTrainig { get; set; }
        int[][] DataTestinput { get; set; }
        int[] DataTestOutput { get; set; }
        double FailTrainig { get; set; }
        double FailDecided { get; set; }



    }
}
