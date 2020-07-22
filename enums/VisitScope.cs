using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SementesTeste.enums
{
    public enum VisitScale
    {
        Mensal,
        Bimestral,
        Trimestral,
        PorConvite,
        ApresentacaoUnica

    }
    public enum VisitMaximumPeople
    {
        TresVoluntários,
        SeisVoluntários,
        Livre

    }
    public enum VisitPeriod
    {
        Manha,
        Tarde
    }
    public enum ActionKind
    {
        HumanizacaoHospitalar,
        HumanizacaoInstituicao,
        ApresentacaoTeatral,
        Intervencao,
        SuperSanguinho

    }
}