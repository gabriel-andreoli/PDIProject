using PDIProject.Persistence;

namespace PDIProject.Domain.Services
{
    public abstract class ServiceBase
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected void Commit()
        {
            _unitOfWork.Commit();
        }
    }
}
