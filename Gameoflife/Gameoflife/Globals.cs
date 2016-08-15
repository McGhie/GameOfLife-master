using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gameoflife
{
     public static class Globals
     {
            public static string GameOfLifeConnectionString { get; } =
                System.Configuration.ConfigurationManager.ConnectionStrings["GameOfLifeData"].ConnectionString;
     }
    
}