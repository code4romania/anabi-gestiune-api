using Anabi.DataAccess.Ef.DbModels;
using Anabi.Domain.Category.Commands;
using Anabi.Domain.Core.Asset.Commands;
using Anabi.Domain.Models;
using Anabi.Features.Category.Models;
using AutoMapper;

namespace Anabi
{
    using Anabi.Common.ViewModels;
    using Anabi.Domain.Asset.Commands;
    using Anabi.Domain.Asset.Commands.Models;
    using Anabi.Domain.Common.Address;
    using Anabi.Domain.Institution.Commands;
    using Anabi.Domain.Person.Commands;
    using Anabi.Domain.StorageSpaces.Commands;
    using Anabi.Features.Assets.Models;
    using Anabi.Features.Institution.Models;
    using Anabi.Features.Person.Models;

    public class AutoMapperMappings : Profile
    {
        public AutoMapperMappings()
        {
            CreateMap<Address, AddressDb>().ReverseMap();
            

            CreateMap<Category, CategoryDb>().ReverseMap();
            CreateMap<AddCategory, CategoryDb>();
            CreateMap<EditCategory, CategoryDb>();

            CreateMap<AddStorageSpace, StorageSpaceDb>().ReverseMap();
            CreateMap<EditStorageSpace, StorageSpaceDb>().ReverseMap();

            CreateMap<County, CountyDb>().ReverseMap();
            CreateMap<Decision, DecisionDb>().ReverseMap();
            CreateMap<HistoricalStage, HistoricalStageDb>().ReverseMap();

            CreateMap<Institution, InstitutionDb>().ReverseMap();
            CreateMap<AddInstitution, InstitutionDb>();
            CreateMap<EditInstitution, InstitutionDb>();
            CreateMap<IAddAddress, AddressDb>();

            CreateMap<Person, PersonDb>().ReverseMap();
            CreateMap<RecoveryBeneficiary, RecoveryBeneficiaryDb>().ReverseMap();
            CreateMap<Stage, StageDb>().ReverseMap();

            CreateMap<StorageSpace, StorageSpaceDb>().ReverseMap();
            CreateMap<StorageSpace, StorageSpaceViewModel>().ReverseMap();

            CreateMap<StorageSpaceViewModel, StorageSpaceDb>().ReverseMap();

            CreateMap<StageViewModel, StageDb>().ReverseMap();
            CreateMap<CategoryViewModel, CategoryDb>().ReverseMap();

            CreateMap<User, UserDb>().ReverseMap();

            CreateMap<IdentifierDb, Identifier>().ReverseMap();

            CreateMap<AddDefendant, PersonDb>().ReverseMap();

            CreateMap<AddOwner, PersonDb>().ReverseMap();

            CreateMap<AddSolutionRequest, AddSolution>();
            CreateMap<AddSolution, SolutionViewModel>();
            CreateMap<AddMinimalAsset, MinimalAssetViewModel>();

            CreateMap<AddDefendantRequest, AddDefendant>();
            CreateMap<AddDefendantRequest, DefendantViewModel>();

            CreateMap<ModifyDefendant, DefendantViewModel>();
            CreateMap<ModifyDefendantRequest, ModifyDefendant>();

            CreateMap<AddOwnerRequest, AddOwner>();
            CreateMap<AddOwnerRequest, OwnerViewModel>();

            CreateMap<ModifyOwner, OwnerViewModel>();
            CreateMap<ModifyOwnerRequest, ModifyOwner>();

            CreateMap<AddAssetAddressRequest, AddressViewModel>();
            CreateMap<ModifyAssetAddressRequest, ModifyAssetAddressModel>();
            CreateMap<ModifyAssetAddressRequest, AddressViewModel>();

            CreateMap<RecoveryDetails, RecoveryDetailsViewModel>();
            CreateMap<EvaluationCommittee, EvaluationCommitteeViewModel>();
            CreateMap<SolutionDetails, SolutionDetailsViewModel>();
            CreateMap<RecoveryCommittee, RecoveryCommitteeViewModel>();

            CreateMap<SequesterDetails, SequesterDetailsViewModel>();
            CreateMap<ConfiscationDetails, ConfiscationDetailsViewModel>();
            CreateMap<AddAssetStorageSpace, AssetStorageSpaceViewModel>();
        }
    }
}
