using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jun
{
    static class CompoundOps
    {
        public const short SelectAll = 0;
        public const short SelectAllies = 1;
        public const short SelectEnemies = 2;
        public const short SelectRandom = -1;

        public const short FilterAlive = 0;
        public const short FilterRange = 1;
        public const short FilterHPBelow = 2;

        public static void Initialise(Dictionary<string, Action<Emitter, int, bool>> handlers)
        {
            handlers["SELECTALL"] = OpSelectAll;
            handlers["SELECTALLIES"] = OpSelectAllies;
            handlers["SELECTENEMIES"] = OpSelectEnemies;

            handlers["SELECTRANDOMTARGET"] = OpSelectRandom;

            handlers["FILTERALIVETARGETS"] = OpFilterAlive;
            handlers["FILTERHPBELOWTARGETS"] = OpFilterHPBelow;
            handlers["FILTERTARGETSBYRANGE"] = OpFilterRange;
        }

        static void OpSelectAll(Emitter e, int args, bool returnResult)
        {
            e.Literal(SelectAll);
            e.Emit(Op.SelectTargets);
        }

        static void OpSelectAllies(Emitter e, int args, bool returnResult)
        {
            e.Literal(SelectAllies);
            e.Emit(Op.SelectTargets);
        }

        static void OpSelectEnemies(Emitter e, int args, bool returnResult)
        {
            e.Literal(SelectEnemies);
            e.Emit(Op.SelectTargets);
        }

        static void OpSelectRandom(Emitter e, int args, bool returnResult)
        {
            e.Literal(SelectRandom);
            e.Emit(Op.SelectTarget);
        }

        static void OpFilterAlive(Emitter e, int args, bool returnResult)
        {
            e.Literal(1);
            e.Literal(FilterAlive);
            e.Emit(Op.FilterTargets);
        }

        static void OpFilterRange(Emitter e, int args, bool returnResult)
        {
            e.Literal(FilterRange);
            e.Emit(Op.FilterTargets);
        }

        static void OpFilterHPBelow(Emitter e, int args, bool returnResult)
        {
            e.Literal(FilterHPBelow);
            e.Emit(Op.FilterTargets);
        }
    }
}
