using PDIProject.Domain.Commands.TeamCommands;

namespace PDIProject.Domain.Interfaces.Services
{
    public interface ITeamService
    {
        void CreateTeam(TeamCommand command);
    }
}
