using Anabi.Domain;
using Anabi.Features.Assets.Models;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anabi.DataAccess.Ef;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace Anabi.Features.Assets
{
    public class GetAssetHandler : BaseHandler, IAsyncRequestHandler<GetAssetDetails, AssetDetails>
    {
        public GetAssetHandler(AnabiContext _ctx, IMapper _mapper) : base(_ctx, _mapper)
        {
        }

        public async Task<AssetDetails> Handle(GetAssetDetails message)
        {
            var decisionsTask = GetDecisionsAsync(message);
            var assetTask = GetAssetAsync(message);
            var filesTask = GetFilesAsync(message);

            await Task.WhenAll(decisionsTask, assetTask, filesTask);

            return new AssetDetails()
            {
                Decisions = decisionsTask.Result,
                Asset = assetTask.Result,
                Files = filesTask.Result
            };

            
        }

        private async Task<List<DecisionDetails>> GetDecisionsAsync(GetAssetDetails message)
        {
            var query = (from h in context.EtapeIstorice
                         join a in context.Bunuri on h.AssetId equals a.Id
                         join d in context.Decizii on h.DecizieId equals d.Id
                         join i in context.Institutii on h.InstitutionId equals i.Id
                         join p in context.Persoane on h.OwnerId equals p.Id
                         join s in context.Etape on h.StageId equals s.Id
                         
                         where a.Id == message.Id
                         select new
                         {
                             historicalStage = h,
                             asset = a,
                             decisionDictionary = d,
                             institutionDictionary = i,
                             person = p,
                             stageDictionary = s
                             
                         }
                                     );


            var decisions = await query.Select(x => new DecisionDetails
            {
                Id = x.historicalStage.Id,
                ActualValue = x.historicalStage.ActualValue,
                ActualValueCurrency = x.historicalStage.ActualValueCurrency,
                AddedDate = x.historicalStage.AddedDate,
                AssetId = x.historicalStage.AssetId,
                AssetState = x.historicalStage.AssetState,
                AssetUniqueIdentifier = x.asset.Identifier,
                DecisionDate = x.historicalStage.DecisionDate,
                DecisionName = x.decisionDictionary.Name,
                DecisionNumber = x.historicalStage.DecisionNumber,
                DecizieId = x.decisionDictionary.Id,
                EstimatedAmount = x.historicalStage.EstimatedAmount,
                EstimatedAmountCurrency = x.historicalStage.EstimatedAmountCurrency,
                InstitutionId = x.historicalStage.InstitutionId,
                InstitutionName = x.institutionDictionary.Name,
                LastChangeDate = x.historicalStage.LastChangeDate,
                LegalBasis = x.historicalStage.LegalBasis,
                OwnerId = x.historicalStage.OwnerId,
                OwnerName = x.person.Name,
                StageId = x.historicalStage.StageId,
                StageName = x.stageDictionary.Name,
                UserCodeAdd = x.historicalStage.UserCodeAdd,
                UserCodeLastChange = x.historicalStage.UserCodeLastChange
            }).ToListAsync();

            return decisions;
        }

        private async Task<Asset> GetAssetAsync(GetAssetDetails message)
        {
            var assetTask = (from
                          a in context.Bunuri
                               join adr in context.Adrese on a.AddressId equals adr.Id
                               join c in context.Judete on adr.CountyId equals c.Id
                               join cat in context.Categorii on a.CategoryId equals cat.Id
                               where a.Id == message.Id
                               select new Asset
                               {
                                   AddedDate = a.AddedDate,
                                   Address = new Address
                                   {
                                       Building = adr.Building,
                                       City = adr.City,
                                       CountyId = adr.CountyId,
                                       CountyName = c.Name,
                                       FlatNo = adr.FlatNo,
                                       Floor = adr.Floor,
                                       Id = adr.Id,
                                       Stair = adr.Stair,
                                       Street = adr.Street
                                   },
                                   CategoryId = a.CategoryId,
                                   CategoryName = cat.Code,
                                   Id = a.Id,
                                   Identifier = a.Identifier,
                                   IsDeleted = a.IsDeleted,
                                   LastChangeDate = a.LastChangeDate,
                                   NecessaryVolume = a.NecessaryVolume,
                                   UserCodeAdd = a.UserCodeAdd,
                                   UserCodeLastChange = a.UserCodeLastChange,
                                   NrOfObjects  = a.NrOfObjects,
                                   MeasureUnit  = a.MeasureUnit,
                                   Remarks      = a.Remarks

                               }).FirstAsync();

            var storageSpacesTask = (from a in context.Bunuri
                                     join asp in context.BunuriSpatiiStocare on a.Id equals asp.AssetId
                                     join sp in context.SpatiiStocare on asp.StorageSpaceId equals sp.Id
                                     join adr in context.Adrese on sp.AddressId equals adr.Id
                                     join c in context.Judete on adr.CountyId equals c.Id
                                     where a.Id == message.Id
                                     select new StorageSpace
                                     {
                                         Id = sp.Id,
                                         AddedDate = asp.AddedDate,
                                         Address = new Address
                                         {
                                             Building = adr.Building,
                                             City = adr.City,
                                             CountyId = adr.CountyId,
                                             CountyName = c.Name,
                                             FlatNo = adr.FlatNo,
                                             Floor = adr.Floor,
                                             Id = adr.Id,
                                             Stair = adr.Stair,
                                             Street = adr.Street
                                         }
                                     }).ToListAsync();


            await Task.WhenAll(assetTask, storageSpacesTask);

            var model = assetTask.Result;
            model.StorageSpaces = storageSpacesTask.Result;

            return model;
        }

        private async Task<List<File>> GetFilesAsync(GetAssetDetails message)
        {
            var filesTask = (from a in context.BunuriDosare
                             join f in context.Dosare on a.FileId equals f.Id
                             where a.AssetId == message.Id

                             select new File
                             {
                                 Id = f.Id,
                                 AddedDate = f.AddedDate,
                                 CriminalField = f.CriminalField,
                                 CurrentFileNumber = f.CurrentFileNumber,
                                 CurrentFileNumberId = f.CurrentFileNumberId,
                                 DamageAmount = f.DamageAmount,
                                 DamageCurrency = f.DamageCurrency,
                                 InitialFileId = f.InitialFileId,
                                 InitialFileNumber = f.InitialFileNumber,
                                 LastChangeDate = f.LastChangeDate,
                                 LegalClassification = f.LegalClassification,
                                 UserCodeAdd = f.UserCodeAdd,
                                 UserCodeLastChange = f.UserCodeLastChange
                             }).ToListAsync();

            var defendantsTask = (from a in context.BunuriDosare
                                  join f in context.Dosare on a.FileId equals f.Id
                                  join df in context.InculpatiDosar on f.Id equals df.FileId
                                  join d in context.Persoane on df.PersonId equals d.Id
                                  join adr in context.Adrese on d.AddressId equals adr.Id
                                  join c in context.Judete on adr.CountyId equals c.Id
                                  where a.AssetId == message.Id
                                  select new Defendant
                                  {
                                      Id = d.Id,
                                      AddedDate = d.AddedDate,
                                      Address = new Address
                                      {
                                          Building = adr.Building,
                                          City = adr.City,
                                          CountyId = adr.CountyId,
                                          CountyName = c.Name,
                                          FlatNo = adr.FlatNo,
                                          Floor = adr.Floor,
                                          Id = adr.Id,
                                          Stair = adr.Stair,
                                          Street = adr.Street
                                      },
                                      Identification = d.Identification,
                                      IdNumber = d.IdNumber,
                                      IdSerie = d.IdSerie,
                                      IsPerson = d.IsPerson,
                                      LastChangeDate = d.LastChangeDate,
                                      Name = d.Name,
                                      UserCodeAdd = d.UserCodeAdd,
                                      UserCodeLastChange = d.UserCodeLastChange,
                                      FileId = f.Id
                                  }
                                  ).ToListAsync();

            await Task.WhenAll(filesTask, defendantsTask);

            var files = filesTask.Result;
            var defendants = defendantsTask.Result;

            files.ForEach(f => { f.Defendants = defendants.Where(d => d.FileId == f.Id).Select(r => r).ToList(); });

            return files;
        }
    }
}
