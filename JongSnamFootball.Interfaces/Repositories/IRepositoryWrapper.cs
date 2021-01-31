using System.Threading.Tasks;

namespace JongSnamFootball.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        IStoreRepository Store { get; }

        IReservationRepository Reservation { get; }

        IPaymentRepository Payment { get; }

        IFieldRepository Field { get; }

        IDiscountRepository Discount { get; }

        IReviewRepository Comment { get; }

        IPictureFieldRepository PictureField { get; }

        Task<int> SaveAsync();

        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();

        void Dispose();
    }
}
