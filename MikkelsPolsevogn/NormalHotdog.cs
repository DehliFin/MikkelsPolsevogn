using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MikkelsPolsevogn
{
    class NormalHotdog:Food
    {
        public Bread Bread { get; set; }
        public BoiledSausage BoiledSausage { get; set; }
        
        public NormalHotdog(Bread bread, BoiledSausage boiledSausage, string name)
        {
            Bread = bread;
            BoiledSausage = boiledSausage;
            Name = name;
        }
    }
}
