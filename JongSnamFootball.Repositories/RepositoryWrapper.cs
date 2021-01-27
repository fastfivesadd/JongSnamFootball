using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JongSnamFootball.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace JongSnamFootball.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper, IDisposable
    {
        private readonly RepositoryDbContext _repositoryDbContext;
        private IDbContextTransaction _dbContextTransaction;

        private ICommentRepository _commentRepository;
        private IDiscountRepository _discountRepository;
        private IFieldRepository _fieldRepository;
        private IPaymentRepository _paymentRepository;
        private IReservationRepository _reservationRepository;
        private IStoreRepository _storeRepository;
        private IUserRepository _userRepository;

        public RepositoryWrapper(RepositoryDbContext repositoryDbContext)
        {
            _repositoryDbContext = repositoryDbContext;
        }

        public ICommentRepository Comment
        {
            get
            {
                if (_commentRepository == null)
                {
                    _commentRepository = new CommentRepository(_repositoryDbContext);
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

        public async Task<int> SaveAsync()
        {
            return await _repositoryDbContext.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _repositoryDbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContextTransaction?.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction?.Rollback();
        }

        public void Dispose()
        {
            _dbContextTransaction?.Dispose();
            _repositoryDbContext?.Dispose();
        }
    }
}
