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

        ICommentRepository Comment { get; }

        Task<int> SaveAsync();

        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}
