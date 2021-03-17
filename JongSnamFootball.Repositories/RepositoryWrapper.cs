using System;
using System.Threading.Tasks;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace JongSnamFootball.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper, IDisposable
    {
        private readonly RepositoryDbContext _repositoryDbContext;
        private IDbContextTransaction _dbContextTransaction;

        private IReviewRepository _commentRepository;
        private IDiscountRepository _discountRepository;
        private IFieldRepository _fieldRepository;
        private IPaymentRepository _paymentRepository;
        private IReservationRepository _reservationRepository;
        private IStoreRepository _storeRepository;
        private IUserRepository _userRepository;
        private IPictureFieldRepository _pictureField;
        private IReviewRepository _reviewRepository;


        public RepositoryWrapper(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public IReviewRepository Comment
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new ReviewRepository(_repositoryDbContext);
                }

                return _commentRepository;
            }
        }

        public IDiscountRepository Discount
        {
            get
            {
                if (_discountRepository == null)
                {
                    _discountRepository = new DiscountRepository(_repositoryDbContext);
                }

                return _discountRepository;
            }
        }

        public IFieldRepository Field
        {
            get
            {
                if (_fieldRepository == null)
                {
                    _fieldRepository = new FieldRepository(_repositoryDbContext);
                }

                return _fieldRepository;
            }
        }

        public IPaymentRepository Payment
        {
            get
            {
                if (_paymentRepository == null)
                {
                    _paymentRepository = new PaymentRepository(_repositoryDbContext);
                }

                return _paymentRepository;
            }
        }

        public IReservationRepository Reservation
        {
            get
            {
                if (_reservationRepository == null)
                {
                    _reservationRepository = new ReservationRepository(_repositoryDbContext);
                }

                return _reservationRepository;
            }
        }

        public IStoreRepository Store
        {
            get
            {
                if (_storeRepository == null)
                {
                    _storeRepository = new StoreRepository(_repositoryDbContext);
                }

                return _storeRepository;
            }
        }

        public IUserRepository User
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_repositoryDbContext);
                }

                return _userRepository;
            }
        }
        public IPictureFieldRepository PictureField
        {
            get
            {
                if (_pictureField == null)
                {
                    _pictureField = new PictureFieldRepository(_repositoryDbContext);
                }

                return _pictureField;
            }
        }
        public IReviewRepository Review
        {
            get
            {
                if (_reviewRepository == null)
                {
                    _reviewRepository = new ReviewRepository(_repositoryDbContext);
                }

                return _reviewRepository;
            }
        }

        public async Task<int> SaveAsync()
        {
            return await _repositoryDbContext.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
             _dbContextTransaction = await _repositoryDbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _dbContextTransaction?.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _dbContextTransaction?.RollbackAsync();
        }

        public void Dispose()
        {
            _dbContextTransaction?.Dispose();
            _repositoryDbContext?.Dispose();
        }
    }
}
