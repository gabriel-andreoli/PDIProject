using System.ComponentModel;

namespace PDIProject.Domain.Enums
{
    public enum ERequirementPriority
    {
        [Description("Nenhum")]
        None = 0,
        [Description("Baixa")]
        Low = 1,
        [Description("Média")]
        Medium = 2,
        [Description("Alta")]
        High = 3,
        [Description("Muito alta")]
        SuperHigh= 4,
        [Description("Essencial")]
        Essential = 5,
    }
}
