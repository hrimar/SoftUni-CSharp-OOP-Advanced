using P09.InfernoInfinity.Contracts;
using P09.InfernoInfinity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

class StartUp
{
    static void Main()  // 100/100 - also with Command Pattern !
    {
        var engine = new Engine();
        engine.Run();
    }

}


