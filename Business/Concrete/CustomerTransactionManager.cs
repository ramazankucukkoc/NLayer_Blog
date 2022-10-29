using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.ComplexTypes;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerTransactionManager : ICustomerTrasanctionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductService _productService;

        public CustomerTransactionManager(IMapper mapper, IUnitOfWork unitOfWork, IProductService productService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productService = productService;
        }



        public async Task<IDataResult<CustomerTransactionDto>> Add(CustomerTransactionAddDto customerTransactionAddDto, string createdByName)
        {

            var customerTransaction = _mapper.Map<CustomerTransaction>(customerTransactionAddDto);
            customerTransaction.CreatedByName = createdByName;
            customerTransaction.ModifiedByName = createdByName;
            customerTransaction.TotalPrice = customerTransaction.Unit * customerTransaction.UnitPrice;
            


            var addCustomerTransaction = await _unitOfWork.CustomerTransaction.AddAsync(customerTransaction);
            await _unitOfWork.SaveAsync();
            return new DataResult<CustomerTransactionDto>(ResultStatus.Success, "Hareket eklendi.", new CustomerTransactionDto
            {
                CustomerTransaction = addCustomerTransaction,
                ResultStatus = ResultStatus.Success,
                Message = "Hareket eklendi"
            });

        }
        public Task<IDataResult<CustomerTransactionListDto>> GetAllByProduct(int productId)
        {
            throw new NotImplementedException();
        }



        public Task<IDataResult<CustomerTransactionDto>> Delete(int customerTransactionId, string modifiedByName)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionDto>> Get(int customerTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionListDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionListDto>> GetAllByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<IDataResult<CustomerTransactionListDto>> GetAllByNonDeleted()
        {
            var customerTransaction = await _unitOfWork.CustomerTransaction.GetAllAsync(c => !c.IsDeleted, c => c.Customer, c => c.Product, c => c.Personel);

            if (customerTransaction.Count > -1)
            {
                
                return new DataResult<CustomerTransactionListDto>(ResultStatus.Success, new CustomerTransactionListDto
                {
                    CustomerTransactions = customerTransaction,
                    ResultStatus = ResultStatus.Success
                });
            }
            return new DataResult<CustomerTransactionListDto>(ResultStatus.Error, "Hiçbir cari bulunamadı", new CustomerTransactionListDto
            {
                CustomerTransactions = null,
                ResultStatus = ResultStatus.Error
            });

        }

        public Task<IDataResult<CustomerTransactionListDto>> GetAllByNonDeletedAndActive()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionListDto>> GetAllByPersonel(int personelId)
        {
            throw new NotImplementedException();
        }

       

        public Task<IDataResult<CustomerTransactionUpdateDto>> GetCustomerTransactionUpdate(int customerTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> HardDelete(int customerTransactionId)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<CustomerTransactionDto>> Update(CustomerTransactionUpdateDto customerTransactionUpdateDto, string modifiedByName)
        {
            throw new NotImplementedException();
        }
    }
}
