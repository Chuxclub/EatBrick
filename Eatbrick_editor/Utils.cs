using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eatbrick_editor
{
    public enum BrickKind { AIR, SIMPLE, DOUBLE, TRIPLE, NEWBALL, MODIFBALL, PADINCR, PADDECR, PADRESET, SOLID };
    public class Brick
    {

        public Brick(int col, int row, BrickKind kind)
        {
            Row = row;
            Column =  col;
            Kind = kind;
        }

        public int Column { get; set; }
        public int Row { get; set; }

        public BrickKind Kind { get; set; }
    }

}
