using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.fighter;

namespace TestApp.visitor
{
    public interface IVisitor
    {
        void Visit(BoxFighter boxFighter);
        void Visit(MmaFighter mmaFighter);
        void Visit(ComplexFighter complexFighter);
    }
}
