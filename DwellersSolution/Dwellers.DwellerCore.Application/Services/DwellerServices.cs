//using Dwellers.DwellerCore.Contracts.Commands;
//using Dwellers.DwellerCore.Contracts.Queries;
//using Dwellers.DwellerCore.Domain.Entities.Dwellers;
//using Dwellers.DwellerCore.Domain.Entities.Dwellings;
//using Dwellers.DwellerCore.Services.DTO;
//using Microsoft.Extensions.Logging;
//using SharedKernel.Application.DwellerResponse;

//namespace Dwellers.DwellerCore.Services
//{
//    public class DwellerServices
//    {
//        private readonly IDwellerRepository _dwellerRepository;
//        private readonly IDwellingRepository _dwellingRepository;
//        private readonly ILogger<DwellerServices> _logger;

//        public DwellerServices(
//            IDwellerRepository dwellerRepository,
//            IDwellingRepository dwellingRepository,
//            ILogger<DwellerServices> logger)
//        {
//            _dwellerRepository = dwellerRepository;
//            _dwellingRepository = dwellingRepository;
//            _logger = logger;
//        }

//        public async Task<DwellerResponse<bool>> CreateDwellerUser
//            (string dbUserId, string dbUserEmail, string dbUserAlias)
//        {
//            DwellerResponse<bool> response = new();

//            var dweller = await Dweller.DwellerFactory.Create
//                (dbUserId, dbUserAlias, dbUserEmail);

//            if (!await _dwellerRepository.AddDweller(dweller))
//                return await response.ErrorResponse(response, "User could not be persisted.", _logger);

//            return await response.SuccessResponse(response);
//        }

//        public async Task<DwellerResponse<bool>> UpdateUserInformation
//            (UpdateDwellerCommand cmd)
//        {
//            DwellerResponse<bool> response = new();

//            var dweller = await _dwellerRepository.GetDwellerById(cmd.UserId);
//            if (dweller is null)
//                return await response.ErrorResponse
//                    (response, "User could not be found.", _logger, 
//                    "An error occurred while updating the user profile photo.");
           
//            return await response.SuccessResponse(response, true);
//        }

//        public async Task<DwellerResponse<FetchUserDetailsResponse>> FetchUserDetails
//            (FetchUserDataQuery query)
//        {
//            DwellerResponse<FetchUserDetailsResponse> response = new();
//            var dweller = await _dwellerRepository.GetDwellerById(query.DwellerId);
//            if (dweller is null)
//                return await response.ErrorResponse(response, "User details could not be fetched.", _logger);

//            var dwelling = await _dwellingRepository.GetDwellingById(query.DwellingId);
//            if (dwelling is null)
//                return await response.ErrorResponse
//                    (response, "User details could not be fetched.", _logger, "House not found in database.");


//            FetchUserDetailsResponse data = new(
//                DwellerId: dweller.Id,
//                DwellingId: dwelling.Id.Value
//                );
//            return await response.SuccessResponse(response, data);
//        }
//    }
//}
