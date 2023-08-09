using System.ComponentModel;

namespace PDIProject.Domain.Enums
{
    public enum ETaskJobStatus
    {
        [Description("None")]
        None = 0,
        [Description("Pendente")]
        Pending = 1,
        [Description("Em progresso")]
        InProgress = 2,
        [Description("Concluída")]
        Completed = 3,
        [Description("Em espera")]
        OnHold = 4,
        [Description("Abandonada")]
        Abandoned = 5
    }
}
