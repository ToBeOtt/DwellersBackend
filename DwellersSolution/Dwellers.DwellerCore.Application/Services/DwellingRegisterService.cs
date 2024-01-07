//using Dwellers.DwellerCore.Contracts.Commands;
//using Dwellers.DwellerCore.Contracts.Result;
//using Dwellers.DwellerCore.Domain.Entities;
//using Dwellers.DwellerCore.Domain.Entities.Dwellers;
//using Dwellers.DwellerCore.Domain.Entities.Dwellings;
//using Dwellers.DwellerCore.Interfaces;
//using Microsoft.Extensions.Logging;
//using SharedKernel.ServiceResponse;

//namespace Dwellers.DwellerCore.Services
//{
//    public class DwellingRegisterService
//    {
//        private readonly ILogger<DwellingRegisterService> _logger;
//        private readonly IDwellerRepository _dwellerRepository;
//        private readonly IDwellingRepository _dwellingRepository;
//        private readonly IDwellerCoreQueries _dwellerCoreQueries;

//        public DwellingRegisterService(
//            ILogger<DwellingRegisterService> logger,
//            IDwellerRepository dwellerRepository,
//            IDwellingRepository dwellingRepository,
//            IDwellerCoreQueries dwellerCoreQueries)
//        {
//            _logger = logger;
//            _dwellerRepository = dwellerRepository;
//            _dwellingRepository = dwellingRepository;
//            _dwellerCoreQueries = dwellerCoreQueries;
//        }

//        // Create a dwelling and attach the newly created dweller to this
//        public async Task<DwellerResponse<DwellingToUserResult>> AttachDwellingToDweller(RegisterDwellingCommand cmd)
//        {
//            DwellerResponse<DwellingToUserResult> response = new();
//            var transaction = await _dwellingRepository.BeginTransactionAsync();

//            try
//            {
//                var dwelling = await Dwelling.DwellerHouseFactory.Create(cmd.Name, cmd.Description);

//                var dweller = await _dwellerRepository.GetDwellerByEmail(cmd.Email);
//                if (dweller == null)
//                    throw new NullReferenceException(nameof(dweller));

//                await _dwellingRepository.AddDwelling(dwelling);

//                var dwellingInhabitant = await DwellingInhabitant.DwellingInhabitantFactory.Create
//                    (dweller.Id, dwelling.Id);

//                await _dwellerRepository.AddDwellerInhabitant(dwellingInhabitant);

//                DwellingToUserResult data = new(
//                    Name: dwelling.GetName(),
//                    HouseId: dwelling.Id.Value
//                    ); 

//                await transaction.CommitAsync();
//                return await response.SuccessResponse(response, data);
//            }
//            catch (Exception ex)
//            {
//                await transaction.RollbackAsync();
//                return await response.ErrorResponse
//                    (response, ex.Message, _logger);
//            }
//        }

//        // Attach user to a already existing dwelling
//        public async Task<DwellerResponse<AttachDwellerToDwellingResult>> AttachDwellerToDwelling
//            (AttachDwellerToDwellingCommand command)
//        {
//            DwellerResponse<AttachDwellerToDwellingResult> response = new();
//            var transaction = await _dwellingRepository.BeginTransactionAsync();
//            try
//            {
//                var dweller = await _dwellerRepository.GetDwellerByEmail(command.Email);
//                if (dweller == null)
//                    throw new NullReferenceException(nameof(dweller));

//                var dwelling = await _dwellerCoreQueries.GetDwellingByInvite(command.Invitation);
//                if (dwelling == null)
//                    throw new NullReferenceException(nameof(dwelling));

//                var dwellingInhabitant = await DwellingInhabitant.DwellingInhabitantFactory.Create
//                    (dweller.Id, dwelling.Id);

//                await _dwellerRepository.AddDwellerInhabitant(dwellingInhabitant);

//                AttachDwellerToDwellingResult data = new AttachDwellerToDwellingResult(
//                      DwellingName: dwelling.GetName(),
//                      Alias: dweller.GetAlias()
//                       );

//                await transaction.CommitAsync();
//                return await response.SuccessResponse(response, data);
//            }
//            catch (Exception ex)
//            {
//                await transaction.RollbackAsync();
//                return await response.ErrorResponse
//                    (response, ex.Message, _logger); 
//            }

           
//        }
//    }
//}
