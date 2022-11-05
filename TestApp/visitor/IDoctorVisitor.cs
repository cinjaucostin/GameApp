using TestApp.fighter;

namespace TestApp.visitor
{
    // mi se pare mai dragut sa stiu din numele interfetei si scopul visitor-ului
    public interface IDoctorVisitor
    {
        void Visit(Fighter fighter);
    }
}
