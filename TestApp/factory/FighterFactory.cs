using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.fighter;

namespace TestApp.factory
{
    public class FighterFactory
    {

        public Fighter createFighter(string team, string type)
        {
            switch(type)
            {
                case "BOX_FIGHTER":
                    return new BoxFighter(team);
                case "MMA_FIGHTER":
                    return new MmaFighter(team);
                case "COMPLEX_FIGHTER":
                    return new ComplexFighter(team);
                default: return null;
            }
        }

    }
}
